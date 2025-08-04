using AutoMapper;
using Portfolio.APP.DTOs;
using Portfolio.APP.DTOs.AppUser;
using Portfolio.APP.DTOs.ProfileDtos;
using Portfolio.APP.DTOs.Recruiter;
using Portfolio.Core.Entities;

namespace Portfolio.APP.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProfileDto, ProfileEntity>().ReverseMap();
            CreateMap<ProfileDto, ProfileEntity>().ReverseMap();
            CreateMap<ProfileUpdateDto, ProfileEntity>()
      .ForMember(dest => dest.Id, opt => opt.Ignore())
      .ForMember(dest => dest.AppUserId, opt => opt.Ignore());

            // 
           // Recruiter
           CreateMap<RecruiterProfile, RecruiterProfileDto>().ReverseMap();
           CreateMap<RecruiterProfile, CreateRecruiterProfileDto>().ReverseMap();
           CreateMap<RecruiterProfile, UpdateRecruiterProfileDto>().ReverseMap();
           CreateMap<RecruiterProfile, RecruiterDto>().ReverseMap();


            CreateMap<ProfileEntity, FullProfileDto>().ReverseMap();
            CreateMap<ProfileEntity, UserProfileDto>().ReverseMap();
            CreateMap<AppUser, AppUserDto>();
            CreateMap<ProfessionalStack, ProfessionalStackDto>().ReverseMap();
            CreateMap<ProfessionalStack,DisplayProfessionalStackDto>().ReverseMap();
            CreateMap<ProfessionalStack, CreateProfessionalStackDto>().ReverseMap();
            CreateMap<ProfessionalStack, UpdateProfessionalStackDto>().ReverseMap();


            CreateMap<WorkExperience, WorkExperienceDto>().ReverseMap();
            CreateMap<WorkExperience, DisplayWorkExperienceDto>().ReverseMap();
            CreateMap<WorkExperience, CreateWorkExperienceDto>().ReverseMap();
            CreateMap<WorkExperience, UpdateWorkExperienceDto>().ReverseMap();
            

            CreateMap<MediaUpload, MediaUploadDto>();
            CreateMap<Post, PostDto>();
            CreateMap<Comment, CommentDto>();

        }
    }
}
