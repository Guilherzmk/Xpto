using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;

namespace Xpto.Services.Entitites
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _repository;
        public EmailService(IEmailRepository repository)
        {
            _repository = repository;
        }

        public IList<Email> Create(IList<Email> emails)
        {
            _repository.InsertMany(emails);
            return emails;
        }
        public Email Update(Email email) 
        {
        _repository.Update(email);
            return email;
        }
        public int Delete(int code)
        {
            var email = _repository.Get(code);   

            if(email != null)
            {
                _repository.Delete(email.Code);
            }

            return code;

        }
        public Email Get(int code)
        {
            var email = _repository.Get(code);
            return email;
        }
        public IList<Email> List()
        {
            var list = _repository.Find();
            return list;
        }
        public IList<Email> List(int customerCode)
        {
            var list = _repository.Find(customerCode);
            return list;
        }
















    }
}
