using System.Data;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;

namespace Xpto.Core.Customers;

public interface ICustomerRepository
{
    Customer Insert(Customer customer);

    Customer Update(Customer customer);

    int Delete(int code);

    Customer Get(Guid id);

    Customer Get(int code);

    IList<Customer> Find();

    DataTable LoadDataTable();

    long Count();

    Customer FilterName(string name);
}