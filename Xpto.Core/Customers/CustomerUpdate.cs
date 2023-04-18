using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;
using Xpto.Core.Shared.Params;
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
            customer.Addresses = new List<Address>();
            updateParams.Addresses ??= new List<AddressParams>();
            foreach (var item in updateParams.Addresses)
            {
                customer.Addresses.Add(new Address(item));
            }

            customer.Phones = new List<Phone>();
            updateParams.Phones ??= new List<PhoneParams>();
            foreach (var item in updateParams.Phones)
            {
                customer.Phones.Add(new Phone(item));
            }

            customer.Emails = new List<Email>();
            updateParams.Emails ??= new List<EmailParams>();
            foreach (var item in updateParams.Emails)
            {
                customer.Emails.Add(new Email(item));
            }

            customer.Note = updateParams.Note;

            if (!customer.Validate(resultService))
            {
                return null;
            }

            return customer;
        }

    }
}
