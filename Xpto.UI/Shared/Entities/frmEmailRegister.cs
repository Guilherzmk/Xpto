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
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.UI.Customers;

namespace Xpto.UI.Shared.Entities
{
    public partial class frmEmailRegister : Form
    {
        public Email Email { get; set; }
        public IList<Email> Emails { get; set; }
        public bool Confirm { get; set; }

        public frmEmailRegister()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Email = new Email()
            {
                Type = txtType.Text,
                Address = txtAddress.Text,
                Note = txtNote.Text,
            };
            this.Confirm = true;
            this.Emails.Add(this.Email);
            var frm = Program.ServiceProvider.GetRequiredService<frmCustomerRegister>();
            this.Close();
        }

        private void frmEmailRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
