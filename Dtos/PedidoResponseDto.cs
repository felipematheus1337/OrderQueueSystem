using System.ComponentModel.DataAnnotations;

namespace OrderQueueSystem.Dtos;

public class PedidoResponseDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public DateTime Data { get; set; }
}
