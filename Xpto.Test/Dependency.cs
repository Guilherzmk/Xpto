using Microsoft.Extensions.DependencyInjection;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;
using Xpto.Repositories.Customers;
using Xpto.Repositories.Shared.Entities;
using Xpto.Repositories.Shared.Sql;
using Xpto.Services.Customers;

namespace Xpto.Test
{
    [TestClass]
    public class Dependency
    {
        public ICustomerService customerService;

        public ICustomerRepository customerRepository;
        public IAddressRepository addressRepository;
        public IEmailRepository emailRepository;
        public IPhoneRepository phoneRepository;

        [TestInitialize]
        public void Init()
        {
           var services = new ServiceCollection();
            services.AddTransient<SqlConnectionProvider>(_ => new SqlConnectionProvider("server=DESKTOP-UJHJIPK\\SQLEXPRESS;database=db_xpto;user=sa;password=123456"));
            //Data Source=.;Initial Catalog=db_xpto;Persist Security Info=True;User ID=sa; Password=123456

            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<ICustomerService, CustomerService>();

            services.AddTransient<IAddressRepository, AddressRepository>();

            services.AddTransient<IEmailRepository, EmailRepository>();

            services.AddTransient<IPhoneRepository, PhoneRepository>();
      
            var provider = services.BuildServiceProvider();
 
            customerService = provider.GetService<ICustomerService>();
            customerRepository = provider.GetService<ICustomerRepository>();
            addressRepository = provider.GetService<IAddressRepository>();
            emailRepository = provider.GetService<IEmailRepository>();
            phoneRepository = provider.GetService<IPhoneRepository>();
        }
    }
}
