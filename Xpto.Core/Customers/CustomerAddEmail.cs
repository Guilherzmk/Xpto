using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Params;
using Xpto.Core.Shared.Results;

namespace Xpto.Core.Customers
{
    public static class CustomerAddEmail
    { 
        public static Customer AddEmail(this Customer _customer, EmailParams emailParams, IResultService resultService)
        {
            if (emailParams == null)
            {
                resultService.Messages.Add("Email inválido");
                return _customer;
            }

            _customer.Emails ??= new List<Email>();
            _customer.Emails.Add(new Email(emailParams));

            return _customer;
        }




    }
}
