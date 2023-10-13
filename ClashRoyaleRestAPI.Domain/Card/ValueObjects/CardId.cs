﻿using ClashRoyaleRestAPI.Domain.Common.Base;
using ClashRoyaleRestAPI.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Card.ValueObjects
{
    public sealed class CardId : BaseIdValueObject
    {
        public CardId(Guid value) : base(value)
        {
        }
    }
}
