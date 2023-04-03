using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Customers;

namespace Xpto.Core.Shared.Entities.Address
{
    public interface IAddressService
    {
        //IList<Address> Create(Address address);
        IList<Address> Create(IList<Address> addresses);
        Address Update(Address address);
        int Delete(int code);
        Address Get(int code);
        IList<Address> List();



    }
}
