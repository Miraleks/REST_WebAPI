using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi
{
    public class CustomerRepository
    {
        private readonly List<Customer> _list;

        public CustomerRepository()
        {
            _list = new List<Customer>();
        }

        public Customer GetById(long id)
        {
            return _list?.Find(x => x.Id == id);
        }

        internal long AddCustomer(string firstname, string lastname)
        {
            var id = _list.Count() == 0 ? 1 : _list.Max(p => p.Id) + 1;
            _list.Add(new Customer{Id = id, Firstname = firstname, Lastname = lastname});
            return id;
        }

    }
}