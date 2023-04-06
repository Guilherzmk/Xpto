using System.Net.NetworkInformation;
using System.Xml.Linq;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;
using Xpto.Repositories.Shared.Entities;
using Xpto.Services.Entitites;

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

            var addresses = new List<Address>
            {
                new Address
                {
                    Type = "Casa",
                    Street = "Rua Xpto",
                    Number = "10",
                    District = "Xpto",
                    City = "Xpto City",
                    State = "Sp",
                    ZipCode = "06397280",
                    Note = "XptoOo"
                },
                new Address
                {
                    Type = "Casa",
                    Street = "Rua Xpto",
                    Number = "10",
                    District = "Xpto",
                    City = "Xpto City",
                    State = "Sp",
                    ZipCode = "06397280",
                    Note = "XptoOo"
                }
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

            customerParams.Addresses = addresses;
            customerParams.Emails = emails;
            customerParams.Phones = phones;
            var result = customerService.Create(customerParams);
        }

        [TestMethod]
        public void Update()
        {
            var customer = new Customer();
            var customerParams = new CustomerUpdateParams
            {
                Name = "Xpto USC",
                Nickname = "x",
                BirthDate = new DateTime(2006, 02, 21),
                PersonType = "PF",
                Identity = "223456789",
                Note = "Xpto",

                Addresses = new List<Address>
            {
                new Address
                {
                    Type = "Casa",
                    Street = "Rua XptoX",
                    Number = "10",
                    District = "XptoX",
                    City = "Xpto City",
                    State = "Sp",
                    ZipCode = "06397280",
                    Note = "XptoOo"
                },
                new Address
                {
                    Type = "Casa",
                    Street = "Rua XptoX",
                    Number = "10",
                    District = "XptoX",
                    City = "Xpto City",
                    State = "Sp",
                    ZipCode = "06397280",
                    Note = "XptoOo"
                }
            },

                Emails = new List<Email>
            {
                new Email
                {
                    Type = "Pessoal",
                    Address = "guilhermx@gmail.com",
                    Note = "Email XPTO"

                }
            },

                Phones = new List<Phone>
            {
                new Phone
                {
                    Type = "Pessoal",
                    Ddd = 12,
                    Number = 946103656,
                    Note = "PHONE XPTO"

                }
            }
            };

            //var result = customerService.Update(customerParams);
        }

        [TestMethod]
        public void Get()
        {
            var customer = new Customer();
            var result = customerService.Get(66);

            customer.Name = result.Name;
        }

        [TestMethod]

        public void GetAddress()
        {
            

            var codeGuid = Guid.Parse("6D2A321F-3D07-437E-95D7-AC422825E9E7");
            var result = customerService.GetAddress(codeGuid);
        }


        [TestMethod]
        public void List()
        {
            var list = customerService.List();
        }

        [TestMethod]
        public void Delete()
        {
            var delete = customerService.Delete(customerCode);
        }

       

        


    }
}