using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Core.Shared.Entities.Email
{
    public interface IEmailRepository
    {
        Email Insert(Email address);
        IList<Email> InsertMany(IList<Email> emails);
        void Update(Email address);
        int Delete(int cpde);
        IList<Email> DeleteMany(IList<Email> emails);
        Email Get(int code);
        IList<Email> Find();
        IList<Email> Find(int customerCode);
    }
}
