using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Portfolio.APP.DTOs.AppUser;
using Portfolio.APP.ServiceInterface;
using Portfolio.APP.ServiceResponse;
using Portfolio.Core.DataInterfaces;
using Portfolio.Core.Entities;
using Portfolio.Core.Pagination;

namespace Portfolio.APP.ServiceImplementations
{
    public class ProfessionalStackService : IProfessionalStackService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUnitOFWork _unitOFWork;
        private readonly IMapper _mapper;
        private const string AllProfessionalStackCacheKey = "all_professional_stack_cache";

        public ProfessionalStackService(IMemoryCache memoryCache, IUnitOFWork unitOFWork, IMapper mapper)
        {
            _memoryCache = memoryCache;
            _unitOFWork = unitOFWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CreateProfessionalStackDto>> AddProfessionalStackAsync(CreateProfessionalStackDto createProfessionalStack)
        {
            var profileExist = await _unitOFWork.Profiles.GetProfileById(createProfessionalStack.ProfileId);
            if (profileExist == null)
            {
                return new ServiceResponse<CreateProfessionalStackDto>(null!, false, "Profile does not exist! Create a profile first");
            }
            

            var newProfStack = _mapper.Map<ProfessionalStack>(createProfessionalStack);

            newProfStack.AppUserId = profileExist.AppUserId;

            await _unitOFWork.ProfessionalStackRepository.CreateStackAsync(newProfStack);
            await _unitOFWork.CompleteAsync();
            var createdStack = _mapper.Map<CreateProfessionalStackDto>(newProfStack);

            _memoryCache.Set($"ProfessionalStack_{newProfStack.Id}", createProfessionalStack, TimeSpan.FromMinutes(10));
            _memoryCache.Remove(AllProfessionalStackCacheKey);

            return new ServiceResponse<CreateProfessionalStackDto>(createdStack, true, "Stack created successfully!.You can add your work experience.");
        }

        public async Task<ServiceResponse<bool>> DeleteProfessionalStackAsync(Guid id)
        {
            try
            {
                var result = await _unitOFWork.ProfessionalStackRepository.DeleteStack(id);
                if (!result)
                {
                    return new ServiceResponse<bool>(false, false, "Professional Stack not found");
                }
                await _unitOFWork.CompleteAsync();
                _memoryCache.Remove($"professional stack_{id}");
                _memoryCache.Remove(AllProfessionalStackCacheKey);
                return new ServiceResponse<bool>(true, true, "Professional Stack deleted and cache cleared ");

            }
            catch (Exception ex)
            {

                return new ServiceResponse<bool>(false, false, $"Error deleting professional stack: {ex.Message}");

            }
        }

        public async  Task<ServiceResponse<PagedResult<ProfessionalStackDto>>> GetAllProfessionalStackAsync(int pageNumber, int pageSize)
        {
            var cacheKey = $"{AllProfessionalStackCacheKey}_page_{pageNumber}_size_{pageSize}";
            if (_memoryCache.TryGetValue(cacheKey, out PagedResult<ProfessionalStackDto>? cachedProStacks))
            {
                return new ServiceResponse<PagedResult<ProfessionalStackDto>>(cachedProStacks, true, "Professional Stacks loaded from cache");
            }
            var pagedProStack = await _unitOFWork.ProfessionalStackRepository.GetPagedProfessionalStackAsync(pageNumber, pageSize);
            var mappedResult = new PagedResult<ProfessionalStackDto>
            {

                Items = _mapper.Map<List<ProfessionalStackDto>>(pagedProStack.Items),
                TotalCount = pagedProStack.TotalCount,
                PageSize = pagedProStack.PageSize,
                PageNumber = pagedProStack.PageNumber


            };
            _memoryCache.Set(cacheKey, mappedResult, TimeSpan.FromMinutes(10));
            return new ServiceResponse<PagedResult<ProfessionalStackDto>>(mappedResult, true, "Professional feltched and cached.");


        }

        public async Task<ServiceResponse<ProfessionalStackDto>> GetProfessionalStackById(Guid id)
        {
           var seatchedStack   = await  _unitOFWork.ProfessionalStackRepository.GetStackById(id);
            if (seatchedStack == null) 
            {
                return new ServiceResponse<ProfessionalStackDto>(null!, false, "Professional Stack not found");

            }
            var proStackInfo = _mapper.Map<ProfessionalStackDto>(seatchedStack);
            return new ServiceResponse<ProfessionalStackDto>(proStackInfo, true, "Professional Stack retrieved successfully!");
        }

        public async Task<ServiceResponse<ProfessionalStackDto>> UpdateProfessionalStackAsync(Guid id, UpdateProfessionalStackDto updateProfessionalStackDto)
        {
            var existingProStack = await _unitOFWork.ProfessionalStackRepository.GetStackById(id);
            if (existingProStack == null)
            {
                return new ServiceResponse<ProfessionalStackDto>(null!, false, "Professional Stack not found");

            }

         _mapper.Map(updateProfessionalStackDto, existingProStack);
            await _unitOFWork.ProfessionalStackRepository.UpdateStackAsync(existingProStack);
            await _unitOFWork.CompleteAsync();
            var updateProstack = _mapper.Map<ProfessionalStackDto>(existingProStack);

            // removing cache
            _memoryCache.Remove($"professional stack_{id}");
            _memoryCache.Remove(AllProfessionalStackCacheKey);

            return new ServiceResponse<ProfessionalStackDto>(updateProstack, true, "Professional Stacked Updated and cache invalided");

        }
    }
}
