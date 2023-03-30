using Attribute.Application.AttributeContracts;
using Attribute.Infrastructure.Consumers;
using Attribute.Infrastructure.Context;
using Attribute.Infrastructure.Repositories;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Attribute.Infrastructure
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AppConnectionString")));
            services.AddTransient<IAttributeRepository, AttributeRepository>();

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

            services.AddScoped<CategoryCreatedConsumer>();
            return services;
        }
    }
}
