using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Core.Shared.Entities.Address
{
    public interface IAddressRepository
    {
        Address Insert(int customerCode, Address address);
        void Update(int customerCode, Address address);
        int Delete(Guid id);
        int DeleteByCustomer(int customerCode);
        Address Get(Guid id);
        IList<Address> Find(int customerCode);
        DataTable LoadDataTable();

    }
}
