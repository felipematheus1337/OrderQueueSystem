using OrderQueueSystem.Dtos;

namespace OrderQueueSystem.Services;

public interface IPedidoService
{
    Task<PedidoResponseDto> BuscarPorId(int id);

    Task CriarPedido(PedidoRequestDto dto);

}
