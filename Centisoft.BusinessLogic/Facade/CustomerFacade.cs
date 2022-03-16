using Centisoft.BusinessLogic.Contract;
using Centisoft.DataAccess.Contract;
using Centisoft.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.BusinessLogic.Facade
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly ICustomerRepository customerRepository;
        /// <summary>
        /// The constructor takes the repository that should be used. This is Dependency Injection        
        /// </summary>
        /// <param name="customerRepository"></param>
        public CustomerFacade(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            //just forward the call
           return await this.customerRepository.AddAsync(customer);
        }

        public void DeleteCustomer(int id)
        {
            //just forward the call
            //consider make some business logic here to determine if we are allowed to delete this customer
            this.customerRepository.DeleteAsync(id);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            //just forward the call
            return await this.customerRepository.GetAllAsync();
        }

        public async Task<List<Customer>> GetAllCustomersWithContacts()
        {
            //just forward the call
            //note that this is in the specific customer repository and not a part of the generic repository
            return await this.customerRepository.GetAllWithContacts();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            //just forward the call
            return await this.customerRepository.GetByIdAsync(id);
        }

        public async Task<Customer> GetCustomerWithContacts(int id)
        {
            //just forward the call
            //note that this is in the specific customer repository and not a part of the generic repository
            return await this.customerRepository.GetCustomerWithContacts(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            //just forward the call
            customerRepository.UpdateAsync(customer);
        }
    }
}
