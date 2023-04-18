using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;
using Xpto.Core.Shared.Params;
using Xpto.Core.Shared.Results;

namespace Xpto.Core.Customers
{
    public partial class Customer
    {
        public static Customer Create(CustomerCreateParams createParams, IResultService resultService)
        {
            resultService.ClearMessages();

            if(createParams == null)
            {
                resultService.Messages.Add("Parâmetro Inválido");
                return null;
            }

            var customer = new Customer();

            customer.Name = createParams.Name;
            customer.Nickname = createParams.Nickname;
            customer.BirthDate = createParams.BirthDate;
            customer.PersonType = createParams.PersonType;
            customer.Identity = createParams.Identity;

            customer.Addresses = new List<Address>();
            createParams.Addresses ??= new List<AddressParams>();
            foreach (var item in createParams.Addresses)
            {
                customer.Addresses.Add(new Address(item));
            }

            createParams.Phones ??= new List<PhoneParams>();
            foreach (var item in createParams.Phones)
            {
                customer.Phones.Add(new Phone(item));
            }

            createParams.Emails ??= new List<EmailParams>();
            foreach (var item in createParams.Emails)
            {
                customer.Emails.Add(new Email(item));
            }

            customer.Note = createParams.Note;

            if (!customer.Validate(resultService))
            {
                return null;
            }

            return customer;
        }


    }
}
