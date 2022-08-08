using AutoMapper;
using TwitterWebAPI.Models;
using TwitterWebAPI.ViewModels;

namespace TwitterWebAPI
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Reply, ReplyViewModel>();
            CreateMap<Tweet, TweetViewModel>();
        }
    }
}
