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
using Xpto.Core.Shared.Functions;
using Xpto.Services.Customers;
using Xpto.UI.Shared.Entities;

namespace Xpto.UI.Customers
{
    public partial class frmCustomerRegister : Form
    {

        public delegate void CustomerChangeDelegate(Customer customer);
        public event CustomerChangeDelegate Change;
        private readonly ICustomerService _customerService;
        Customer customer = new Customer();
        public bool Confirm { get; set; }

        public frmCustomerRegister(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }

        private void CustomerRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            customer.Name = this.txtName.Text;
            customer.Nickname = this.txtNickname.Text;
            customer.BirthDate = this.dtpBirthDate.Value;
            customer.PersonType = this.cboPersonType.Text;
            customer.Identity = this.txtIdentity.Text;
            customer.Note = this.txtNote.Text;

            if (customer.Code == 0)
            {
                customer = _customerService.Create(customer);
                var msgText = "Cliente criado com sucesso";
                MessageBox.Show(msgText, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                customer = _customerService.Update(customer);
                var msgText = "Cliente atualizado com sucesso";
                MessageBox.Show(msgText, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            AddAddress();
        }

        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            AddPhone();
        }

        private void btnAddEmail_Click(object sender, EventArgs e)
        {
            AddEmail();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AddAddress()
        {
            var frm = new frmAddressRegister();
            frm.Addresses = this.customer.Addresses;
            frm.ShowDialog(this);
            this.LoadAddresses();
        }

        public void AddEmail()
        {
            var frm = new frmEmailRegister();
            frm.Emails = this.customer.Emails;
            frm.ShowDialog(this);
            this.LoadEmails();
        }

        public void AddPhone()
        {
            var frm = new frmPhoneRegister();
            frm.Phones = this.customer.Phones;
            frm.ShowDialog(this);
            this.LoadPhones();
        }

        public void LoadAddresses()
        {
            var frm = new frmAddressRegister();
            frm.Addresses = this.customer.Addresses;
            this.dgvAddress.DataSource = frm.Addresses;
        }

        public void LoadEmails()
        {
            var frm = new frmEmailRegister();
            frm.Emails = this.customer.Emails;
            this.dgvEmail.DataSource = frm.Emails;
        }

        public void LoadPhones()
        {
            var frm = new frmPhoneRegister();
            frm.Phones = this.customer.Phones;
            this.dgvPhone.DataSource = frm.Phones;
        }

        public void LoadCustomer(Customer customer)
        {
            this.customer = customer;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (customer.Code == 0)
            {
                var msgText = "Não é possível apagar o cliente pois ele não existe";
                MessageBox.Show(msgText, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var msgText = MessageBox.Show("Excluir Cliente?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgText != DialogResult.Yes) { return; }

                this._customerService.Delete(customer.Code);
                this.Change(customer);
                this.Close();
                MessageBox.Show("Cliente excluído com sucesso!", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
