using Microsoft.Extensions.DependencyInjection;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.UI.Customers;

namespace Xpto.UI.Shared.Entities
{
    public partial class frmAddressRegister : Form
    {
        public bool Confirm { get; set; }
        public Customer Customer = new Customer();
        public Address Address { get; set; }
        public IList<Address> Addresses { get; set; }
        public frmAddressRegister()
        {
            InitializeComponent();
        }

        private void frmAddressRegister_Load(object sender, EventArgs e)
        {
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnRegister_Click_1(object sender, EventArgs e)
        {
            this.Address = new Address()
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

            this.Confirm = true;
            this.Addresses.Add(this.Address);
            var frm = Program.ServiceProvider.GetRequiredService<frmCustomerRegister>();
            this.Close();
        }
    }
}
