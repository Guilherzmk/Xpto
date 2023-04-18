using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xpto.Services.Customers;
using Microsoft.Extensions.DependencyInjection;
using Xpto.Core.Customers;
using Xpto.UI.Delegates;

namespace Xpto.UI.Customers
{
    public partial class frmCustomerSearch : Form
    {
        private readonly ICustomerService _customerService;
        public event CustomerMensageDelegate Sucess;

        public frmCustomerSearch(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }

        private void frmCustomerSearch_Load(object sender, EventArgs e)
        {
            this.LoadCustomers();
        }

        private void dvgSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var code = Guid.Parse(this.dgvSearch.SelectedRows[0].Cells[0].Value?.ToString());

                var customer = this._customerService.Get(code);
                if (customer == null)
                    return;

                var frm = Program.ServiceProvider.GetRequiredService<frmCustomerRegister>();
                frm.LoadCustomer(customer);

                frm.Change += CustomerChanged;

                frm.ShowDialog(this);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = Program.ServiceProvider.GetRequiredService<frmCustomerRegister>();
            frm.Change += CustomerChanged;
            frm.Show(this);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var code = Guid.Parse(this.dgvSearch.SelectedRows[0].Cells[0].Value?.ToString());

            var customer = this._customerService.Get(code);
            if (customer == null)
                return;

            var frm = Program.ServiceProvider.GetRequiredService<frmCustomerRegister>();
            frm.LoadCustomer(customer);


            frm.Show(this);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.LoadCustomers();
        }

        private void LoadCustomers()
        {
            var dt = this._customerService.LoadDataTable();
            this.dgvSearch.DataSource = dt;

            this.dgvSearch.Columns["id"].Visible = false;
            this.dgvSearch.Columns["creation_date"].Visible = false;
            this.dgvSearch.Columns["creation_user_id"].Visible = false;
            this.dgvSearch.Columns["creation_user_name"].Visible = false;
            this.dgvSearch.Columns["change_date"].Visible = false;
            this.dgvSearch.Columns["change_user_id"].Visible = false;
            this.dgvSearch.Columns["change_user_name"].Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerChanged(Customer customer)
        {
            this.LoadCustomers();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    var msgText = "Insira algo para filtrar";
                    MessageBox.Show(msgText, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    (dgvSearch.DataSource as DataTable).DefaultView.RowFilter =
                        String.Format("Nome like '%" + txtName.Text + "%'");
                }
            }
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void mskCpf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(mskCpf.Text))
                {
                    var msgText = "Insira algo para filtrar";
                    MessageBox.Show(msgText, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    (dgvSearch.DataSource as DataTable).DefaultView.RowFilter =
                        String.Format("'CPF/CNPJ' like '%" + mskCpf.Text + "%'");
                }
            }
        }
    }
}

