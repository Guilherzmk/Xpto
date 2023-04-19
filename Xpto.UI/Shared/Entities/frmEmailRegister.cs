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
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Params;
using Xpto.Core.Shared.Types;
using Xpto.UI.Customers;
using Xpto.UI.Delegates;

namespace Xpto.UI.Shared.Entities
{
    public partial class frmEmailRegister : Form
    {
        public EmailParams _email;
        public event EmailConfirmDelegate Confirmed;
        private Guid _id;
        public ActionType Action = ActionType.None;

        public frmEmailRegister()
        {
            InitializeComponent();
        }

        private void frmEmailRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Action = ActionType.Create;
            this._email = new EmailParams();

            _email.Type = cboType.Text;
            _email.Address = txtAddress.Text;
            _email.Note = txtNote.Text;

            if (this._id != Guid.Empty)
                this._email.Id = this._id;

            if (this.Confirmed is not null)
                this.Confirmed(_email);

            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Action = ActionType.Delete;

            _email = new EmailParams();

            if (_email.Id == Guid.Empty)
            {
                var msgText = "Não é possível apagar o email pois ele não existe";
                MessageBox.Show(msgText, "Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var msgText = MessageBox.Show("Excluir Email?", "Email", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgText != DialogResult.Yes) { return; }

                this._email.Id = this._id;

                this.Close();
                MessageBox.Show("Email excluído com sucesso!", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadEmail(Email email)
        {
            this._id = email.Id;
            this.cboType.Text = email.Type;
            this.txtAddress.Text = email.Address;
            this.txtNote.Text = email.Note;

        }
    }
}
