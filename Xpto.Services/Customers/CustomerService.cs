using System.Data;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;

namespace Xpto.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }


        public Customer Create(Customer customer)
        {
            _repository.Insert(customer);
            return customer;
        }

        public Customer Update(Customer customer)
        {
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
