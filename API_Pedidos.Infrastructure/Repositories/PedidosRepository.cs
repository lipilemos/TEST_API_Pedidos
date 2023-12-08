using API_Pedidos.Domain.Core.Results;
using API_Pedidos.Domain.PedidosContext.Entities;
using API_Pedidos.Domain.PedidosContext.Repositories;
using API_Pedidos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API_Pedidos.Infrastructure.Repositories
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly AppDbContext _dbContext;

        public PedidosRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;            
        }

        public async Task<SimpleResult> AddAsync(Pedido pedido)
        {            
            _dbContext.Pedidos.Add(pedido);
            await _dbContext.SaveChangesAsync();
            return await Task.FromResult(SimpleResult.Ok());
        }
        public async Task<Result<Pedido>> GetByIdAsync(int id)
        {       
            var pedido = await _dbContext.Pedidos
             .Include(p => p.ItensPedido)
                 .ThenInclude(ip => ip.Produto)
             .FirstOrDefaultAsync(p => p.Id == id);

            var result = Result<Pedido>.Ok(pedido);
            return await Task.FromResult(result);            
        }
        public async Task<Result<IList<Pedido>>> GetAllAsync()
        {
            var pedido = await _dbContext.Pedidos
             .Include(p => p.ItensPedido)
                 .ThenInclude(ip => ip.Produto).ToListAsync();

            var result = Result<IList<Pedido>>.Ok(pedido);
            return await Task.FromResult(result);
        }
        public async Task<Result<Pedido>> UpdateAsync(Pedido pedido)
        {
            _dbContext.Entry(pedido).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            var result = Result<Pedido>.Ok(pedido);
            return await Task.FromResult(result);
        }
        public async Task<SimpleResult> RemoveAsync(int id)
        {
            var pedido = await _dbContext.Set<Pedido>().FindAsync(id);

            if (pedido != null)
            {
                _dbContext.Set<Pedido>().Remove(pedido);
                await _dbContext.SaveChangesAsync();
            }
            
            return await Task.FromResult(SimpleResult.Ok());
        }        
    }
}
