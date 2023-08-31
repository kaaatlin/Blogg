using AutoMapper;
using BLog.BLL.ViewModels.Comments;
using BLog.BLL.ViewModels.Posts;
using BLog.BLL.ViewModels.Tags;
using BLog.BLL.ViewModels.Users;
using BLog.DAL.Models;

namespace BLog.API.Contracts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterViewModel, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(x => x.UserName, opt => opt.MapFrom(c => c.UserName));

            CreateMap<CommentCreateViewModel, Comment>();
            CreateMap<CommentEditViewModel, Comment>();
            CreateMap<PostCreateViewModel, Post>();
            CreateMap<PostEditViewModel, Post>();
            CreateMap<TagCreateViewModel, Tag>();
            CreateMap<TagEditViewModel, Tag>();
            CreateMap<UserEditViewModel, User>();
        }
    }
}
