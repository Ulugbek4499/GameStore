﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Common;

namespace GameStore.Domain.Entities
{
    public class CartItem:BaseAuditableEntity
    {
        public int Count { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}