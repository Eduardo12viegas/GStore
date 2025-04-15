using System.ComponentModel.DataAnnotations;
using Mysqlx;
namespace GStore.ViewModels

 public class LoginVM
{
   [Display(Name = "Email ou Nome de Usúario", Prompt = "Informe seu Email ou Nome de Úsuario")]
    [Required(ErrorMessage = "Por favor, informe seu email ou nome de usuário")]

    public string Email {get; set; }

    [Display(Name = "Senha de Acesso", Prompt = "*******")]
    [Required(ErrorMessage = "Por favor, informe sua senha")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }
        
    
}