using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;
using Xpto.Repositories.Customers;
using Xpto.Repositories.Shared.Entities;
using Xpto.Repositories.Shared.Sql;
using Xpto.Services.Customers;
using Xpto.UI.Customers;

namespace Xpto.UI
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            ApplicationConfiguration.Initialize();

            Application.Run(ServiceProvider.GetRequiredService<frmApp>());

        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {

                    services.AddTransient<frmApp>();
                    services.AddTransient<frmCustomerRegister>();
                    services.AddTransient<frmCustomerSearch>();

                    services.AddTransient<SqlConnectionProvider>(_ => new SqlConnectionProvider("server=DESKTOP-UJHJIPK\\SQLEXPRESS;database=db_xpto;user=sa;password=123456"));

                    services.AddTransient<ICustomerRepository, CustomerRepository>();
                    services.AddTransient<ICustomerService, CustomerService>();

                    services.AddTransient<IAddressRepository, AddressRepository>();

                    services.AddTransient<IPhoneRepository, PhoneRepository>();

                    services.AddTransient<IEmailRepository, EmailRepository>();
                });
        }





    }
}