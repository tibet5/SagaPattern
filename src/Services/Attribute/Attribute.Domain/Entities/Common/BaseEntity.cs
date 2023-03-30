using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute.Domain.Entities.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int? State { get; set; }
        public int ProcessedBy { get; set; }

        public void Activate()
        {
            State = 1;
        }

        public void Passivated()
        {
            State = 0;
        }

        public void Delete()
        {
            State = -1;
        }
    }
}
