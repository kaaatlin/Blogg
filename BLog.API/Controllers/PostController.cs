using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLog.BLL.Services.IServices;
using BLog.BLL.ViewModels.Posts;

namespace BLog.API.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// Получение всех постов
        /// </summary>
        //[Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route("GetPosts")]
        public async Task<IEnumerable<ShowPostViewModel>> GetPosts()
        {
            var posts = await _postService.GetPosts();
            var postsResponse = posts.Select(p => new ShowPostViewModel { Id = p.Id, AuthorId = p.AuthorId, Title = p.Title, Content = p.Content, Tags = p.Tags.Select(_ => _.Name) }).ToList();

            return postsResponse;
        }

        /// <summary>
        /// Добавление поста
        /// </summary>
        [HttpPost]
        [Route("AddPost")]
        public async Task<IActionResult> AddPost(PostCreateViewModel model)
        {
            await _postService.CreatePost(model);

            return StatusCode(201);
        }

        /// <summary>
        /// Редактирование поста
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpPatch]
        [Route("EditPost")]
        public async Task<IActionResult> EditPost(PostEditViewModel model)
        {
            await _postService.EditPost(model, model.Id);

            return StatusCode(201);
        }

        /// <summary>
        /// Удаление поста
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [HttpDelete]
        [Route("RemovePost")]
        public async Task<IActionResult> RemovePost(Guid id)
        {
            await _postService.RemovePost(id);

            return StatusCode(201);
        }
    }
}
