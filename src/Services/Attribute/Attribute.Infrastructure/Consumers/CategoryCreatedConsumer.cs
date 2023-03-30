using Attribute.Application.AttributeContracts;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute.Infrastructure.Consumers
{
    public class CategoryCreatedConsumer : IConsumeAsync<CategoryCreated>
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IBus _bus;

        public CategoryCreatedConsumer(IAttributeRepository attributeRepository, IBus bus)
        {
            _attributeRepository = attributeRepository;
            _bus = bus;
        }

        public async Task ConsumeAsync(CategoryCreated message, CancellationToken cancellationToken)
        {
            Console.Write("Categori olusturuldu");
            await _attributeRepository.ChangeState(message.CategoryId);
        }

    }
}
