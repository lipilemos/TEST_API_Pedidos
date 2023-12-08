using API_Pedidos.Domain.Core.Results;
using API_Pedidos.Domain.PedidosContext.Entities;
using System.Threading.Tasks;

namespace API_Pedidos.Domain.PedidosContext.Services
{
    public interface IPedidosService
    {
        Task<SimpleResult> CreateAsync(Pedido pedido);
        Task<Result<IList<Pedido>>> GetAllAsync();
        Task<Result<Pedido>> GetPedidoByIdAsync(int id);
        Task<Result<Pedido>> UpdateAsync(Pedido id);
        Task<SimpleResult> RemoveAsync(int id);        

    }
}
