using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
        private Email _email;
        private readonly IEmailService _emailService;
        private Guid _id;

        public Email Email => _email;



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
            this._email = new Email()
            {
                Type = txtType.Text,
                Address = txtAddress.Text,
                Note = txtNote.Text,
            };
            if (this._id != Guid.Empty)
                this._email.Id = this._id;
            this.Close();
        }

        public void LoadEmail(Email email)
        {
            this._id = email.Id;
            this.txtType.Text = email.Type;
            this.txtAddress.Text = email.Address;
            this.txtNote.Text = email.Note;

        }

        private void frmEmailRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
