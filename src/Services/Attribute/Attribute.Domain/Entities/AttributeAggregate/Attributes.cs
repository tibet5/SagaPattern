using Attribute.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute.Domain.Entities.AttributeAggregate
{
    public class Attributes : BaseEntity
    {
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public bool IsVariantable { get; set; }
    }
}
