using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Features.Account.ViewModels
{
  public class RegisterViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirmar senha")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    [DataType(DataType.Text)]
    [Display(Name = "RA")]
    [Required(ErrorMessage = "O Numero do RA é obrigatório.")]
    public string AcademicRecord { get; set; }

    [DataType(DataType.Text)]
    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Name { get; set; }
  }
}
