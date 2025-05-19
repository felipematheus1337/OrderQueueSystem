using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderQueueSystem.Domain;

[Table("tb_pedidos")]
public class Pedido
{
    public int Id { get; set; }

    [Required]
    public string Email { get; set; }

    public DateTime Data { get; set; }




}
