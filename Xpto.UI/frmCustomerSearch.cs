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
using Xpto.Core.Shared.Entities.Address;

namespace Xpto.UI.Customers
{
    public partial class frmCustomerSearch : Form
    {
        private readonly ICustomerService _customerService;

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
                var code = int.Parse(this.dvgSearch.SelectedRows[0].Cells[1].Value?.ToString());

                var customer = this._customerService.Get(code);
                if (customer == null)
                    return;

                var frm = Program.ServiceProvider.GetRequiredService<frmCustomerRegister>();
                frm.LoadCustomer(customer);
                //frm.Change += CustomerChanged;

                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = Program.ServiceProvider.GetRequiredService<frmCustomerRegister>();
            frm.Show(this);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var code = int.Parse(this.dvgSearch.SelectedRows[0].Cells[1].Value?.ToString());

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
            this.dvgSearch.DataSource = dt;
            this.dvgSearch.Columns["id"].Visible = false;
            this.dvgSearch.Columns["creation_date"].Visible = false;
            this.dvgSearch.Columns["creation_user_id"].Visible = false;
            this.dvgSearch.Columns["creation_user_name"].Visible = false;
            this.dvgSearch.Columns["change_date"].Visible = false;
            this.dvgSearch.Columns["change_user_id"].Visible = false;
            this.dvgSearch.Columns["change_user_name"].Visible = false;


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

        private void txtIdentity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtIdentity.Text))
                {
                    var msgText = "Insira algo para filtrar";
                    MessageBox.Show(msgText, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    (dvgSearch.DataSource as DataTable).DefaultView.RowFilter =
                        string.Format("identity like '%" + txtIdentity.Text + "%'");
                }
            }
        }
    }
}

