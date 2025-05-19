using AutoMapper;
using OrderQueueSystem.Domain;
using OrderQueueSystem.Dtos;

namespace OrderQueueSystem.Mapper;

public class DtoMappingProfile : Profile
{

    public DtoMappingProfile()
    {
        CreateMap<Pedido, PedidoRequestDto>().ReverseMap();
        CreateMap<Pedido, PedidoResponseDto>().ReverseMap();   
    }

}
