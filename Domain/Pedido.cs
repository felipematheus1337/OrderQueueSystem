using System.ComponentModel.DataAnnotations.Schema;

namespace OrderQueueSystem.Domain;

[Table("tb_pedidos")]
public class Pedido
{
    public int Id;
}
