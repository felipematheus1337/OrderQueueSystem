using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderQueueSystem.Dtos;
using OrderQueueSystem.Services;

namespace OrderQueueSystem.Controllers;

[Route("[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{

    private readonly PedidoService _service;

    public PedidoController (PedidoService pedidoService)
    {
        _service = pedidoService;
    }

    [HttpGet("{id:int:min(1)", Name = "ObterPedido")]
    public async Task<ActionResult<PedidoResponseDto>> buscar(int id)
    {
        var pedido = await _service.BuscarPorId(id);

        if (pedido is null) return NotFound();

        return Ok(pedido);

    }

    [HttpPost]
    public async Task<ActionResult> CriarPedido([FromBody] PedidoRequestDto dto)
    {
        if (dto is null) return BadRequest();

        await _service.CriarPedido(dto);

        return Created();

    }
    

    

}
