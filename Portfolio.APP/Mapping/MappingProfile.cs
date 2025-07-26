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
            CreateMap<ProfileDto, ProfileEntity>().ReverseMap();
            CreateMap<ProfileUpdateDto, ProfileEntity>()
      .ForMember(dest => dest.Id, opt => opt.Ignore())
      .ForMember(dest => dest.AppUserId, opt => opt.Ignore());
        }
    }
}
