﻿using System.ComponentModel.DataAnnotations;

namespace BLog.BLL.ViewModels.Users
{
    /// <summary>
    /// Модель регистрации пользователя
    /// </summary>
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя", Prompt = "Введите имя")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия", Prompt = "Введите фамилию")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Никнейм", Prompt = "Введите никнейм")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [EmailAddress]
        [Display(Name = "Email", Prompt = "example@mail.com")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль", Prompt = "Введите пароль")]
        [StringLength(50, ErrorMessage = "Поле {0} должно иметь минимум {2} символов", MinimumLength = 5)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль", Prompt = "Введите пароль")]
        public string? PasswordReg { get; set; }
    }
}
