using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Core.Shared.Entities.Phone
{
    public interface IPhoneRepository
    {
        Phone Insert(int customerCode, Phone phone);
        void Update(int customerCode, Phone phone);
        int Delete(int code);
        int DeleteByCustomer(int customerCode);
        Phone Get(int code);
        IList<Phone> Find();
        IList<Phone> Find(int customerCode);




    }
}
