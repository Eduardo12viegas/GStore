using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GStore.Models;

[Table("produto_foto")]
public class ProdutoFoto
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "produto")]
    [Required(ErrorMessage = "por favor, informe o produto")]
    public int ProdutoID { get; set; }
    [ForeignKey("ProdutoId")]
    public Produto Produto { get; set; }

    [Display(Name = "Foto")]
    [StringLength(200)]
    [Required(ErrorMessage = "por favor, informe o arquivo")]

    public string ArquivoFoto { get; set; }
    [Display(Name = "Descrição")]
    [Required(ErrorMessage = "por favor, informe o arquivo")]
    [StringLength(100)]
    public string Descricao { get; set; }
}
