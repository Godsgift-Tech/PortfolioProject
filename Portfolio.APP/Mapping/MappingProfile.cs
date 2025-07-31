using AutoMapper;
using Portfolio.APP.DTOs;
using Portfolio.APP.DTOs.AppUser;
using Portfolio.APP.DTOs.ProfileDtos;
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

            CreateMap<ProfileEntity, FullProfileDto>().ReverseMap();
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
