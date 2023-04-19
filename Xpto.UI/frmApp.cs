using Microsoft.Extensions.DependencyInjection;
using Xpto.UI.Customers;

namespace Xpto.UI
{
    public partial class frmApp : Form
    {
        public frmApp()
        {
            InitializeComponent();
        }

        private void Xpto_Load(object sender, EventArgs e)
        {

        }

        private void btnCustomerRegister_Click(object sender, EventArgs e)
        {
            var frm = Program.ServiceProvider.GetRequiredService<frmCustomerRegister>();
            frm.Show(this);

        }

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            var frm = Program.ServiceProvider.GetRequiredService<frmCustomerSearch>();
            frm.Show(this);
        }

        private void btnCustomerBin_Click(object sender, EventArgs e)
        {
            var frm = Program.ServiceProvider.GetRequiredService<frmCustomerBin>();
            frm.Show(this);
        }
    }
}