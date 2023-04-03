using System.Net.NetworkInformation;
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
        public int customerCode = 46;

        [TestMethod]
        public void Create()
        {

            var customer = new Customer
            {
                Name = "Guilherme",
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

            customer.Addresses = addresses;
            customer.Emails = emails;
            customer.Phones = phones;
            var result = customerService.Create(customer);
        }

        [TestMethod]
        public void Update()
        {
            
            var customer = new Customer
            {
                Code = customerCode,
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

            var result = customerService.Update(customer);
        }

        [TestMethod]
        public void Get()
        {
            var customer = new Customer();
            var result = customerService.Get(customerCode);

            customer.Name = result.Name;
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

        [TestMethod]

        public void FilterName()
        {
            var filter = customerService.FilterName(name);
        }


    }
}