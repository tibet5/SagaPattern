using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute.Application.AttributeContracts
{
    public interface IAttributeRepository
    {
        Task<bool> GetAttributeById(int id);
        Task<bool> ChangeState(int id);
    }
}
