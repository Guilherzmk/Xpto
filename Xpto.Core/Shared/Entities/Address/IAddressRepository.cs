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
        IList<Address> Insert(Address address);
        IList<Address> InsertMany(IList<Address> addresses);
        void Update(Address address);
        int Delete(int code);
        IList<Address> DeleteMany(IList<Address> addresses);
        Address Get(int code);
        IList<Address> Find();
        IList<Address> Find(int customerCode);
        DataTable LoadDataTable();

    }
}
