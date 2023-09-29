﻿using System;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}