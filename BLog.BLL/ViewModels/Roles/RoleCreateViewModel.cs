using System.ComponentModel.DataAnnotations;

namespace BLog.BLL.ViewModels.Roles
{
    /// <summary>
    /// Модель создания роли
    /// </summary>
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Название")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Описание роли", Prompt = "Описание")]
        public string? Description { get; set; }
    }
}
