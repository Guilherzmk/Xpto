using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;
using Xpto.Core.Shared.Params;
using Xpto.Core.Shared.Results;

namespace Xpto.Core.Customers
{
    public static class CustomerAddPhone
    {
        public static Customer AddPhone(this Customer _customer, PhoneParams phoneParams, IResultService resultService)
        {
            if (phoneParams == null)
            {
                resultService.Messages.Add("Telefone inválido");
                return _customer;
            }

            _customer.Phones ??= new List<Phone>();
            _customer.Phones.Add(new Phone(phoneParams));

            return _customer;
        }


    }
}
