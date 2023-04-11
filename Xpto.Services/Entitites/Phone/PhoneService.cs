using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;

namespace Xpto.Services.Entitites
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _repository;

        public PhoneService(IPhoneRepository repository)
        {
            _repository = repository;
        }

        public IList<Phone> Create(IList<Phone> phones)
        {
            _repository.InsertMany(phones);
            return phones;
        }

        public Phone Update(Phone phone)
        {
        _repository.Update(phone);
            return phone;
        }

        public int Delete(int code)
        {
            var phone = _repository.Get(code);   

            if(phone != null)
            {
                _repository.Delete(phone.Code);
            }

            return code;

        }

        public Phone Get(int code)
        {
            var phone = _repository.Get(code);
            return phone;
        }

        public IList<Phone> List()
        {
            var list = _repository.Find();
            return list;
        }

        public IList<Phone> List(int customerCode)
        {
            var list = _repository.Find(customerCode);
            return list;
        }
    }
}
