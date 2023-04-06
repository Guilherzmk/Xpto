using System.Data;
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

        public int Delete(int code)
        {
            var customer = _repository.Get(code);

            if (customer != null)
            {
                _repository.Delete(customer.Code);
            }

            return code;

        }

        public Customer Get(int code)
        {
            var customer = _repository.Get(code);
            return customer;
        }

        public Address GetAddress(Guid id)
        {
            var address = _repository.GetAddress(id);
            return address;
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

    }
}
