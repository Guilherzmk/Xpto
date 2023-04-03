using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;

namespace Xpto.Services.Entitites
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;
        public AddressService(IAddressRepository repository)
        {
            _repository = repository;
        }

        public IList<Address> Create(IList<Address> addresses)
        {
            _repository.InsertMany(addresses);
            
            return addresses;
        }

        public Address Update(Address address) 
        {
        _repository.Update(address);
            return address;
        }

        public int Delete(int code)
        {
            var address = _repository.Get(code);

            if (address != null)
            {
                _repository.Delete(address.CustomerCode);
            }

            return code;

        }

        public Address Get(int code)
        {
            var address = _repository.Get(code);
            return address;
        }

    public IList<Address> List()
        {
            var list = _repository.Find();
            return list;
        }

        public IList<Address> List(int customerCode)
        {
            var list = _repository.Find(customerCode);
            return list;
        }
















    }
}
