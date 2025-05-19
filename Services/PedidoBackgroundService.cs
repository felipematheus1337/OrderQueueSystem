
using Microsoft.EntityFrameworkCore;
using OrderQueueSystem.Context;
using OrderQueueSystem.Domain;

namespace OrderQueueSystem.Services;

public class PedidoBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public PedidoBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<PedidoBackgroundService>>();
                var emailService = scope.ServiceProvider.GetRequiredService<EmailService>();

                var pedidos = await dbContext.Pedidos
                    .Where(p => !p.Processado)
                    .ToListAsync();

                var tasks = pedidos.Select(async pedido =>
                {
                    int PedidoId = pedido.Id;
                    try
                    {
                        logger.LogInformation($"Processando pedido com id: {PedidoId}");
                        pedido.Processado = true;
                        await emailService.SendEmail(pedido);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"Falha ao enviar o email do pedido com id: {PedidoId}");

                    }

                }).ToList();

                await Task.WhenAll(tasks);

                await dbContext.SaveChangesAsync();
                    
            }

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
       
    }
}
