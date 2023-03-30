using Category.Application.RepositoryContracts;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Infrastructure.Consumers
{
    public class AttributeCreatedConsumer : IConsumeAsync<CreateAttribute>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBus _bus;

        public AttributeCreatedConsumer(ICategoryRepository categoryRepository, IBus bus)
        {
            _categoryRepository = categoryRepository;
            _bus = bus;
        }

        public async Task ConsumeAsync(CreateAttribute message, CancellationToken cancellationToken)
        {
            Console.Write("Attribute olusturuldu");
        }
    }
}
