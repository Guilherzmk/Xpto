﻿using System.Data;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;
using Xpto.Core.Shared.Results;

namespace Xpto.Services.Customers
{
    public class CustomerService : ResultService, ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            this.Messages = new List<string>();
            _repository = repository;
        }

        public Customer Create(CustomerCreateParams createParams)
        {
            var customer = Customer.Create(createParams, this);

            if (this.Messages.Count > 0)
                return null;

            _repository.Insert(customer);
            return customer;
        }

        public Customer Update(Guid id, CustomerUpdateParams updateParams)
        {
            var customer = this._repository.Get(id);
            if (customer == null)
                return null;

            customer.Update(updateParams, this);

            _repository.Update(customer);
            return customer;
        }

        public void Delete(Guid id)
        {
            var customer = _repository.Get(id);

            if (customer != null)
            {
                _repository.Delete(customer.Id);
            }
        }

        public void SoftDelete(Guid id)
        {
            var customer = _repository.Get(id);

            if(customer != null)
            {
                _repository.SoftDelete(customer.Id);
            }

        }

        public Customer Get(Guid id)
        {
            var customer = _repository.Get(id);
            return customer;
        }

        public IList<Customer> List()
        {
           
            var list = _repository.Find();

            return list;
        }

        public Customer FilterName(string name)
        {
            var customer = _repository.FilterName(name);
            return customer;
        }

        public DataTable LoadDataTable()
        {
            var dt = _repository.LoadDataTable();
            return dt;
        }

        public DataTable LoadDataTableDisabled()
        {
            var dt = _repository.LoadDataTableDisabled();
            return dt;
        }


    }
}
