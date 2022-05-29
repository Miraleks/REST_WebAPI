using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _customerRepository;

        
        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [HttpGet("{id:long}")]   
        public Task<Customer> GetCustomerAsync([FromRoute] long id)
        {
            
            Customer customer = _customerRepository?.GetById(id);
            if (customer != null)
            {
                return Task.FromResult(customer);
            }
            else
            {
                return Task.FromResult<Customer>(null);
            }
            
        }

        [HttpPost("")]   
        public Task<long> CreateCustomerAsync([FromQuery] string firstname, string lastname)
        
        {          
            var id = _customerRepository.AddCustomer(firstname, lastname);
            
            return Task.FromResult(id);
        }

    }
}