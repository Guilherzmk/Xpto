using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xpto.Core.Customers;
using Xpto.Services.Customers;
using Xpto.UI.Customers;

namespace Xpto.UI
{
    public partial class CodeUpdate : Form
    {
        Customer Customer = new Customer();
        private readonly ICustomerService _customerService;
        public CodeUpdate(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }



        private void CodeUpdate_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            
            var code = Customer.Code = Convert.ToInt32(txtCode.Text);

            var customer = this._customerService.Get(code);
            if (customer == null)
            {
                return;
            }

            var frm = Program.ServiceProvider.GetRequiredService<frmCustomerRegister>();
            frm.LoadCustomer(customer);
            frm.Show();
        }
    }
}
