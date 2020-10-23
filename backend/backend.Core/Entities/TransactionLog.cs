using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Core.Entities
{
    public class TransactionLog
    {
        public Guid Id { get; set; }
        public string TransactionType { get; set; }
        public int SourceAccount { get; set; }
        public int DestinationAccount { get; set; }
        public string UserName { get; set; }
        public DateTime Date{ get; set; }
        public decimal Amount{ get; set; }
    }
}
