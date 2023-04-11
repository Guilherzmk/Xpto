using System.Data;
using System.Text;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;
using Xpto.Services.Customers;
using Xpto.UI.Shared.Entities;
using Xpto.Core.Shared.Types;

namespace Xpto.UI.Customers
{
    public partial class frmCustomerRegister : Form
    {

        private readonly ICustomerService _customerService;

        private Customer Customer = new Customer();

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
            this.txtIdentity.Text = customer.Identity;
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
                    Identity = this.txtIdentity.Text,
                    Note = this.txtNote.Text,
                    Addresses = Customer.Addresses,
                    Phones = Customer.Phones,
                    Emails = Customer.Emails,
                };

                var result = this._customerService.Create(customerParams);
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
                    Identity = this.txtIdentity.Text,
                    Note = this.txtNote.Text,
                    BirthDate = this.dtpBirthDate.Value,
                    PersonType = this.cboPersonType.Text,
                    Addresses = Customer.Addresses,
                    Emails = Customer.Emails,
                    Phones = Customer.Phones,
                };

                Customer = this._customerService.Update(Customer.Id, customerParams);

                MessageBox.Show("Cliente atualizado com sucesso!", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            var frm = new frmAddressRegister();
            frm.ShowDialog(this);

            if (frm.Address != null)
                this.Customer.Addresses.Add(frm.Address);

            this.LoadAddresses();
        }

        public void LoadAddresses()
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Código");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Rua");
            dt.Columns.Add("Número");
            dt.Columns.Add("Complemento");
            dt.Columns.Add("Distrito");
            dt.Columns.Add("Cidade");
            dt.Columns.Add("Estado");
            dt.Columns.Add("CEP");
            dt.Columns.Add("Anotações");

            foreach (var item in this.Customer.Addresses)
            {
                var row = dt.Rows.Add(item.Id);
                row[1] = item.Code;
                row[2] = item.Type;
                row[3] = item.Street;
                row[4] = item.Number;
                row[5] = item.Complement;
                row[6] = item.District;
                row[7] = item.City;
                row[8] = item.State;
                row[9] = item.ZipCode;
                row[10] = item.Note;
            }

            this.dgvAddress.DataSource = dt;
            this.dgvAddress.Columns["Id"].Visible = false;
            this.dgvAddress.Columns["Código"].Visible = false;

        }

        private void dgvAddress_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var id = Guid.Parse(this.dgvAddress.SelectedRows[0].Cells[0].Value?.ToString());

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
                    if (frm.Address != null)
                        for (int i = 0; i <= Customer.Addresses.Count - 1; i++)
                        {
                            var item = Customer.Addresses[i];

                            if (item.Id == id)
                            {
                                Customer.Addresses[i] = frm.Address;
                                break;
                            }
                        }
                    LoadAddresses();
                }
                else if (frm.Action == ActionType.Delete)
                {
                    if (frm.Address != null)
                        for (int i = 0; i <= Customer.Addresses.Count - 1; i++)
                        {
                            var item = Customer.Addresses[i];

                            if (item.Id == id)
                            {
                                Customer.Addresses.Remove(item);
                                break;
                            }
                        }
                    LoadAddresses();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            var frm = new frmPhoneRegister();
            frm.ShowDialog(this);

            if (frm.Phone != null)
                this.Customer.Phones.Add(frm.Phone);

            this.LoadPhones();
        }

        public void LoadPhones()
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Código");
            dt.Columns.Add("Código do CLiente");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("DDD");
            dt.Columns.Add("Número");
            dt.Columns.Add("Anotações");

            foreach (var item in this.Customer.Phones)
            {
                var row = dt.Rows.Add(item.Id);
                row[1] = item.Code;
                row[2] = item.CustomerCode;
                row[3] = item.Type;
                row[4] = item.Ddd;
                row[5] = item.Number;
                row[6] = item.Note;
            }

            this.dgvPhone.DataSource = dt;
            this.dgvPhone.Columns["Id"].Visible = false;
            this.dgvPhone.Columns["Código"].Visible = false;
            this.dgvPhone.Columns["Código do CLiente"].Visible = false;

        }

        private void dgvPhone_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var id = Guid.Parse(this.dgvPhone.SelectedRows[0].Cells[0].Value?.ToString());

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
                            Customer.Phones[i] = frm.Phone;
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAddEmail_Click(object sender, EventArgs e)
        {
            var frm = new frmEmailRegister();
            frm.ShowDialog(this);

            if (frm.Email != null)
                this.Customer.Emails.Add(frm.Email);
            this.LoadEmails();
        }

        public void LoadEmails()
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Código");
            dt.Columns.Add("Código do Cliente");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Endereço de Email");
            dt.Columns.Add("Anotação");

            foreach (var item in this.Customer.Emails)
            {
                var row = dt.Rows.Add(item.Id);
                row[1] = item.Code;
                row[2] = item.CustomerCode;
                row[3] = item.Type;
                row[4] = item.Address;
                row[5] = item.Note;
            }

            this.dgvEmail.DataSource = dt;
            this.dgvEmail.Columns["Id"].Visible = false;
            this.dgvEmail.Columns["Código"].Visible = false;
            this.dgvEmail.Columns["Código do Cliente"].Visible = false;
        }

        private void dgvEmail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var id = Guid.Parse(this.dgvEmail.SelectedRows[0].Cells[0].Value?.ToString());

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
                            Customer.Emails[i] = frm.Email;
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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

                this._customerService.Delete(Customer.Code);

                this.Close();
                MessageBox.Show("Cliente excluído com sucesso!", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
