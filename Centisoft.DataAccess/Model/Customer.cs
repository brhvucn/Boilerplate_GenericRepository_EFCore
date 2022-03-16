using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.DataAccess.Model
{
    public class Customer : BaseModel
    {
        public Customer()
        {
            this.Contacts = new List<Contact>();
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }    
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
