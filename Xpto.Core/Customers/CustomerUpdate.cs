using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Shared.Results;

namespace Xpto.Core.Customers
{
    public static class CustomerUpdate
    {
        public static Customer Update(this Customer customer, CustomerUpdateParams updateParams, IResultService resultService)
        {
            if (updateParams == null)
            {
                resultService.Messages.Add("Parâmetro inválido");
                return null;
            }

            customer.Name = updateParams.Name;
            customer.Nickname = updateParams.Nickname;
            customer.BirthDate = updateParams.BirthDate;
            customer.PersonType = updateParams.PersonType;
            customer.Identity = updateParams.Identity;
            customer.Addresses = updateParams.Addresses;
            customer.Phones = updateParams.Phones;
            customer.Emails = updateParams.Emails;
            customer.Note = updateParams.Note;

            if (!customer.Validate(resultService))
            {
                return null;
            }

            return customer;
        }

    }
}
