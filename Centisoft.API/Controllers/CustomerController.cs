using Centisoft.BusinessLogic.Contract;
using Centisoft.DataAccess.Model;
using Centisoft.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Centisoft.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerFacade customerFacade;
        private DataContext dataContext;
        public CustomerController(ICustomerFacade customerFacade, DataContext dataContext)
        {
            this.customerFacade = customerFacade;
            this.dataContext = dataContext;
        }
        // GET: api/<CustomerController>
        /// <summary>
        /// Will get all the customers. If the parameter ?includecontacts=1 is added to the url then
        /// the nested contacts will be added to the response
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            bool includeContacts = Request.Query["includecontacts"].Count>0;
            if (includeContacts)
            {
                return await this.customerFacade.GetAllCustomersWithContacts();
            }
            return await this.customerFacade.GetAllCustomers();
        }

        [HttpGet("{id}/contacts")]
        public async Task<List<Contact>> GetCustomerWithContacts(int id)
        {
            Customer customer = await this.customerFacade.GetCustomerWithContacts(id);
            return customer.Contacts; //only return the contacts
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<Customer> Get(int id)
        {
            bool includeContacts = Request.Query["includecontacts"].Count > 0;
            if (includeContacts)
            {
                return await this.customerFacade.GetCustomerWithContacts(id);
            }
            return await this.customerFacade.GetCustomer(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            customerFacade.CreateCustomer(customer);
            this.dataContext.SaveChanges(); //commit all changes
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            customer.Id = id; //setting the id from the parameter list. This is the "proper" way to do REST (having the id in the url)
            customerFacade.UpdateCustomer(customer);
            this.dataContext.SaveChanges(); //commit all changes
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerFacade.DeleteCustomer(id);
            this.dataContext.SaveChanges(); //commit all changes
        }

    }
}
