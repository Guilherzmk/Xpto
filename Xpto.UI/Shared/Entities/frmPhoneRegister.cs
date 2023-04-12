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
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;
using Xpto.Core.Shared.Types;
using Xpto.UI.Customers;

namespace Xpto.UI.Shared.Entities
{
    public partial class frmPhoneRegister : Form
    {
        public Phone _phone { get; set; }
        public ActionType Action = ActionType.None;
        private Guid _id;

        public Phone Phone => _phone;

        public frmPhoneRegister()
        {
            InitializeComponent();
        }

        private void frmPhoneRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Action = ActionType.Create;

                this._phone = new Phone()
                {
                    Type = txtType.Text,
                    Ddd = Convert.ToInt32(txtDdd.Text),
                    Number = Convert.ToInt64(txtNumber.Text),
                    Note = txtNote.Text
                };

                if (this._id != Guid.Empty)
                    this._phone.Id = this._id;

                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _phone = new Phone();

            Action = ActionType.Delete;

            if (_phone.Id == Guid.Empty)
            {
                var msgText = "Não é possível apagar o telefone pois ele não existe";
                MessageBox.Show(msgText, "Telefone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var msgText = MessageBox.Show("Excluir Telefone?", "Telefone", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgText != DialogResult.Yes) { return; }

                this._phone.Id = this._id;

                this.Close();
                MessageBox.Show("Telefone excluído com sucesso!", "Telefone", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadPhone(Phone phone)
        {
            this._id = phone.Id;
            this.txtType.Text = phone.Type;
            this.txtDdd.Text = phone.Ddd.ToString();
            this.txtNumber.Text = phone.Number.ToString();
            this.txtNote.Text = phone.Note;
        }
    }
}
