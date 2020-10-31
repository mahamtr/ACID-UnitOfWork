using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Entities;

namespace backend.Core.Entities
{
    public class TransactionLog
    {
        public virtual Guid Id { get; set; }
        public virtual string TransactionType { get; set; }
        public virtual Guid? SourceAccountId { get; set; }
        public virtual Guid? DestinationAccountId { get; set; }
        public virtual Guid UserId  { get; set; }
        public virtual User User  { get; set; }
        public virtual DateTime Date{ get; set; }
        public virtual decimal Amount{ get; set; }
    }
}
