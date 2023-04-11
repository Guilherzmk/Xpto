namespace Xpto.UI.Customers
{
    partial class frmCustomerSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerSearch));
            lblName = new Label();
            txtName = new TextBox();
            btnExit = new Button();
            dvgSearch = new DataGridView();
            clienteToolStripMenuItem = new ToolStripMenuItem();
            cadastrarToolStripMenuItem = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            mstCustomer = new MenuStrip();
            panel1 = new Panel();
            btnFind = new Button();
            lblIdentity = new Label();
            txtIdentity = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dvgSearch).BeginInit();
            mstCustomer.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.ForeColor = SystemColors.Control;
            lblName.Location = new Point(42, 54);
            lblName.Name = "lblName";
            lblName.Size = new Size(61, 29);
            lblName.TabIndex = 3;
            lblName.Text = "Nome:";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(17, 17, 17);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.ForeColor = SystemColors.Window;
            txtName.Location = new Point(109, 61);
            txtName.Name = "txtName";
            txtName.Size = new Size(169, 22);
            txtName.TabIndex = 4;
            txtName.KeyDown += txtName_KeyDown;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(51, 51, 51);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = SystemColors.Control;
            btnExit.Location = new Point(1015, 704);
            btnExit.Margin = new Padding(4, 3, 4, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(184, 52);
            btnExit.TabIndex = 5;
            btnExit.Text = "Sair";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // dvgSearch
            // 
            dvgSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dvgSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgSearch.BackgroundColor = Color.FromArgb(17, 17, 17);
            dvgSearch.Location = new Point(13, 12);
            dvgSearch.Name = "dvgSearch";
            dvgSearch.RowTemplate.Height = 25;
            dvgSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgSearch.Size = new Size(1186, 686);
            dvgSearch.TabIndex = 9;
            dvgSearch.CellDoubleClick += dvgSearch_CellDoubleClick;
            // 
            // clienteToolStripMenuItem
            // 
            clienteToolStripMenuItem.BackColor = Color.FromArgb(51, 51, 51);
            clienteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cadastrarToolStripMenuItem, editarToolStripMenuItem });
            clienteToolStripMenuItem.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            clienteToolStripMenuItem.ForeColor = SystemColors.Control;
            clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            clienteToolStripMenuItem.Size = new Size(58, 23);
            clienteToolStripMenuItem.Text = "Cliente";
            // 
            // cadastrarToolStripMenuItem
            // 
            cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            cadastrarToolStripMenuItem.Size = new Size(132, 24);
            cadastrarToolStripMenuItem.Text = "Cadastrar";
            cadastrarToolStripMenuItem.Click += cadastrarToolStripMenuItem_Click;
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(132, 24);
            editarToolStripMenuItem.Text = "Editar";
            editarToolStripMenuItem.Click += editarToolStripMenuItem_Click;
            // 
            // mstCustomer
            // 
            mstCustomer.BackColor = Color.FromArgb(37, 37, 37);
            mstCustomer.Items.AddRange(new ToolStripItem[] { clienteToolStripMenuItem });
            mstCustomer.Location = new Point(0, 0);
            mstCustomer.Name = "mstCustomer";
            mstCustomer.Size = new Size(1538, 27);
            mstCustomer.TabIndex = 10;
            mstCustomer.Text = "menuStrip1";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(37, 37, 37);
            panel1.Controls.Add(btnFind);
            panel1.Controls.Add(dvgSearch);
            panel1.Controls.Add(btnExit);
            panel1.Location = new Point(300, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(1813, 907);
            panel1.TabIndex = 11;
            // 
            // btnFind
            // 
            btnFind.BackColor = Color.FromArgb(51, 51, 51);
            btnFind.FlatStyle = FlatStyle.Flat;
            btnFind.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnFind.ForeColor = SystemColors.Control;
            btnFind.Location = new Point(823, 704);
            btnFind.Margin = new Padding(4, 3, 4, 3);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(184, 52);
            btnFind.TabIndex = 10;
            btnFind.Text = "Consultar";
            btnFind.UseVisualStyleBackColor = false;
            btnFind.Click += btnFind_Click;
            // 
            // lblIdentity
            // 
            lblIdentity.AutoSize = true;
            lblIdentity.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblIdentity.ForeColor = SystemColors.Control;
            lblIdentity.Location = new Point(12, 98);
            lblIdentity.Name = "lblIdentity";
            lblIdentity.Size = new Size(91, 29);
            lblIdentity.TabIndex = 12;
            lblIdentity.Text = "CPF/CNPJ:";
            // 
            // txtIdentity
            // 
            txtIdentity.BackColor = Color.FromArgb(17, 17, 17);
            txtIdentity.BorderStyle = BorderStyle.FixedSingle;
            txtIdentity.ForeColor = SystemColors.Window;
            txtIdentity.Location = new Point(109, 105);
            txtIdentity.Name = "txtIdentity";
            txtIdentity.Size = new Size(169, 22);
            txtIdentity.TabIndex = 13;
            txtIdentity.KeyDown += txtIdentity_KeyDown;
            // 
            // frmCustomerSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1538, 881);
            Controls.Add(txtIdentity);
            Controls.Add(lblIdentity);
            Controls.Add(panel1);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(mstCustomer);
            Font = new Font("Constantia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mstCustomer;
            Name = "frmCustomerSearch";
            Text = "Pesquisa";
            WindowState = FormWindowState.Maximized;
            Load += frmCustomerSearch_Load;
            ((System.ComponentModel.ISupportInitialize)dvgSearch).EndInit();
            mstCustomer.ResumeLayout(false);
            mstCustomer.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblName;
        private TextBox txtName;
        private Button btnExit;
        private DataGridView dvgSearch;
        private ToolStripMenuItem clienteToolStripMenuItem;
        private ToolStripMenuItem cadastrarToolStripMenuItem;
        private MenuStrip mstCustomer;
        private Panel panel1;
        private Button btnFind;
        private ToolStripMenuItem editarToolStripMenuItem;
        private Label lblIdentity;
        private TextBox txtIdentity;
    }


}
