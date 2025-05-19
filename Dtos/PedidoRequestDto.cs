using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace OrderQueueSystem.Dtos;

public class PedidoRequestDto
{
    [EmailAddress]
    private string Email { get; set; }

    private DateTime Data { get; set; }
}
