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
using System.Runtime.Versioning;
using static Xpto.UI.Customers.frmCustomerRegister;

namespace Xpto.UI.Customers
{
    public partial class frmCustomerSearch : Form
    {
        private readonly ICustomerService _customerService;
        public event CustomerChangeDelegate Change;
        Customer customer = new Customer();

        public frmCustomerSearch(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }

        private void frmCustomerSearch_Load(object sender, EventArgs e)
        {
            this.LoadCustomers();
        }

        private void LoadCustomers()
        {
            var dt = this._customerService.LoadDataTable();
            this.dvgSearch.DataSource = dt;
            this.dvgSearch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            for (int i = 0; i < this.dvgSearch.Columns.Count; i++)
            {
                this.dvgSearch.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerChanged(Customer customer)
        {
            this.LoadCustomers();
        }

        private void dvgSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var code = int.Parse(this.dvgSearch.SelectedRows[0].Cells[1].Value?.ToString());

            var customer = this._customerService.Get(code);
            if (customer == null)
                return;


            var frm = Program.ServiceProvider.GetRequiredService<frmCustomerRegister>();
            frm.LoadCustomer(customer);
            frm.Change += CustomerChanged;

            frm.Show(this);
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = Program.ServiceProvider.GetRequiredService<frmCustomerRegister>();
            frm.Show(this);
        }



        private void btnFilter_Click(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.LoadCustomers();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var code = int.Parse(this.dvgSearch.SelectedRows[0].Cells[1].Value?.ToString());

            var customer = this._customerService.Get(code);
            if (customer == null)
                return;

            var frm = Program.ServiceProvider.GetRequiredService<frmCustomerRegister>();
            frm.LoadCustomer(customer);
            frm.Change += CustomerChanged;

            frm.Show(this);
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
                    (dvgSearch.DataSource as DataTable).DefaultView.RowFilter =
                        String.Format("name like '%" + txtName.Text + "%'");
                }
            }
        }
    }
}

