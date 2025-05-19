using OrderQueueSystem.Context;
using OrderQueueSystem.Domain;

namespace OrderQueueSystem.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
