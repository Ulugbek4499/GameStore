using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Common;

namespace GameStore.Domain.Entities
{
    public class Cart:BaseAuditableEntity
    {
        public virtual ICollection<CartItem>? Items { get; set; }
        public virtual Order? Order { get; set; }
    }
}
