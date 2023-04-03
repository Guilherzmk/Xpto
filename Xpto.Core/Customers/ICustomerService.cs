using System.Data;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;
namespace Xpto.Services.Customers;

public interface ICustomerService
{
    Customer Create(Customer customer);
    Customer Update(Customer customer);
    int Delete(int code);
    Customer Get(int code);
    IList<Customer> List();
    Customer FilterName(string name);
    DataTable LoadDataTable();
}