namespace Xpto.UI
{
    partial class frmApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApp));
            panel1 = new Panel();
            btnCustomerBin = new Button();
            btnCustomerRegister = new Button();
            btnCustomerSearch = new Button();
            lblXpto = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(37, 37, 37);
            panel1.Controls.Add(btnCustomerBin);
            panel1.Controls.Add(btnCustomerRegister);
            panel1.Controls.Add(btnCustomerSearch);
            panel1.Location = new Point(0, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(2346, 814);
            panel1.TabIndex = 0;
            // 
            // btnCustomerBin
            // 
            btnCustomerBin.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCustomerBin.BackColor = Color.FromArgb(51, 51, 51);
            btnCustomerBin.Cursor = Cursors.Hand;
            btnCustomerBin.FlatStyle = FlatStyle.Flat;
            btnCustomerBin.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnCustomerBin.ForeColor = SystemColors.Control;
            btnCustomerBin.ImageAlign = ContentAlignment.BottomRight;
            btnCustomerBin.Location = new Point(11, 158);
            btnCustomerBin.Name = "btnCustomerBin";
            btnCustomerBin.Size = new Size(184, 52);
            btnCustomerBin.TabIndex = 2;
            btnCustomerBin.Text = "Registros Excluidos";
            btnCustomerBin.UseVisualStyleBackColor = false;
            btnCustomerBin.Click += btnCustomerBin_Click;
            // 
            // btnCustomerRegister
            // 
            btnCustomerRegister.BackColor = Color.FromArgb(51, 51, 51);
            btnCustomerRegister.Cursor = Cursors.Hand;
            btnCustomerRegister.FlatStyle = FlatStyle.Flat;
            btnCustomerRegister.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCustomerRegister.ForeColor = SystemColors.Control;
            btnCustomerRegister.Location = new Point(11, 21);
            btnCustomerRegister.Name = "btnCustomerRegister";
            btnCustomerRegister.Size = new Size(184, 52);
            btnCustomerRegister.TabIndex = 1;
            btnCustomerRegister.Text = "Registrar Cliente";
            btnCustomerRegister.UseVisualStyleBackColor = false;
            btnCustomerRegister.Click += btnCustomerRegister_Click;
            // 
            // btnCustomerSearch
            // 
            btnCustomerSearch.BackColor = Color.FromArgb(51, 51, 51);
            btnCustomerSearch.Cursor = Cursors.Hand;
            btnCustomerSearch.FlatStyle = FlatStyle.Flat;
            btnCustomerSearch.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCustomerSearch.ForeColor = SystemColors.Control;
            btnCustomerSearch.Location = new Point(11, 89);
            btnCustomerSearch.Name = "btnCustomerSearch";
            btnCustomerSearch.Size = new Size(184, 52);
            btnCustomerSearch.TabIndex = 0;
            btnCustomerSearch.Text = "Pesquisar Cliente";
            btnCustomerSearch.UseVisualStyleBackColor = false;
            btnCustomerSearch.Click += btnCustomerSearch_Click;
            // 
            // lblXpto
            // 
            lblXpto.AutoSize = true;
            lblXpto.Font = new Font("Bahnschrift", 36F, FontStyle.Regular, GraphicsUnit.Point);
            lblXpto.ForeColor = SystemColors.Control;
            lblXpto.Location = new Point(11, 9);
            lblXpto.Margin = new Padding(2, 0, 2, 0);
            lblXpto.Name = "lblXpto";
            lblXpto.Size = new Size(120, 58);
            lblXpto.TabIndex = 1;
            lblXpto.Text = "Xpto";
            // 
            // frmApp
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1172, 661);
            Controls.Add(lblXpto);
            Controls.Add(panel1);
            Font = new Font("Constantia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmApp";
            Text = "Xpto";
            WindowState = FormWindowState.Maximized;
            Load += Xpto_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnCustomerSearch;
        private Button btnCustomerRegister;
        private Label lblXpto;
        private Button btnCustomerBin;
    }
}