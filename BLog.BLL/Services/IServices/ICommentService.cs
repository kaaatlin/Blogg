﻿using BLog.DAL.Models;
using BLog.BLL.ViewModels.Comments;

namespace BLog.BLL.Services.IServices
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CommentCreateViewModel model, Guid userId);

        Task RemoveComment(Guid id);

        Task<List<Comment>> GetComments();

        Task<CommentEditViewModel> EditComment(Guid id);

        Task EditComment(CommentEditViewModel model, Guid id);
    }
}
