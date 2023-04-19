using System.Data;
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
                frm.btnRegister.Text = "Atualizar";
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
            this.dgvSearch.Columns[0].Visible = false;
            this.dgvSearch.Columns[8].Visible = false;
            this.dgvSearch.Columns[9].Visible = false;
            this.dgvSearch.Columns[10].Visible = false;
            this.dgvSearch.Columns[11].Visible = false;
            this.dgvSearch.Columns[12].Visible = false;
            this.dgvSearch.Columns[13].Visible = false;
            this.dgvSearch.Columns[14].Visible = false;

            this.dgvSearch.Columns[1].HeaderText = "Código";
            this.dgvSearch.Columns[2].HeaderText = "Nome";
            this.dgvSearch.Columns[3].HeaderText = "Nome Fantasia";
            this.dgvSearch.Columns[4].HeaderText = "Data de Nascimento";
            this.dgvSearch.Columns[5].HeaderText = "CPF/CNPJ";
            this.dgvSearch.Columns[6].HeaderText = "Tipo de Pessoa";
            this.dgvSearch.Columns[7].HeaderText = "Anotações";
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
                        String.Format("name like '%" + txtName.Text + "%'");
                }
            }
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
                        String.Format("identity like '%" + mskCpf.Text.ToString() + "%'");

                }
            }
        }

        private void mskCnpj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(mskCnpj.Text))
                {
                    var msgText = "Insira algo para filtrar";
                    MessageBox.Show(msgText, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    (dgvSearch.DataSource as DataTable).DefaultView.RowFilter =
                        String.Format("identity like '%" + mskCnpj.Text.ToString() + "%'");

                }
            }
        }
    }
}

