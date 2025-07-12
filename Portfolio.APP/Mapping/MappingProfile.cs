using AutoMapper;
using Portfolio.APP.DTOs.ProfileDtos;
using Portfolio.Core.Entities;

namespace Portfolio.APP.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProfileDto, ProfileEntity>().ReverseMap();
          //  CreateMap<ProfileEntity, CreateProfileDto>();
           // CreateMap<UpdateProfileDto, Profile>().ReverseMap();
        }
    }
}
