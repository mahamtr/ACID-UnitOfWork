﻿using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Core.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public decimal Balance { get; set; }
    }
}