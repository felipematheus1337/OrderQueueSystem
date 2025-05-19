using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderQueueSystem.Domain;

[Table("tb_pedidos")]
public class Pedido
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Email { get; set; }

    public DateTime Data { get; set; }

    public bool Processado { get; set; } = false;


}
