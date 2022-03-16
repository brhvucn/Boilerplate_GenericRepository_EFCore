using Centisoft.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.BusinessLogic.Contract
{
    /// <summary>
    /// This is a description for the customer facade. In a "pure" CRUD environment, this will basically have
    /// the same operations as the underlying repositories. In order to maintain a "3 layered architecture"
    /// this layer is "required"
    /// </summary>
    public interface ICustomerFacade
    {
        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetAllCustomersWithContacts();
        Task<Customer> GetCustomer(int id);
        Task<Customer> GetCustomerWithContacts(int id);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        Task<Customer> CreateCustomer(Customer customer);
    }
}
