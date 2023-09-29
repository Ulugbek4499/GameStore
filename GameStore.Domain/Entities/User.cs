using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace GameStore.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
    }
}
