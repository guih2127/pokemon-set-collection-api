using AutoMapper;
using pokemon_tcg_collection_api.Models;
using pokemon_tcg_collection_api.ViewModels;

namespace pokemon_tcg_collection_api.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, GetUserViewModel>().ReverseMap();
            CreateMap<InsertUserViewModel, UserEntity>()
                .ReverseMap()
                .ForMember(x => x.ConfirmPassword, opt => opt.Ignore());
        }
    }
}