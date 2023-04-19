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
using Xpto.Core.Shared.Params;
using Xpto.Core.Shared.Types;
using Xpto.UI.Customers;
using Xpto.UI.Delegates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Xpto.UI.Shared.Entities
{
    public partial class frmPhoneRegister : Form
    {
        public PhoneParams _phone { get; set; }
        public event PhoneConfirmDelegate Confirmed;
        public ActionType Action = ActionType.None;
        private Guid _id;


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
                this._phone = new PhoneParams();

                _phone.Type = cboType.Text;
                _phone.Ddd = Convert.ToInt32(mskNumber.Text.Substring(1, 2));
                _phone.Number = Convert.ToInt64(mskNumber.Text.Substring(4, 5) + mskNumber.Text.Substring(10, 4));
                _phone.Note = txtNote.Text;

                if (this._id != Guid.Empty)
                    this._phone.Id = this._id;

                if (this.Confirmed is not null)
                    this.Confirmed(_phone);

                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            Action = ActionType.Delete;

            _phone = new PhoneParams();

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
            this.cboType.Text = phone.Type;
            //var ddd = Convert.ToInt32(this.mskNumber.Text.Substring(1, 2));
            this.mskNumber.Text = phone.ToString();
            //var number = Convert.ToInt64(mskNumber.Text.Substring(4, 5) + mskNumber.Text.Substring(10, 4));
           
            this.txtNote.Text = phone.Note;
        }
    }
}
