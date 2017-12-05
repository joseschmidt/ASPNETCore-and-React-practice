using System;
using System.Collections.Generic;
using System.Text;

namespace ASPNETCore_React.Domain.Models
{
    public class User
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
