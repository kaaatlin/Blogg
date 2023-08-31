using System.ComponentModel.DataAnnotations;

namespace BLog.BLL.ViewModels.Comments
{
    /// <summary>
    /// Модель создания комментария
    /// </summary>
    public class CommentCreateViewModel
    {
        /// <summary>
        /// Содержание комментария
        /// </summary>
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Содержание", Prompt = "Содержание")]
        public string? Content { get; set; }

        /// <summary>
        /// Автор комментария
        /// </summary>
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Автор", Prompt = "Автор")]
        public string? Author { get; set; }

        /// <summary>
        /// Id поста для которого создается комментарий
        /// </summary>
        public Guid PostId;
    }
}
