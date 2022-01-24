using System;
using System.ComponentModel.DataAnnotations;

namespace WebsiteMangaAnime.Models.IdentityControl
{
    public class RegisterModel
    {
        [Required,
        MinLength(3),
        Display(Name = "Никнейм")]
        public string UserName { get; set; }
        [Required,
        DataType(DataType.EmailAddress),
        Display(Name = "Электронная почта")]
        public string Email { get; set; }
        [Required,
        DataType(DataType.Date),
        Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }
        [Required,
        DataType(DataType.Password),
        MinLength(5)]
        public string Password { get; set; }
        [Required,
        DataType(DataType.Password),
        MinLength(5),
        Compare("Password", ErrorMessage = "Пароли не совпадают"),
        Display(Name = "Повторить пароль")]
        public string PasswordConfirm { get; set; }
    }
    public class LoginModel
    {
        [Required,
        DataType(DataType.EmailAddress),
        Display(Name = "Электронная почта")]
        public string Email { get; set; }
        [Required,
        DataType(DataType.Password),
        MinLength(5),
        Display(Name = "Пароль")]
        public string Password { get; set; }
    }
    public class ForgotPasswordModel
    {
        [Required,
        DataType(DataType.EmailAddress),
        Display(Name = "Электронная почта")]
        public string Email { get; set; }
    }
    public class ResetPasswordModel
    {
        [Required]
        public string Id { get; set; }
        [Required,
        MinLength(5),
        DataType(DataType.Password),
        Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required,
        MinLength(5),
        DataType(DataType.Password),
        Compare("Password", ErrorMessage = "Пароли должны совпадать"),
        Display(Name = "Повторить пароль")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Token { get; set; }
    }
}