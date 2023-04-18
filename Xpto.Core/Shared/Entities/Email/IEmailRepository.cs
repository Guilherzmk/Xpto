using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Core.Shared.Entities.Email
{
    public interface IEmailRepository
    {
        Email Insert(int customerCode, Email address);
        void Update(int customerCode, Email address);
        int Delete(int cpde);
        int DeleteByCustomer(int customerCode);
        Email Get(int code);
        IList<Email> Find();
        IList<Email> Find(int customerCode);
    }
}
