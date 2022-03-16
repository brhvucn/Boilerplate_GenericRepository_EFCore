using Centisoft.DataAccess.Contract;
using Centisoft.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.DataAccess.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context) { }
        public async Task<List<Customer>> GetAllWithContacts()
        {
            return await this.context.Customers.Include(x => x.Contacts).ToListAsync();
        }

        /// <summary>
        /// Gets all customers with contacts. Contacts are "child/nested" objects within the customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Customer> GetCustomerWithContacts(int id)
        {
            return this.context.Customers.Include(x=>x.Contacts).FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
