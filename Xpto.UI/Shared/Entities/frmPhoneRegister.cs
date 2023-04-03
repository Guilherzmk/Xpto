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
using Xpto.Core.Shared.Entities.Phone;
using Xpto.UI.Customers;

namespace Xpto.UI.Shared.Entities
{
    public partial class frmPhoneRegister : Form
    {
        public Phone Phone { get; set; }
        public IList<Phone> Phones { get; set; }
        public bool Confirm { get; set; }

        public frmPhoneRegister()
        {
            InitializeComponent();
        }

        private void frmPhoneRegister_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Phone = new Phone()
            {
                Type = txtType.Text,
                Ddd = Convert.ToInt32(txtDdd.Text),
                Number = Convert.ToInt32(txtNumber.Text),
                Note = txtNote.Text,
            };
            this.Confirm = true;
            this.Phones.Add(this.Phone);
            var frm = Program.ServiceProvider.GetRequiredService<frmCustomerRegister>();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
