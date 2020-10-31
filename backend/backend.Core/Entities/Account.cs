using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Entities;

namespace backend.Core.Entities
{
    public class Account
    {
        public virtual Guid Id { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual ICollection<User> Users { get; set; }


    }
}
