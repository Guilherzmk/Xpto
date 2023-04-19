using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Xpto.Core.Customers;
using Xpto.Services.Customers;

namespace Xpto.UI.Customers
{
    public partial class frmCustomerBin : Form
    {
        private readonly ICustomerService _customerService;
        private Customer Customer = new();

        public frmCustomerBin(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }

        private void frmCustomerBin_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        public void LoadCustomers()
        {
            var dt = this._customerService.LoadDataTableDisabled();
            this.dgvCustomerBin.DataSource = dt;
            this.dgvCustomerBin.Columns[0].Visible = false;
            this.dgvCustomerBin.Columns[8].Visible = false;
            this.dgvCustomerBin.Columns[9].Visible = false;
            this.dgvCustomerBin.Columns[10].Visible = false;
            this.dgvCustomerBin.Columns[11].Visible = false;
            this.dgvCustomerBin.Columns[12].Visible = false;
            this.dgvCustomerBin.Columns[13].Visible = false;
            this.dgvCustomerBin.Columns[14].Visible = false;

            this.dgvCustomerBin.Columns[1].HeaderText = "Código";
            this.dgvCustomerBin.Columns[2].HeaderText = "Nome";
            this.dgvCustomerBin.Columns[3].HeaderText = "Nome Fantasia";
            this.dgvCustomerBin.Columns[4].HeaderText = "Data de Nascimento";
            this.dgvCustomerBin.Columns[5].HeaderText = "CPF/CNPJ";
            this.dgvCustomerBin.Columns[6].HeaderText = "Tipo de Pessoa";
            this.dgvCustomerBin.Columns[7].HeaderText = "Anotações";
        }

        private void dgvCustomerBin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var code = Guid.Parse(this.dgvCustomerBin.SelectedRows[0].Cells[0].Value?.ToString());

                var customer = this._customerService.Get(code);
                if (customer == null)
                    return;

                var frm = Program.ServiceProvider.GetRequiredService<frmCustomerRegister>();
                frm.btnRegister.Text = "Ativar";
                frm.LoadCustomer(customer);

                frm.Change += CustomerChanged;

                frm.ShowDialog(this);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerChanged(Customer customer)
        {
            this.LoadCustomers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var code = Guid.Parse(this.dgvCustomerBin.SelectedRows[0].Cells[0].Value?.ToString());

            if (code == null)
            {
                var msgText = "Não é possível apagar o cliente pois ele não existe";
                MessageBox.Show(msgText, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var msgText = MessageBox.Show("Excluir Cliente?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgText != DialogResult.Yes) { return; }

                this._customerService.Delete(code);

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
