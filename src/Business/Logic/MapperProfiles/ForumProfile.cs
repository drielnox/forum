using AutoMapper;
using drielnox.Forum.Business.Logic.DTOs.Responses;

namespace drielnox.Forum.Business.Logic.MapperProfiles
{
    internal sealed class ForumProfile : Profile
    {
        public ForumProfile()
        {
            CreateMap<Entities.Forum, ViewForumResponse>()
                .ForMember(dest => dest.ForumId, opt => opt.MapFrom(src => src.Identifier))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Administrator, opt => opt.MapFrom(src => src.Administrator))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}
