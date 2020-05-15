using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackGroundService
{
    public class HelloWorldHostedService : BackgroundService
    {
        private readonly ILogger<HelloWorldHostedService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;


        public HelloWorldHostedService(ILogger<HelloWorldHostedService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

       

        public override Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Servis je počeo s radom u vrijeme : {time} ", DateTimeOffset.Now);
            return base.StartAsync(stoppingToken);
        }

        public override Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Servis prestaje s radom u : {time} ", DateTimeOffset.Now);
            return base.StopAsync(stoppingToken);
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                if (DoWork())
                {
                    _logger.LogInformation("Ima odgovora . ", DateTimeOffset.Now);
                }
                else
                {
                    _logger.LogInformation("No response. ", DateTimeOffset.Now);
                }
                await Task.Delay(10000, stoppingToken);

            }
        }
        public bool DoWork()
        {
                int count = 0;
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DbTestContext>();
                Korisnik k = new Korisnik();
                k.Ime = "Irma";
                k.Prezime = "Roz";
                k.Godine = 25;

                dbContext.Korisnici.Add(k);
                dbContext.SaveChanges();
                    count = 1;
            }
                if (count == 1) return true;
                else return false;
        }

    }

}
