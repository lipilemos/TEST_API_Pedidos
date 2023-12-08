using API_Pedidos.Domain.PedidosContext.Entities;
using API_Pedidos.Models;
using AutoMapper;

namespace API_Pedidos.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Pedido, PedidoGetResultModel>();            
            CreateMap<PedidoPostRequestModel, Pedido>();
            CreateMap<ItensPedidoPostRequestModel, ItensPedido>();
            CreateMap<ProdutoPostRequestModel, Produto>();
            CreateMap<PedidoPutRequestModel, Pedido>();
            CreateMap<ItensPedidoPutRequestModel, ItensPedido>();
        }
    }
}
