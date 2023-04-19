namespace Xpto.UI.Customers
{
    partial class frmCustomerBin
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
            panel1 = new Panel();
            btnClose = new Button();
            btnDelete = new Button();
            dgvCustomerBin = new DataGridView();
            lblBin = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerBin).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(37, 37, 37);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(dgvCustomerBin);
            panel1.Location = new Point(0, 84);
            panel1.Name = "panel1";
            panel1.Size = new Size(934, 481);
            panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(51, 51, 51);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = SystemColors.Control;
            btnClose.Location = new Point(773, 413);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 51);
            btnClose.TabIndex = 30;
            btnClose.Text = "Fechar";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(51, 51, 51);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.ForeColor = SystemColors.Control;
            btnDelete.Location = new Point(617, 413);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 51);
            btnDelete.TabIndex = 28;
            btnDelete.Text = "Deletar";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvCustomerBin
            // 
            dgvCustomerBin.BackgroundColor = Color.FromArgb(17, 17, 17);
            dgvCustomerBin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerBin.Location = new Point(12, 17);
            dgvCustomerBin.Name = "dgvCustomerBin";
            dgvCustomerBin.RowTemplate.Height = 25;
            dgvCustomerBin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomerBin.Size = new Size(906, 390);
            dgvCustomerBin.TabIndex = 0;
            dgvCustomerBin.CellDoubleClick += dgvCustomerBin_CellDoubleClick;
            // 
            // lblBin
            // 
            lblBin.AutoSize = true;
            lblBin.Font = new Font("Bahnschrift", 36F, FontStyle.Regular, GraphicsUnit.Point);
            lblBin.ForeColor = SystemColors.Control;
            lblBin.Location = new Point(11, 9);
            lblBin.Margin = new Padding(2, 0, 2, 0);
            lblBin.Name = "lblBin";
            lblBin.Size = new Size(451, 58);
            lblBin.TabIndex = 2;
            lblBin.Text = "Registros Excluidos";
            // 
            // frmCustomerBin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(930, 560);
            Controls.Add(lblBin);
            Controls.Add(panel1);
            Name = "frmCustomerBin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCustomerBin";
            Load += frmCustomerBin_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomerBin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblBin;
        private DataGridView dgvCustomerBin;
        public Button btnDelete;
        public Button btnClose;
    }
}