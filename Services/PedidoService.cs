
using AutoMapper;
using OrderQueueSystem.Context;
using OrderQueueSystem.Domain;
using OrderQueueSystem.Dtos;
using OrderQueueSystem.Exceptions;
using OrderQueueSystem.Repositories;
using OrderQueueSystem.Utils;

namespace OrderQueueSystem.Services;

public class PedidoService : IPedidoService
{

    private readonly IPedidoRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<PedidoService> _logger;

    public PedidoService(IPedidoRepository repository, IMapper mapper, ILogger<PedidoService> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PedidoResponseDto> BuscarPorId(int id)
    {
        _logger.LogInformation($"Buscando pedido com Id: {id}");
        var pedido =  await _repository.GetByIdAsync(id);
        if (pedido is null) throw new PedidoNaoEncontradoException(BusinessUtils.PEDIDO_EXCEPTION_MESSAGE);
        return _mapper.Map<PedidoResponseDto>(pedido);
    }

    public async Task CriarPedido(PedidoRequestDto dto)
    {
            var pedido = _mapper.Map<Pedido>(dto);
            _logger.LogInformation($"Criando Pedido: {dto.ToString()}");
            await _repository.AddAsync(pedido);
            await _repository.SaveChangesAsync();
    }

}
