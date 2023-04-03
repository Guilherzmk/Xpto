using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Customers;

namespace Xpto.Core.Shared.Entities.Email
{
    public interface IEmailService
    {
        IList<Email> Create(IList<Email> emails);
        Email Update(Email email);
        int Delete(int code);
        Email Get(int code);
        IList<Email> List();



    }
}
