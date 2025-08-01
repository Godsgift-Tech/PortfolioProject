using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Portfolio.APP.DTOs.AppUser;
using Portfolio.APP.ServiceInterface;
using Portfolio.APP.ServiceResponse;
using Portfolio.Core.DataInterfaces;
using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.APP.ServiceImplementations
{
    public class WorkExperienceService : IWorkExperienceService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUnitOFWork _unitOFWork;
        private readonly IMapper _mapper;
        private const string AllWorkExperienceCacheKey = "all_work_experience_cache";
        public WorkExperienceService(IMemoryCache memoryCache, IUnitOFWork unitOFWork, IMapper mapper)
        {
            _memoryCache = memoryCache;
            _unitOFWork = unitOFWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CreateWorkExperienceDto>> AddWorkExperienceAsync(CreateWorkExperienceDto createWorkExperienceDto)
        {
            // Step 1: Validate ProfessionalStack
            var existingProstack = await _unitOFWork.ProfessionalStackRepository.GetStackById(createWorkExperienceDto.ProfessionalStackId);
            if (existingProstack == null)
            {
                return new ServiceResponse<CreateWorkExperienceDto>(null!, false, "You do not have a stack yet! Create a professional stack first");
            }

            //  Map and assign ProfileId from ProfessionalStack
            var newWorkExperience = _mapper.Map<WorkExperience>(createWorkExperienceDto);
            newWorkExperience.ProfileId = existingProstack.ProfileId;
            newWorkExperience.AppUserId = existingProstack.AppUserId;

            // Save WorkExperience
            await _unitOFWork.WorkExperienceRepository.CreateWorkExperienceAsync(newWorkExperience);
            await _unitOFWork.CompleteAsync();

            var createdWorkExperience = _mapper.Map<CreateWorkExperienceDto>(newWorkExperience);

            //  Cache
            _memoryCache.Set($"WorkExperience_{newWorkExperience.Id}", createWorkExperienceDto, TimeSpan.FromMinutes(10));
            _memoryCache.Remove(AllWorkExperienceCacheKey);

            return new ServiceResponse<CreateWorkExperienceDto>(createdWorkExperience, true, "Work experience uploaded successfully to profile and cache");
        }


        public async Task<ServiceResponse<bool>> DeleteWorkExperienceAsync(Guid id)
        {

            try
            {
                var result = await _unitOFWork.WorkExperienceRepository.DeleteExperienceAsync(id);
                if (!result)
                {
                    return new ServiceResponse<bool>(false, false, "No work experience for this Profile yet");

                }
                await _unitOFWork.CompleteAsync();
                _memoryCache.Remove($"Work_Experience_{id}");
                _memoryCache.Remove(AllWorkExperienceCacheKey);
                return new ServiceResponse<bool>(true, true, "Work experience deleted and cache cleared ");

            }
            catch (Exception ex)
            {

                return new ServiceResponse<bool>(false, false, $"Error deleting professional stack: {ex.Message}");

            }
        }

        public async Task<ServiceResponse<WorkExperienceDto>> UpdateWorkExperienceAsync(Guid id, UpdateWorkExperienceDto updateWorkExperienceDto)
        {
            var existingWorkExperience = await _unitOFWork.WorkExperienceRepository.GetWorkExperienceByIdAsync(id);
            if (existingWorkExperience == null)
            {
                return new ServiceResponse<WorkExperienceDto>(null!, false, "Work experience not found");
            }

            _mapper.Map(updateWorkExperienceDto, existingWorkExperience);
            await _unitOFWork.WorkExperienceRepository.UpdateWorkExperienceAsync(existingWorkExperience);
            await _unitOFWork.CompleteAsync();

            var updateExperience = _mapper.Map<WorkExperienceDto>(existingWorkExperience);

            // remove the cache

            _memoryCache.Remove($"Work_Experience_{id}");
            _memoryCache.Remove(AllWorkExperienceCacheKey);

            return new ServiceResponse<WorkExperienceDto>(updateExperience, true, "Professional Stacked Updated and cache invalided");

        }
    }
}
