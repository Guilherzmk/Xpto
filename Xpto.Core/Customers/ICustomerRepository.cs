﻿using System.Data;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;

namespace Xpto.Core.Customers;

public interface ICustomerRepository
{
    Customer Insert(Customer customer);
    Customer Update(Customer customer);
    void Delete(Guid id);
    void SoftDelete(Guid id);
    Customer Get(Guid id);
    Customer Get(int code);
    IList<Customer> Find();
    DataTable LoadDataTable();
    DataTable LoadDataTableDisabled();
    long Count();
    Customer FilterName(string name);
}