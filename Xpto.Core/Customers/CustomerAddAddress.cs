using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Results;

namespace Xpto.Core.Customers
{
    public static class CustomerAddAddress
    {
        public static Customer AddAddress(this Customer _customer, AddressParams addressParams, IResultService resultService)
        {
            if (addressParams == null)
            {
                resultService.Messages.Add("Endereço inválido");
                return _customer;
            }

            _customer.Addresses ??= new List<Address>();
            _customer.Addresses.Add(new Address(addressParams));

            return _customer;
        }
        
                
        


        


    }
}
