﻿using System.Windows.Forms;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Types;

namespace Xpto.UI.Shared.Entities
{
    public partial class frmAddressRegister : Form
    {
        private Address _address;
        private Guid _id;
        public ActionType Action = ActionType.None;

        public Address Address => _address;

        public frmAddressRegister()
        {
            InitializeComponent();
        }

        private void frmAddressRegister_Load(object sender, EventArgs e)
        {

        }

        public void btnRegister_Click_1(object sender, EventArgs e)
        {
            this.Action = ActionType.Create;

            this._address = new Address()
            {
                Type = txtType.Text,
                Street = txtStreet.Text,
                Number = txtNumber.Text,
                Complement = txtComplement.Text,
                District = txtDistrict.Text,
                City = txtCity.Text,
                State = cboState.Text,
                ZipCode = txtZipCode.Text,
                Note = txtNote.Text,
            };

            if (this._id != Guid.Empty)
                this._address.Id = this._id;

            this.Close();
        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
            this.Action = ActionType.Delete;

            this._address = new Address();


            if (this._address.Id == Guid.Empty)
            {
                var msgText = "Não é possível apagar o endereço pois ele não existe";
                MessageBox.Show(msgText, "Endereço", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var msgText = MessageBox.Show("Excluir Endereço?", "Endereço", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgText != DialogResult.Yes) { return; }

                this._address.Id = this._id;

                this.Close();
                MessageBox.Show("Endereço excluído com sucesso!", "Endereço", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadAddress(Address address)
        {
            this._id = address.Id;
            this.txtType.Text = address.Type;
            this.txtStreet.Text = address.Street;
            this.txtNumber.Text = address.Number;
            this.txtComplement.Text = address.Complement;
            this.txtDistrict.Text = address.District;
            this.txtCity.Text = address.City;
            this.cboState.Text = address.State;
            this.txtZipCode.Text = address.ZipCode;
            this.txtNote.Text = address.Note;
        }
    }
}
