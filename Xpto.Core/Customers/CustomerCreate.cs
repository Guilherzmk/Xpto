using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            customer.Addresses = createParams.Addresses;
            customer.Phones = createParams.Phones;
            customer.Emails = createParams.Emails;
            customer.Note = createParams.Note;

            if (!customer.Validate(resultService))
            {
                return null;
            }

            return customer;
        }


    }
}
