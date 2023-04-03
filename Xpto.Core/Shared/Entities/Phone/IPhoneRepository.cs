using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Core.Shared.Entities.Phone
{
    public interface IPhoneRepository
    {
        Phone Insert(Phone phone);
        IList<Phone> InsertMany(IList<Phone> phones);
        void Update(Phone phone);
        int Delete(int code);
        IList<Phone> DeleteMany(IList<Phone> phones);
        Phone Get(int code);
        IList<Phone> Find();
        IList<Phone> Find(int customerCode);




    }
}
