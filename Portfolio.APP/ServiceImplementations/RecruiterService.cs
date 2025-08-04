using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Portfolio.APP.DTOs.ProfileDtos;
using Portfolio.APP.DTOs.Recruiter;
using Portfolio.APP.ServiceInterface;
using Portfolio.APP.ServiceResponse;
using Portfolio.Core.DataInterfaces;
using Portfolio.Core.Entities;
using Portfolio.Core.Pagination;

namespace Portfolio.APP.ServiceImplementations
{
    public class RecruiterService : IRecruiterService
    {
        private readonly IUserService _userService;
        private readonly IMemoryCache _memoryCache;
        private readonly IUnitOFWork _unitOFWork;
        private readonly IMapper _mapper;

        private const string AllRecruitersCacheKey = "all_recruiters_cache";
        public RecruiterService(IUserService userService, IMemoryCache memoryCache, IUnitOFWork unitOFWork, IMapper mapper)
        {
            _userService = userService;
            _memoryCache = memoryCache;
            _unitOFWork = unitOFWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CreateRecruiterProfileDto>> CreateRecruiterAsync(CreateRecruiterProfileDto recruiterProfile)
        {
           // validate user
           var validAppUserId = await _unitOFWork.AppUserRepository.GetUserByIdAsync(recruiterProfile.AppUserId);
            if (validAppUserId == null)
            {
                return new ServiceResponse<CreateRecruiterProfileDto>(null!, false, "The UserId is invalid. Sign up first before creating a recruite's profile.");
            }
            // check if Recruiter already exist
            var existingRecruiter = await _unitOFWork.RecruiterRepository.GetRecruiterProfileByUserIdAsync(recruiterProfile.AppUserId);
            if (existingRecruiter != null)
            {
                return new ServiceResponse<CreateRecruiterProfileDto>(null!, false, "A Recruiter's Profile already exists for this user.");
            }
            // map and create Recruiter
            var newRecruiter = _mapper.Map<RecruiterProfile>(recruiterProfile);

            await _unitOFWork.RecruiterRepository.AddRecruiter(newRecruiter);
            await _unitOFWork.CompleteAsync();
            var createdRecruiter = _mapper.Map<CreateRecruiterProfileDto>(newRecruiter);

            // Cache
            _memoryCache.Set($"recruiter_{newRecruiter.Id}", createdRecruiter, TimeSpan.FromMinutes(10));
            _memoryCache.Remove(AllRecruitersCacheKey);

            return new ServiceResponse<CreateRecruiterProfileDto>(createdRecruiter, true, "Recruiter's Profile created and cached.");

        }

        public async Task<ServiceResponse<bool>> DeleteRecruiterAsync(Guid id)
        {
            try
            {
                var getRecruiter = await _unitOFWork.RecruiterRepository.DeleteRecruiterProfileById(id);
                if (!getRecruiter)
                {
                    return new ServiceResponse<bool>(false, false, "Recruiter not found!");
                }
                await _unitOFWork.CompleteAsync();
                _memoryCache.Remove($"recruiter_{id}");
                _memoryCache.Remove(AllRecruitersCacheKey);
                return new ServiceResponse<bool>(true, true, "Recruiter deleted and cache cleared!");

            }
            catch (Exception ex)
            {

                return new ServiceResponse<bool>(false, false, $"Error deletingRecruiter's profile: {ex.Message}");

            }

        }

       

        public async Task<ServiceResponse<PagedResult<RecruiterProfileDto>>> GetAllRecruitersAsync(int pageNumber, int pageSize)
        {
            var cacheKey = $"{AllRecruitersCacheKey}_page_{pageNumber}_size_{pageSize}";

            if (_memoryCache.TryGetValue(cacheKey, out PagedResult<RecruiterProfileDto>? cachedRecruiters))
            {
                return new ServiceResponse<PagedResult<RecruiterProfileDto>>(cachedRecruiters, true, "Recruiters loaded from cache");
            }

            var pagedRecruiters = await _unitOFWork.RecruiterRepository.GetAllPagedRecruiterProfiles(pageNumber, pageSize);

            var mappedResult = new PagedResult<RecruiterProfileDto>
            {
                Items = _mapper.Map<List<RecruiterProfileDto>>(pagedRecruiters.Items),
                TotalCount = pagedRecruiters.TotalCount,
                PageSize = pagedRecruiters.PageSize,
                PageNumber = pagedRecruiters.PageNumber
            };

            _memoryCache.Set(cacheKey, mappedResult, TimeSpan.FromMinutes(10));

            return new ServiceResponse<PagedResult<RecruiterProfileDto>>(mappedResult, true, "Recruiter Profiles fetched and cached.");
        }

        public async Task<ServiceResponse<CreateRecruiterProfileDto>> GetRecruiterById(Guid id)
        {
            var searchedRecruiter = await _unitOFWork.RecruiterRepository.GetRecruiterProfileById(id);
            if (searchedRecruiter == null)
            {
                return new ServiceResponse<CreateRecruiterProfileDto>(null!, false, "Recruiter not found");
            }
            var recruiterInfo = _mapper.Map<CreateRecruiterProfileDto>(searchedRecruiter);
            return new ServiceResponse<CreateRecruiterProfileDto>(recruiterInfo, true, "Recruiter's profile retrieved successfully!");
        }

        public async Task<ServiceResponse<RecruiterProfileDto>> UpdateRecruiterProfileAsync(Guid id, UpdateRecruiterProfileDto updateRecruiterProfile)
        {
            var existingRecruiterProfile = await _unitOFWork.RecruiterRepository.GetRecruiterProfileById(id);
            if(existingRecruiterProfile == null)
            {
                return new ServiceResponse<RecruiterProfileDto>(null!, false, "Recruiter not found");
            }
            // map
            _mapper.Map(updateRecruiterProfile, existingRecruiterProfile);
            await _unitOFWork.RecruiterRepository.UpdateRecruiter(existingRecruiterProfile);
            await _unitOFWork.CompleteAsync();

            var updatedRecruiterDto = _mapper.Map<RecruiterProfileDto>(existingRecruiterProfile);
            _memoryCache.Remove($"recruiter_{id}");
            _memoryCache.Remove(AllRecruitersCacheKey);
            return new ServiceResponse<RecruiterProfileDto>(updatedRecruiterDto, true, "Recruiter's Profile updated and cache invalidated.");


        }

        public async Task<ServiceResponse<RecruiterDto>> GetRecruiterByUserId(Guid userId)
        {
            var searchedRecruiter = await _unitOFWork.RecruiterRepository.GetRecruiterProfileByUserIdAsync(userId);
            if (searchedRecruiter == null)
            {
                return new ServiceResponse<RecruiterDto>(null!, false, "Recruiter not found");
            }
            var recruiterInfo = _mapper.Map<RecruiterDto>(searchedRecruiter);
            return new ServiceResponse<RecruiterDto>(recruiterInfo, true, "Recruiter retrieved successfully");

        }
    }
}
