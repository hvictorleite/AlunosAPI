using System.ComponentModel.DataAnnotations;

namespace AlunosAPI.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "Senhas não coincidem")]
        public string ConfirmPassword { get; set; }
    }
}
