namespace Xpto.UI.Shared.Entities
{
    partial class frmEmailRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmailRegister));
            panel1 = new Panel();
            cboType = new ComboBox();
            btnDelete = new Button();
            btnClose = new Button();
            btnRegister = new Button();
            txtNote = new TextBox();
            lblNote = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            lblType = new Label();
            lblEmailRegister = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(37, 37, 37);
            panel1.Controls.Add(cboType);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(txtNote);
            panel1.Controls.Add(lblNote);
            panel1.Controls.Add(txtAddress);
            panel1.Controls.Add(lblAddress);
            panel1.Controls.Add(lblType);
            panel1.Location = new Point(-2, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(804, 389);
            panel1.TabIndex = 0;
            // 
            // cboType
            // 
            cboType.BackColor = Color.FromArgb(17, 17, 17);
            cboType.ForeColor = SystemColors.Window;
            cboType.FormattingEnabled = true;
            cboType.Items.AddRange(new object[] { "Pessoal", "Corporativo" });
            cboType.Location = new Point(14, 41);
            cboType.Name = "cboType";
            cboType.Size = new Size(312, 23);
            cboType.TabIndex = 24;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(51, 51, 51);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.ForeColor = SystemColors.Control;
            btnDelete.Location = new Point(484, 317);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 51);
            btnDelete.TabIndex = 23;
            btnDelete.Text = "Deletar";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(51, 51, 51);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = SystemColors.Control;
            btnClose.Location = new Point(328, 317);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 51);
            btnClose.TabIndex = 22;
            btnClose.Text = "Fechar";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRegister.BackColor = Color.FromArgb(51, 51, 51);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.ForeColor = SystemColors.Control;
            btnRegister.Location = new Point(640, 317);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(150, 51);
            btnRegister.TabIndex = 21;
            btnRegister.Text = "Adicionar";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtNote
            // 
            txtNote.BackColor = Color.FromArgb(17, 17, 17);
            txtNote.BorderStyle = BorderStyle.FixedSingle;
            txtNote.ForeColor = SystemColors.Window;
            txtNote.Location = new Point(14, 157);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(312, 23);
            txtNote.TabIndex = 7;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblNote.ForeColor = SystemColors.ControlLightLight;
            lblNote.Location = new Point(14, 125);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(111, 29);
            lblNote.TabIndex = 6;
            lblNote.Text = "Observação:";
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.FromArgb(17, 17, 17);
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.ForeColor = SystemColors.Window;
            txtAddress.Location = new Point(14, 99);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(312, 23);
            txtAddress.TabIndex = 5;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblAddress.ForeColor = SystemColors.ControlLightLight;
            lblAddress.Location = new Point(14, 67);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(164, 29);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Endereço de Email:";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblType.ForeColor = SystemColors.ControlLightLight;
            lblType.Location = new Point(14, 9);
            lblType.Name = "lblType";
            lblType.Size = new Size(49, 29);
            lblType.TabIndex = 2;
            lblType.Text = "Tipo:";
            // 
            // lblEmailRegister
            // 
            lblEmailRegister.AutoSize = true;
            lblEmailRegister.Font = new Font("Bahnschrift", 36F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmailRegister.ForeColor = SystemColors.Control;
            lblEmailRegister.Location = new Point(12, 9);
            lblEmailRegister.Name = "lblEmailRegister";
            lblEmailRegister.Size = new Size(147, 58);
            lblEmailRegister.TabIndex = 2;
            lblEmailRegister.Text = "Email";
            // 
            // frmEmailRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(800, 450);
            Controls.Add(lblEmailRegister);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmEmailRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmEmailRegister";
            Load += frmEmailRegister_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblEmailRegister;
        private Label lblType;
        private TextBox txtNote;
        private Label lblNote;
        private TextBox txtAddress;
        private Label lblAddress;
        private Button btnRegister;
        private Button btnClose;
        private Button btnDelete;
        private ComboBox cboType;
    }
}