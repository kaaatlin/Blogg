﻿using System.ComponentModel.DataAnnotations;
using BLog.BLL.ViewModels.Tags;

namespace BLog.BLL.ViewModels.Posts
{
    /// <summary>
    /// Модель создания поста
    /// </summary>
    public class PostCreateViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? AuthorId { get; set; }
        public List<TagViewModel>? Tags { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Заголовок", Prompt = "Заголовок")]
        public string? Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Содержание", Prompt = "Содержание")]
        public string? Content { get; set; }
    }
}
