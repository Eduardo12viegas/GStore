using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GStore.Models;

[Table("produto_foto")]
public class ProdutoFoto
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Produto")]
    [Required(ErrorMessage = "Por favor, informe o Produto")]
    public int ProdutoId { get; set; }
    [ForeignKey("ProdutoId")]
    public Produto Produto { get; set; }

    [Display(Name = "Foto")]
    [StringLength(200)]
    [Required(ErrorMessage = "Por favor, informe o arquivo")]
    public string ArquivoFoto { get; set; }

    [Display(Name = "Descrição")]
    [StringLength(100, ErrorMessage = "A Descrição deve possuir no máximo 100 caracteres")]
    public string Descricao { get; set; }
}
