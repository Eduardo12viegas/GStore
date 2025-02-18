using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GStore.Models;

    public class Usuario : IdentityUser
    {
        [Required(ErrorMessage ="Por favor inofrme o Nome")]
        [StringLength(60, ErrorMessage = "O nome deve possuir no maximo 60 caracteres")]
        public string Nome {get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento {get; set; }

        [StringLength(200)]
        public string Foto {get; set; }
    }
