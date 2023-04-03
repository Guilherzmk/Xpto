namespace Xpto.UI.Shared.Entities
{
    partial class frmPhoneRegister
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
            btnRegister = new Button();
            txtNote = new TextBox();
            lblNote = new Label();
            txtNumber = new TextBox();
            lblNumber = new Label();
            txtDdd = new TextBox();
            lblDdd = new Label();
            txtType = new TextBox();
            lblType = new Label();
            lblPhoneRegister = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(37, 37, 37);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(txtNote);
            panel1.Controls.Add(lblNote);
            panel1.Controls.Add(txtNumber);
            panel1.Controls.Add(lblNumber);
            panel1.Controls.Add(txtDdd);
            panel1.Controls.Add(lblDdd);
            panel1.Controls.Add(txtType);
            panel1.Controls.Add(lblType);
            panel1.Location = new Point(-3, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(805, 382);
            panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(51, 51, 51);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = SystemColors.Control;
            btnClose.Location = new Point(485, 317);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 51);
            btnClose.TabIndex = 23;
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
            btnRegister.Location = new Point(641, 317);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(150, 51);
            btnRegister.TabIndex = 22;
            btnRegister.Text = "Adicionar";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtNote
            // 
            txtNote.BackColor = Color.FromArgb(17, 17, 17);
            txtNote.BorderStyle = BorderStyle.FixedSingle;
            txtNote.ForeColor = SystemColors.Window;
            txtNote.Location = new Point(15, 216);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(312, 23);
            txtNote.TabIndex = 10;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblNote.ForeColor = SystemColors.ControlLightLight;
            lblNote.Location = new Point(15, 184);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(111, 29);
            lblNote.TabIndex = 9;
            lblNote.Text = "Observação:";
            // 
            // txtNumber
            // 
            txtNumber.BackColor = Color.FromArgb(17, 17, 17);
            txtNumber.BorderStyle = BorderStyle.FixedSingle;
            txtNumber.ForeColor = SystemColors.Window;
            txtNumber.Location = new Point(15, 158);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(312, 23);
            txtNumber.TabIndex = 8;
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblNumber.ForeColor = SystemColors.ControlLightLight;
            lblNumber.Location = new Point(15, 126);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(79, 29);
            lblNumber.TabIndex = 7;
            lblNumber.Text = "Número:";
            // 
            // txtDdd
            // 
            txtDdd.BackColor = Color.FromArgb(17, 17, 17);
            txtDdd.BorderStyle = BorderStyle.FixedSingle;
            txtDdd.ForeColor = SystemColors.Window;
            txtDdd.Location = new Point(15, 100);
            txtDdd.Name = "txtDdd";
            txtDdd.Size = new Size(312, 23);
            txtDdd.TabIndex = 6;
            // 
            // lblDdd
            // 
            lblDdd.AutoSize = true;
            lblDdd.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblDdd.ForeColor = SystemColors.ControlLightLight;
            lblDdd.Location = new Point(15, 68);
            lblDdd.Name = "lblDdd";
            lblDdd.Size = new Size(46, 29);
            lblDdd.TabIndex = 5;
            lblDdd.Text = "DDD:";
            // 
            // txtType
            // 
            txtType.BackColor = Color.FromArgb(17, 17, 17);
            txtType.BorderStyle = BorderStyle.FixedSingle;
            txtType.ForeColor = SystemColors.Window;
            txtType.Location = new Point(15, 42);
            txtType.Name = "txtType";
            txtType.Size = new Size(312, 23);
            txtType.TabIndex = 4;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblType.ForeColor = SystemColors.ControlLightLight;
            lblType.Location = new Point(15, 10);
            lblType.Name = "lblType";
            lblType.Size = new Size(49, 29);
            lblType.TabIndex = 3;
            lblType.Text = "Tipo:";
            // 
            // lblPhoneRegister
            // 
            lblPhoneRegister.AutoSize = true;
            lblPhoneRegister.Font = new Font("Bahnschrift", 36F, FontStyle.Regular, GraphicsUnit.Point);
            lblPhoneRegister.ForeColor = SystemColors.Control;
            lblPhoneRegister.Location = new Point(12, 9);
            lblPhoneRegister.Name = "lblPhoneRegister";
            lblPhoneRegister.Size = new Size(204, 58);
            lblPhoneRegister.TabIndex = 3;
            lblPhoneRegister.Text = "Telefone";
            // 
            // frmPhoneRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(800, 450);
            Controls.Add(lblPhoneRegister);
            Controls.Add(panel1);
            Name = "frmPhoneRegister";
            Text = "frmPhoneRegister";
            Load += frmPhoneRegister_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblPhoneRegister;
        private Label lblType;
        private TextBox txtType;
        private Label lblNote;
        private TextBox txtNumber;
        private Label lblNumber;
        private TextBox txtDdd;
        private Label lblDdd;
        private TextBox txtNote;
        private Button btnRegister;
        private Button btnClose;
    }
}