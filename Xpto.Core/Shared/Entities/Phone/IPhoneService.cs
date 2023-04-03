using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Phone;

namespace Xpto.Core.Shared.Entities.Phone
{
    public interface IPhoneService
    {
        IList<Phone> Create(IList<Phone> phones);
        Phone Update(Phone phone);
        int Delete(int code);
        Phone Get(int code);
        IList<Phone> List();




    }
}
