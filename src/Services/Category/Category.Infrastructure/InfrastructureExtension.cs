using Category.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Category.Application.RepositoryContracts;
using Category.Infrastructure.Repositories;
using EasyNetQ.AutoSubscribe;
using EasyNetQ;
using System.Reflection;
using Category.Infrastructure.Consumers;

namespace Category.Infrastructure
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfratructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("AppConnectionString")));
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            var bus = RabbitHutch.CreateBus("host=localhost");
            services.AddSingleton<IBus>(bus);
            services.AddSingleton<MessageDispatcher>();
            services.AddSingleton<AutoSubscriber>(_ =>
            {
                return new AutoSubscriber(_.GetRequiredService<IBus>(), Assembly.GetExecutingAssembly().GetName().Name)
                {
                    AutoSubscriberMessageDispatcher = _.GetRequiredService<MessageDispatcher>()
                };
            });

            services.AddScoped<AttributeCreatedConsumer>();

            return services;
        }
    }
}
