using System.Data;
using System.Text;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;
using Xpto.Services.Customers;
using Xpto.UI.Shared.Entities;
using Xpto.Core.Shared.Types;
using Xpto.UI.Delegates;
using Xpto.Core.Shared.Results;
using Xpto.Core.Shared.Params;

namespace Xpto.UI.Customers
{
    public partial class frmCustomerRegister : Form
    {

        private readonly ICustomerService _customerService;

        public event CustomerChangeDelegate Change;
        public event CustomerMensageDelegate Sucess;

        private Customer Customer = new();

        public bool Confirm { get; set; }

        public frmCustomerRegister(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }

        private void CustomerRegister_Load(object sender, EventArgs e)
        {

        }

        public void LoadCustomer(Customer customer)
        {
            this.Customer = customer;
            this.txtName.Text = customer.Name;
            this.txtNickname.Text = customer.Nickname;
            this.mskIdentity.Text = customer.Identity;
            this.txtNote.Text = customer.Note;
            this.dtpBirthDate.Text = customer.BirthDate?.ToString("dd/MM/yyyy");
            this.cboPersonType.Text = customer.PersonType;
            this.lblCode.Text = $"Código: {customer.Code}";
            LoadAddresses();
            LoadEmails();
            LoadPhones();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void Save()
        {
            if (this.Customer.Code == 0)
                this.Create();
            else
                this.Update();

            this.Close();
        }

        private void Create()
        {
            try
            {
                var msg = MessageBox.Show("Cadastrar Cliente?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg != DialogResult.Yes)
                {
                    return;
                }

                var customerParams = new CustomerCreateParams(this.txtName.Text)
                {
                    Nickname = this.txtNickname.Text,
                    BirthDate = this.dtpBirthDate.Value,
                    PersonType = this.cboPersonType.Text,
                    Identity = this.mskIdentity.Text,
                    Note = this.txtNote.Text,
                    Addresses = new List<AddressParams>(),
                    Phones = new List<PhoneParams>(),
                    Emails = new List<EmailParams>()
                };

                Customer.Addresses ??= new List<Address>();
                foreach (var item in Customer.Addresses)
                {
                    customerParams.Addresses.Add(item.ToParams());
                }

                Customer.Phones ??= new List<Phone>();
                foreach (var item in Customer.Phones)
                {
                    customerParams.Phones.Add(item.ToParams());
                }

                Customer.Emails ??= new List<Email>();
                foreach (var item in Customer.Emails)
                {
                    customerParams.Emails.Add(item.ToParams());
                }

                var result = this._customerService.Create(customerParams);
                this.Change.Invoke(Customer);
                if (this._customerService.Messages.Count > 0)
                {
                    var sb = new StringBuilder();
                    foreach (var message in this._customerService.Messages)
                    {
                        sb.AppendLine(message);
                    }

                    MessageBox.Show(sb.ToString(), "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Customer = result;
                   
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update()
        {
            try
            {
                var msg = MessageBox.Show("Atualizar Cliente?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg != DialogResult.Yes)
                {
                    return;
                }

                var customerParams = new CustomerUpdateParams()
                {
                    Name = this.txtName.Text,
                    Nickname = this.txtNickname.Text,
                    Identity = this.mskIdentity.Text,
                    Note = this.txtNote.Text,
                    BirthDate = this.dtpBirthDate.Value,
                    PersonType = this.cboPersonType.Text,
                    Addresses = new List<AddressParams>(),
                    Phones = new List<PhoneParams>(),
                    Emails = new List<EmailParams>()
                };

                Customer.Addresses ??= new List<Address>();
                foreach (var item in Customer.Addresses)
                {
                    customerParams.Addresses.Add(item.ToParams());
                }

                Customer.Phones ??= new List<Phone>();
                foreach (var item in Customer.Phones)
                {
                    customerParams.Phones.Add(item.ToParams());
                }

                Customer.Emails ??= new List<Email>();
                foreach (var item in Customer.Emails)
                {
                    customerParams.Emails.Add(item.ToParams());
                }

                Customer = this._customerService.Update(Customer.Id, customerParams);

                this.Change.Invoke(Customer);
                var msgText = "Cliente atualizado com sucesso!";

                if (this.Sucess != null)
                    this.Sucess(msgText);

                MessageBox.Show(msgText, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddAddress(AddressParams addressParams)
        {
            var resultService = new ResultService();
            this.Customer.AddAddress(addressParams, resultService);
            if (resultService.Messages.Count > 0)
                MessageBox.Show(resultService.Messages[0]);

            this.LoadAddresses();
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            var frm = new frmAddressRegister();
            frm.Confirmed += AddAddress;
            frm.ShowDialog();

        }

        public void LoadAddresses()
        {
            this.Customer.Addresses ??= new List<Address>();
            lvwAddress.View = View.Details;
            lvwAddress.Columns.Clear();
            lvwAddress.Items.Clear();

            lvwAddress.Columns.Add("Tipo");
            lvwAddress.Columns.Add("Rua");
            lvwAddress.Columns.Add("Número");
            lvwAddress.Columns.Add("Complemento");
            lvwAddress.Columns.Add("Bairro");
            lvwAddress.Columns.Add("Cidade");
            lvwAddress.Columns.Add("Estado");
            lvwAddress.Columns.Add("CEP");
            lvwAddress.Columns.Add("Anotações");

            foreach (var address in this.Customer.Addresses)
            {
                var item = new ListViewItem(address.Type);
                lvwAddress.Items.Add(item);

                item.SubItems.Add(address.Street);
                item.SubItems.Add(address.Number);
                item.SubItems.Add(address.Complement);
                item.SubItems.Add(address.District);
                item.SubItems.Add(address.City);
                item.SubItems.Add(address.State);
                item.SubItems.Add(address.ZipCode);
                item.SubItems.Add(address.Note);

                item.Tag = address.Id;
            }
        }

        private void lvwAddress_DoubleClick(object sender, EventArgs e)
        {
            var id = Guid.Parse(lvwAddress.SelectedItems[0].Tag.ToString());

            Address address = null;
            foreach (var item in Customer.Addresses)
            {
                if (item.Id == id)
                {
                    address = item;
                    break;
                }
            }

            if (address == null)
                return;

            var frm = new frmAddressRegister();
            frm.LoadAddress(address);
            frm.ShowDialog(this);

            if (frm.Action == ActionType.Create)
            {
                if (frm._address != null)
                {
                    for (int i = 0; i <= Customer.Addresses.Count - 1; i++)
                    {
                        var item = Customer.Addresses[i];

                        if (item.Id == id)
                        {
                            Customer.Addresses[i] = (new Address(frm._address));
                            break;
                        }
                    }
                }
            }
            else if (frm.Action == ActionType.Delete)
            {
                if (frm._address != null)
                {
                    for (int i = 0; i <= Customer.Addresses.Count - 1; i++)
                    {
                        var item = Customer.Addresses[i];

                        if (item.Id == id)
                        {
                            Customer.Addresses.Remove(item);
                            break;
                        }
                    }
                }
            }
            LoadAddresses();
        }

        private void AddPhone(PhoneParams phoneParams)
        {
            var resultService = new ResultService();
            this.Customer.AddPhone(phoneParams, resultService);
            if (resultService.Messages.Count > 0)
                MessageBox.Show(resultService.Messages[0]);

            this.LoadPhones();
        }

        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            var frm = new frmPhoneRegister();
            frm.Confirmed += AddPhone;
            frm.ShowDialog();
        }

        public void LoadPhones()
        {
            this.Customer.Phones ??= new List<Phone>();
            lvwPhone.View = View.Details;
            lvwPhone.Columns.Clear();
            lvwPhone.Items.Clear();

            lvwPhone.Columns.Add("Tipo");
            lvwPhone.Columns.Add("DDD");
            lvwPhone.Columns.Add("Número");
            lvwPhone.Columns.Add("Anotações");

            foreach (var phone in this.Customer.Phones)
            {
                var item = new ListViewItem(phone.Type);
                lvwPhone.Items.Add(item);

                item.SubItems.Add(phone.Ddd.ToString());
                item.SubItems.Add(phone.Number.ToString());
                item.SubItems.Add(phone.Note);

                item.Tag = phone.Id;
            }
        }

        private void lvwPhone_DoubleClick(object sender, EventArgs e)
        {
            var id = Guid.Parse(lvwPhone.SelectedItems[0].Tag.ToString());

            Phone phone = null;
            foreach (var item in Customer.Phones)
            {
                if (item.Id == id)
                {
                    phone = item;
                    break;
                }
            }

            if (phone == null)
                return;

            var frm = new frmPhoneRegister();
            frm.LoadPhone(phone);
            frm.ShowDialog(this);

            if (frm.Action == ActionType.Create)
            {
                for (int i = 0; i <= Customer.Phones.Count - 1; i++)
                {
                    var item = Customer.Phones[i];

                    if (item.Id == id)
                    {
                        Customer.Phones[i] = (new Phone(frm._phone));
                        break;
                    }
                }
            }
            else if (frm.Action == ActionType.Delete)
            {
                for (int i = 0; i <= Customer.Phones.Count - 1; i++)
                {
                    var item = Customer.Phones[i];

                    if (item.Id == id)
                    {
                        Customer.Phones.Remove(item);
                        break;
                    }
                }
            }
            LoadPhones();
        }

        private void AddEmail(EmailParams emailParams)
        {
            var resultService = new ResultService();
            this.Customer.AddEmail(emailParams, resultService);
            if (resultService.Messages.Count > 0)
                MessageBox.Show(resultService.Messages[0]);

            this.LoadEmails();

        }

        private void btnAddEmail_Click(object sender, EventArgs e)
        {
            var frm = new frmEmailRegister();
            frm.Confirmed += AddEmail;
            frm.ShowDialog(this);


        }

        public void LoadEmails()
        {
            this.Customer.Emails ??= new List<Email>();
            lvwEmail.View = View.Details;
            lvwEmail.Columns.Clear();
            lvwEmail.Items.Clear();

            lvwEmail.Columns.Add("Tipo");
            lvwEmail.Columns.Add("Endereço de Email");
            lvwEmail.Columns.Add("Anotação");

            foreach (var email in this.Customer.Emails)
            {
                var item = new ListViewItem(email.Type);
                lvwEmail.Items.Add(item);

                item.SubItems.Add(email.Address);
                item.SubItems.Add(email.Note);

                item.Tag = email.Id;

            }
        }

        private void lvwEmail_DoubleClick(object sender, EventArgs e)
        {
            var id = Guid.Parse(this.lvwEmail.SelectedItems[0].Tag.ToString());

            Email email = null;
            foreach (var item in Customer.Emails)
            {
                if (item.Id == id)
                {
                    email = item;
                    break;
                }
            }

            if (email == null)
                return;

            var frm = new frmEmailRegister();
            frm.LoadEmail(email);
            frm.ShowDialog(this);

            if (frm.Action == ActionType.Create)
            {
                for (int i = 0; i <= Customer.Emails.Count - 1; i++)
                {
                    var item = Customer.Emails[i];

                    if (item.Id == id)
                    {
                        Customer.Emails[i] = (new Email(frm._email));
                        break;
                    }
                }
            }
            else if (frm.Action == ActionType.Delete)
            {
                for (int i = 0; i <= Customer.Emails.Count - 1; i++)
                {
                    var item = Customer.Emails[i];

                    if (item.Id == id)
                    {
                        Customer.Emails.Remove(item);
                        break;
                    }
                }
            }
            LoadEmails();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Customer.Code == 0)
            {
                var msgText = "Não é possível apagar o cliente pois ele não existe";
                MessageBox.Show(msgText, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var msgText = MessageBox.Show("Excluir Cliente?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgText != DialogResult.Yes) { return; }

                this._customerService.Delete(Customer.Id);
                this.Change.Invoke(Customer);

                this.Close();
                MessageBox.Show("Cliente excluído com sucesso!", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboPersonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPersonType.Text == "PF")
            {
                mskIdentity.Mask = "000.000.000-00";
            }
            else if (cboPersonType.Text == "PJ")
            {
                mskIdentity.Mask = "00.000.000/0001-00";
            }
        }
    }
}