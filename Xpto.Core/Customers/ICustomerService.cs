using System.Data;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;
using Xpto.Core.Shared.Results;

namespace Xpto.Services.Customers;

public interface ICustomerService : IResultService
{
    Customer Create(CustomerCreateParams createParams);
    Customer Update(Guid id, CustomerUpdateParams updateParams);
    int Delete(int code);
    Customer Get(int code);
    IList<Customer> List();
    DataTable LoadDataTable();
}