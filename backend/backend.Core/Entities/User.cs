using System;
using System.Collections.Generic;
using System.Text;
using backend.Core.Common;
using backend.Core.Entities;

namespace CleanArchitecture.Core.Entities
{
    public class User
    {
        public virtual Guid Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public  virtual Guid AccountId  { get; set; }
        public virtual Account Account  { get; set; }
        
        public virtual ICollection<TransactionLog> TransacionLogs { get; set; }

        public bool AuthenticateUser(string loginPassWord)
        {
            return string.Equals(Password, PasswordHasher.HashPassword(loginPassWord));
        }
    }
}
