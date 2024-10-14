using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class PontoTuristico
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    [MaxLength(100)]
    public string Descricao { get; set; }

    [Required]
    [MaxLength(200)]
    public string Localizacao { get; set; }

    [Required]
    [MaxLength(100)]
    public string Cidade { get; set; }

    [Required]
    [MaxLength(2)]
    public string Estado { get; set; }
}
