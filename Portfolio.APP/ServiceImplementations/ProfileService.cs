using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Portfolio.APP.DTOs.ProfileDtos;
using Portfolio.APP.ServiceInterface;
using Portfolio.APP.ServiceResponse;
using Portfolio.Core.DataInterfaces;
using Portfolio.Core.Entities;
using Portfolio.Core.Pagination;

namespace Portfolio.APP.ServiceImplementations
{
    public class ProfileService : IProfileService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUnitOFWork _unitOFWork;
        private readonly IMapper _mapper;

        private const string AllProfilesCacheKey = "all_profiles_cache";

        public ProfileService(IUnitOFWork unitOFWork, IMemoryCache memoryCache, IMapper mapper)
        {
            _unitOFWork = unitOFWork;
            _memoryCache = memoryCache;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CreateProfileDto>> CreateProfileAsync(CreateProfileDto profileDto)
        {
            var newProfile = _mapper.Map<ProfileEntity>(profileDto);

            await _unitOFWork.Profiles.CreateProfileAsync(newProfile);
            await _unitOFWork.CompleteAsync();

            var createdProfileDto = _mapper.Map<CreateProfileDto>(newProfile);

            // Cache single profile
            var profileCacheKey = $"profile_{newProfile.Id}";
            _memoryCache.Set(profileCacheKey, createdProfileDto, TimeSpan.FromMinutes(30));

            // Invalidate paged cache
            _memoryCache.Remove(AllProfilesCacheKey);

            return new ServiceResponse<CreateProfileDto>(createdProfileDto, true, "Profile created and cached.");
        }

        public async Task<ServiceResponse<bool>> DeleteProfileAsync(Guid id)
        {
            try
            {
                var result = await _unitOFWork.Profiles.DeleteProfileAsync(id);

                if (!result)
                {
                    return new ServiceResponse<bool>(false, false, "Profile not found or already deleted.");
                }

                await _unitOFWork.CompleteAsync();

                // Invalidate individual and paged profile caches
                _memoryCache.Remove($"profile_{id}");
                _memoryCache.Remove(AllProfilesCacheKey);

                return new ServiceResponse<bool>(true, true, "Profile deleted and cache cleared.");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>(false, false, $"Error deleting profile: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<PagedResult<ProfileDto>>> GetAllProfilesAsync(int pageNumber, int pageSize)
        {
            var cacheKey = $"{AllProfilesCacheKey}_page_{pageNumber}_size_{pageSize}";

            if (_memoryCache.TryGetValue(cacheKey, out PagedResult<ProfileDto>? cachedProfiles))
            {
                return new ServiceResponse<PagedResult<ProfileDto>>(cachedProfiles, true, "Profiles loaded from cache.");
            }

            var pagedProfiles = await _unitOFWork.Profiles.GetPagedProfilesAsync(pageNumber, pageSize);

            var mappedResult = new PagedResult<ProfileDto>
            {
                Items = _mapper.Map<List<ProfileDto>>(pagedProfiles.Items),
                TotalCount = pagedProfiles.TotalCount,
                PageSize = pagedProfiles.PageSize,
                PageNumber = pagedProfiles.PageNumber
            };

            _memoryCache.Set(cacheKey, mappedResult, TimeSpan.FromMinutes(30));

            return new ServiceResponse<PagedResult<ProfileDto>>(mappedResult, true, "Profiles fetched and cached.");
        }

        public async Task<ServiceResponse<UpdateProfileDto>> UpdateProfileAsync(Guid id, UpdateProfileDto profileDto)
        {
            var existingProfile = await _unitOFWork.Profiles.GetProfileById(id);
            if (existingProfile == null)
            {
                return new ServiceResponse<UpdateProfileDto>(null!, false, "Profile not found.");
            }

            _mapper.Map(profileDto, existingProfile);

            await _unitOFWork.Profiles.UpdateProfileAsync(existingProfile);
            await _unitOFWork.CompleteAsync();

            var updatedDto = _mapper.Map<UpdateProfileDto>(existingProfile);

            // Invalidate or update individual profile cache
            _memoryCache.Remove($"profile_{id}");
            _memoryCache.Remove(AllProfilesCacheKey);

            return new ServiceResponse<UpdateProfileDto>(updatedDto, true, "Profile updated and cache invalidated.");
        }
    }
}
