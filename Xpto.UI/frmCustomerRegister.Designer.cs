namespace Xpto.UI.Customers
{
    partial class frmCustomerRegister
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
            lblRegister = new Label();
            pnlRegister = new Panel();
            dgvAddress = new DataGridView();
            btnAddEmail = new Button();
            btnAddPhone = new Button();
            btnAddAddress = new Button();
            dgvEmail = new DataGridView();
            lblEmail = new Label();
            dgvPhone = new DataGridView();
            label2 = new Label();
            lblAdress = new Label();
            button1 = new Button();
            btnRegister = new Button();
            cboPersonType = new ComboBox();
            dtpBirthDate = new DateTimePicker();
            txtNote = new TextBox();
            lblNote = new Label();
            txtIdentity = new TextBox();
            lblIdentity = new Label();
            label1 = new Label();
            lblBirthDate = new Label();
            txtNickname = new TextBox();
            lblNickname = new Label();
            txtName = new TextBox();
            lblName = new Label();
            lblCode = new Label();
            btnDelete = new Button();
            pnlRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAddress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhone).BeginInit();
            SuspendLayout();
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Font = new Font("Bahnschrift", 36F, FontStyle.Regular, GraphicsUnit.Point);
            lblRegister.ForeColor = SystemColors.Control;
            lblRegister.Location = new Point(9, 9);
            lblRegister.Margin = new Padding(2, 0, 2, 0);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(176, 58);
            lblRegister.TabIndex = 0;
            lblRegister.Text = "Cliente";
            // 
            // pnlRegister
            // 
            pnlRegister.AutoSize = true;
            pnlRegister.BackColor = Color.FromArgb(37, 37, 37);
            pnlRegister.Controls.Add(btnDelete);
            pnlRegister.Controls.Add(dgvAddress);
            pnlRegister.Controls.Add(btnAddEmail);
            pnlRegister.Controls.Add(btnAddPhone);
            pnlRegister.Controls.Add(btnAddAddress);
            pnlRegister.Controls.Add(dgvEmail);
            pnlRegister.Controls.Add(lblEmail);
            pnlRegister.Controls.Add(dgvPhone);
            pnlRegister.Controls.Add(label2);
            pnlRegister.Controls.Add(lblAdress);
            pnlRegister.Controls.Add(button1);
            pnlRegister.Controls.Add(btnRegister);
            pnlRegister.Controls.Add(cboPersonType);
            pnlRegister.Controls.Add(dtpBirthDate);
            pnlRegister.Controls.Add(txtNote);
            pnlRegister.Controls.Add(lblNote);
            pnlRegister.Controls.Add(txtIdentity);
            pnlRegister.Controls.Add(lblIdentity);
            pnlRegister.Controls.Add(label1);
            pnlRegister.Controls.Add(lblBirthDate);
            pnlRegister.Controls.Add(txtNickname);
            pnlRegister.Controls.Add(lblNickname);
            pnlRegister.Controls.Add(txtName);
            pnlRegister.Controls.Add(lblName);
            pnlRegister.Location = new Point(-1, 82);
            pnlRegister.Margin = new Padding(2, 3, 2, 3);
            pnlRegister.Name = "pnlRegister";
            pnlRegister.Size = new Size(3679, 804);
            pnlRegister.TabIndex = 1;
            // 
            // dgvAddress
            // 
            dgvAddress.BackgroundColor = Color.FromArgb(17, 17, 17);
            dgvAddress.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAddress.Location = new Point(920, 47);
            dgvAddress.Name = "dgvAddress";
            dgvAddress.RowTemplate.Height = 25;
            dgvAddress.Size = new Size(641, 137);
            dgvAddress.TabIndex = 26;
            // 
            // btnAddEmail
            // 
            btnAddEmail.BackColor = Color.FromArgb(51, 51, 51);
            btnAddEmail.ForeColor = SystemColors.Control;
            btnAddEmail.Location = new Point(1486, 370);
            btnAddEmail.Name = "btnAddEmail";
            btnAddEmail.Size = new Size(75, 23);
            btnAddEmail.TabIndex = 25;
            btnAddEmail.Text = "Adicionar";
            btnAddEmail.UseVisualStyleBackColor = false;
            btnAddEmail.Click += btnAddEmail_Click;
            // 
            // btnAddPhone
            // 
            btnAddPhone.BackColor = Color.FromArgb(51, 51, 51);
            btnAddPhone.ForeColor = SystemColors.Control;
            btnAddPhone.Location = new Point(1486, 195);
            btnAddPhone.Name = "btnAddPhone";
            btnAddPhone.Size = new Size(75, 23);
            btnAddPhone.TabIndex = 24;
            btnAddPhone.Text = "Adicionar";
            btnAddPhone.UseVisualStyleBackColor = false;
            btnAddPhone.Click += btnAddPhone_Click;
            // 
            // btnAddAddress
            // 
            btnAddAddress.BackColor = Color.FromArgb(51, 51, 51);
            btnAddAddress.ForeColor = SystemColors.Control;
            btnAddAddress.Location = new Point(1486, 15);
            btnAddAddress.Name = "btnAddAddress";
            btnAddAddress.Size = new Size(75, 23);
            btnAddAddress.TabIndex = 23;
            btnAddAddress.Text = "Adicionar";
            btnAddAddress.UseVisualStyleBackColor = false;
            btnAddAddress.Click += btnAddAddress_Click;
            // 
            // dgvEmail
            // 
            dgvEmail.BackgroundColor = Color.FromArgb(17, 17, 17);
            dgvEmail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmail.Location = new Point(920, 400);
            dgvEmail.Name = "dgvEmail";
            dgvEmail.RowTemplate.Height = 25;
            dgvEmail.Size = new Size(641, 137);
            dgvEmail.TabIndex = 22;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmail.ForeColor = SystemColors.ControlLightLight;
            lblEmail.Location = new Point(920, 364);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(62, 29);
            lblEmail.TabIndex = 21;
            lblEmail.Text = "Email:";
            // 
            // dgvPhone
            // 
            dgvPhone.BackgroundColor = Color.FromArgb(17, 17, 17);
            dgvPhone.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhone.Location = new Point(920, 224);
            dgvPhone.Name = "dgvPhone";
            dgvPhone.RowTemplate.Height = 25;
            dgvPhone.Size = new Size(641, 137);
            dgvPhone.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(920, 189);
            label2.Name = "label2";
            label2.Size = new Size(82, 29);
            label2.TabIndex = 19;
            label2.Text = "Telefone:";
            // 
            // lblAdress
            // 
            lblAdress.AutoSize = true;
            lblAdress.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblAdress.ForeColor = SystemColors.ControlLightLight;
            lblAdress.Location = new Point(920, 9);
            lblAdress.Name = "lblAdress";
            lblAdress.Size = new Size(90, 29);
            lblAdress.TabIndex = 18;
            lblAdress.Text = "Endereço:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(51, 51, 51);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(1099, 560);
            button1.Name = "button1";
            button1.Size = new Size(150, 51);
            button1.TabIndex = 16;
            button1.Text = "Fechar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRegister.BackColor = Color.FromArgb(51, 51, 51);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.ForeColor = SystemColors.Control;
            btnRegister.Location = new Point(1411, 560);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(150, 51);
            btnRegister.TabIndex = 15;
            btnRegister.Text = "Registrar";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // cboPersonType
            // 
            cboPersonType.BackColor = Color.FromArgb(17, 17, 17);
            cboPersonType.ForeColor = SystemColors.Window;
            cboPersonType.FormattingEnabled = true;
            cboPersonType.Items.AddRange(new object[] { "PF", "PJ" });
            cboPersonType.Location = new Point(13, 256);
            cboPersonType.Name = "cboPersonType";
            cboPersonType.Size = new Size(312, 22);
            cboPersonType.TabIndex = 14;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(13, 187);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(312, 22);
            dtpBirthDate.TabIndex = 13;
            dtpBirthDate.Value = new DateTime(2023, 3, 28, 18, 16, 47, 0);
            // 
            // txtNote
            // 
            txtNote.BackColor = Color.FromArgb(17, 17, 17);
            txtNote.BorderStyle = BorderStyle.FixedSingle;
            txtNote.ForeColor = SystemColors.Window;
            txtNote.Location = new Point(13, 400);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(312, 22);
            txtNote.TabIndex = 11;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblNote.ForeColor = SystemColors.ControlLightLight;
            lblNote.Location = new Point(10, 368);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(111, 29);
            lblNote.TabIndex = 10;
            lblNote.Text = "Observação:";
            // 
            // txtIdentity
            // 
            txtIdentity.BackColor = Color.FromArgb(17, 17, 17);
            txtIdentity.BorderStyle = BorderStyle.FixedSingle;
            txtIdentity.ForeColor = SystemColors.Window;
            txtIdentity.Location = new Point(13, 326);
            txtIdentity.Name = "txtIdentity";
            txtIdentity.Size = new Size(312, 22);
            txtIdentity.TabIndex = 9;
            // 
            // lblIdentity
            // 
            lblIdentity.AutoSize = true;
            lblIdentity.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblIdentity.ForeColor = SystemColors.ControlLightLight;
            lblIdentity.Location = new Point(10, 294);
            lblIdentity.Name = "lblIdentity";
            lblIdentity.Size = new Size(91, 29);
            lblIdentity.TabIndex = 8;
            lblIdentity.Text = "CPF/CNPJ:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(10, 224);
            label1.Name = "label1";
            label1.Size = new Size(133, 29);
            label1.TabIndex = 6;
            label1.Text = "Tipo de Pessoa:";
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblBirthDate.ForeColor = SystemColors.ControlLightLight;
            lblBirthDate.Location = new Point(10, 155);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(175, 29);
            lblBirthDate.TabIndex = 4;
            lblBirthDate.Text = "Data de Nascimento:";
            // 
            // txtNickname
            // 
            txtNickname.BackColor = Color.FromArgb(17, 17, 17);
            txtNickname.BorderStyle = BorderStyle.FixedSingle;
            txtNickname.ForeColor = SystemColors.Window;
            txtNickname.Location = new Point(13, 115);
            txtNickname.Name = "txtNickname";
            txtNickname.Size = new Size(312, 22);
            txtNickname.TabIndex = 3;
            // 
            // lblNickname
            // 
            lblNickname.AutoSize = true;
            lblNickname.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblNickname.ForeColor = SystemColors.ControlLightLight;
            lblNickname.Location = new Point(10, 83);
            lblNickname.Name = "lblNickname";
            lblNickname.Size = new Size(135, 29);
            lblNickname.TabIndex = 2;
            lblNickname.Text = "Nome Fantasia:";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(17, 17, 17);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.ForeColor = SystemColors.Window;
            txtName.Location = new Point(13, 47);
            txtName.Name = "txtName";
            txtName.Size = new Size(312, 22);
            txtName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.ForeColor = SystemColors.ControlLightLight;
            lblName.Location = new Point(10, 15);
            lblName.Name = "lblName";
            lblName.Size = new Size(61, 29);
            lblName.TabIndex = 0;
            lblName.Text = "Nome:";
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblCode.ForeColor = SystemColors.ControlLightLight;
            lblCode.Location = new Point(220, 33);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(70, 29);
            lblCode.TabIndex = 26;
            lblCode.Text = "Código:";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(51, 51, 51);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.ForeColor = SystemColors.Control;
            btnDelete.Location = new Point(1255, 560);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 51);
            btnDelete.TabIndex = 27;
            btnDelete.Text = "Deletar";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // frmCustomerRegister
            // 
            AutoScaleDimensions = new SizeF(5F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(2128, 705);
            Controls.Add(lblCode);
            Controls.Add(pnlRegister);
            Controls.Add(lblRegister);
            Font = new Font("Bahnschrift Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "frmCustomerRegister";
            Text = "Customer Register";
            WindowState = FormWindowState.Maximized;
            Load += CustomerRegister_Load;
            pnlRegister.ResumeLayout(false);
            pnlRegister.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAddress).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhone).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRegister;
        private Panel pnlRegister;
        private Label lblName;
        private Label lblNote;
        private Label lblIdentity;
        private Label label1;
        private Label lblBirthDate;
        private Label lblNickname;
        private Button btnRegister;
        private Button button1;
        private Label lblEmail;
        private Label label2;
        private Label lblAdress;
        private Button btnAddEmail;
        private Button btnAddPhone;
        private Button btnAddAddress;
        private Label lblCode;
        public TextBox txtName;
        public DateTimePicker dtpBirthDate;
        public TextBox txtNote;
        public TextBox txtIdentity;
        public TextBox txtNickname;
        public ComboBox cboPersonType;
        public DataGridView dgvEmail;
        public DataGridView dgvPhone;
        public DataGridView dgvAddress;
        private Button btnDelete;
    }
}