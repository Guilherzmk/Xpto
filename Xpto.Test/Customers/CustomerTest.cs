using System.Net.NetworkInformation;
using System.Xml.Linq;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;
using Xpto.Repositories.Shared.Entities;

namespace Xpto.Test.Customers
{
    [TestClass]
    public class CustomerTest : Dependency
    {
        private readonly ICustomerRepository _customer;
        private readonly IAddressRepository _addressRepository;
        private readonly IEmailRepository _emailRepository;
        public string name = "Gui";
        public int customerCode = 68;


        [TestMethod]
        public void Create()
        {
            var customer = new Customer();
            var customerParams = new CustomerCreateParams(customer.Name = "Guilherme")
            {
                Nickname = "Gui",
                BirthDate = new DateTime(2006, 02, 21),
                PersonType = "PF",
                Identity = "123456789",
                Note = "Xpto"
            };

           

            var emails = new List<Email>
            {
                new Email
                {
                    Type = "Pessoal",
                    Address = "guilherme@gmail.com",
                    Note = "Email XPTO"

                }
            };

            var phones = new List<Phone>
            {
                new Phone
                {
                    Type = "Pessoal",
                    Ddd = 11,
                    Number = 956103656,
                    Note = "PHONE XPTO"

                }
            };

            

            
            var result = customerService.Create(customerParams);
        }

        [TestMethod]
        public void Update()
        {
            var customer = new Customer();
           

               

            

            //var result = customerService.Update(customerParams);
        }

        [TestMethod]
        public void Get()
        {
            var customer = new Customer();



        }

 
        [TestMethod]
        public void List()
        {
            var list = customerService.List();
        }

        [TestMethod]
        public void Delete()
        {
            
        }

       

        


    }
}