using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class Users
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid Id_Account  { get; set; }
    }
}
