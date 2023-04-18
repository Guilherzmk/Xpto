using Refit;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Types;
using Xpto.UI.Delegates;
using Xpto.UI.Functions.ViaCep;

namespace Xpto.UI.Shared.Entities
{
    public partial class frmAddressRegister : Form
    {
        public AddressParams _address = new AddressParams();
        public event AddressConfirmDelegate Confirmed;
        public Guid _id;
        public ActionType Action = ActionType.None;

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
            _address = new AddressParams();

            _address.Type = this.txtType.Text;
            _address.Street = this.txtStreet.Text;
            _address.Number = this.txtNumber.Text;
            _address.Complement = this.txtComplement.Text;
            _address.District = this.txtDistrict.Text;
            _address.City = this.txtCity.Text;
            _address.State = this.cboState.Text;
            _address.ZipCode = this.mskCep.Text;
            _address.Note = this.txtNote.Text;

            if (this._id != Guid.Empty)
                this._address.Id = this._id;

            if (this.Confirmed is not null)
                this.Confirmed(_address);

            this.Close();
        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
            this.Action = ActionType.Delete;
            this._address = new AddressParams();

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
            var zipCode = this.mskCep.Text.Replace("-", "");
            zipCode = address.ZipCode;
            this.txtNote.Text = address.Note;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mskCep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetAddressAsync(mskCep.Text);
            }
        }

        async Task GetAddressAsync(string zipCode)
        {
            try
            {
                var findZipCode = RestService.For<ICepApiService>("https://viacep.com.br");
                var address = await findZipCode.GetAddressAsync(zipCode);

                txtStreet.Text = address.Logradouro;
                txtDistrict.Text = address.Bairro;
                txtComplement.Text = address.Complemento;
                txtCity.Text = address.Localidade;
                cboState.Text = address.Uf;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
