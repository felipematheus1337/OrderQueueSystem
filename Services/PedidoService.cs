
using AutoMapper;
using OrderQueueSystem.Context;
using OrderQueueSystem.Domain;
using OrderQueueSystem.Dtos;
using OrderQueueSystem.Repositories;

namespace OrderQueueSystem.Services;

public class PedidoService : IPedidoService
{

    private readonly IPedidoRepository _repository;
    private readonly IMapper _mapper;

    public PedidoService(IPedidoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PedidoResponseDto> BuscarPorId(int id)
    {
        var pedido =  await _repository.GetByIdAsync(id);
        return _mapper.Map<PedidoResponseDto>(pedido);
    }

    public async Task CriarPedido(PedidoRequestDto dto)
    {
            var pedido = _mapper.Map<Pedido>(dto);
            await _repository.AddAsync(pedido);
            await _repository.SaveChangesAsync();
    }
}
