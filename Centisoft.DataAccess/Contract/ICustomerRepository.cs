using Centisoft.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.DataAccess.Contract
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        //here goes interface declarations for customer specific repository actions
        //this is actions that is not already covered in the derived interface
        //e.g. GetCustomersWithNoPurchases()
        Task<List<Customer>> GetAllWithContacts();
        Task<Customer> GetCustomerWithContacts(int id);
    }
}
