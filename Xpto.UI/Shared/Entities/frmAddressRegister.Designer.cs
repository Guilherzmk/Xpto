﻿namespace Xpto.UI.Shared.Entities
{
    partial class frmAddressRegister
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
            txtZipCode = new TextBox();
            lblZipCode = new Label();
            cboState = new ComboBox();
            lblState = new Label();
            txtCity = new TextBox();
            lblCity = new Label();
            txtDistrict = new TextBox();
            lblDistrict = new Label();
            txtComplement = new TextBox();
            lblComplement = new Label();
            txtNumber = new TextBox();
            lblNumber = new Label();
            txtStreet = new TextBox();
            lblStreet = new Label();
            txtType = new TextBox();
            lblType = new Label();
            lblAddressRegister = new Label();
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
            panel1.Controls.Add(txtZipCode);
            panel1.Controls.Add(lblZipCode);
            panel1.Controls.Add(cboState);
            panel1.Controls.Add(lblState);
            panel1.Controls.Add(txtCity);
            panel1.Controls.Add(lblCity);
            panel1.Controls.Add(txtDistrict);
            panel1.Controls.Add(lblDistrict);
            panel1.Controls.Add(txtComplement);
            panel1.Controls.Add(lblComplement);
            panel1.Controls.Add(txtNumber);
            panel1.Controls.Add(lblNumber);
            panel1.Controls.Add(txtStreet);
            panel1.Controls.Add(lblStreet);
            panel1.Controls.Add(txtType);
            panel1.Controls.Add(lblType);
            panel1.Location = new Point(-4, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(805, 385);
            panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(51, 51, 51);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = SystemColors.Control;
            btnClose.Location = new Point(486, 321);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 51);
            btnClose.TabIndex = 21;
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
            btnRegister.Location = new Point(642, 321);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(150, 51);
            btnRegister.TabIndex = 20;
            btnRegister.Text = "Adicionar";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click_1;
            // 
            // txtNote
            // 
            txtNote.BackColor = Color.FromArgb(17, 17, 17);
            txtNote.BorderStyle = BorderStyle.FixedSingle;
            txtNote.ForeColor = SystemColors.Window;
            txtNote.Location = new Point(393, 218);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(312, 23);
            txtNote.TabIndex = 19;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblNote.ForeColor = SystemColors.ControlLightLight;
            lblNote.Location = new Point(394, 186);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(111, 29);
            lblNote.TabIndex = 18;
            lblNote.Text = "Observação:";
            // 
            // txtZipCode
            // 
            txtZipCode.BackColor = Color.FromArgb(17, 17, 17);
            txtZipCode.BorderStyle = BorderStyle.FixedSingle;
            txtZipCode.ForeColor = SystemColors.Window;
            txtZipCode.Location = new Point(393, 160);
            txtZipCode.Name = "txtZipCode";
            txtZipCode.Size = new Size(312, 23);
            txtZipCode.TabIndex = 17;
            // 
            // lblZipCode
            // 
            lblZipCode.AutoSize = true;
            lblZipCode.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblZipCode.ForeColor = SystemColors.ControlLightLight;
            lblZipCode.Location = new Point(394, 128);
            lblZipCode.Name = "lblZipCode";
            lblZipCode.Size = new Size(45, 29);
            lblZipCode.TabIndex = 16;
            lblZipCode.Text = "CEP:";
            // 
            // cboState
            // 
            cboState.BackColor = Color.FromArgb(17, 17, 17);
            cboState.ForeColor = SystemColors.Window;
            cboState.FormattingEnabled = true;
            cboState.Items.AddRange(new object[] { "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO" });
            cboState.Location = new Point(393, 102);
            cboState.Name = "cboState";
            cboState.Size = new Size(312, 23);
            cboState.TabIndex = 15;
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblState.ForeColor = SystemColors.ControlLightLight;
            lblState.Location = new Point(393, 70);
            lblState.Name = "lblState";
            lblState.Size = new Size(70, 29);
            lblState.TabIndex = 13;
            lblState.Text = "Estado:";
            // 
            // txtCity
            // 
            txtCity.BackColor = Color.FromArgb(17, 17, 17);
            txtCity.BorderStyle = BorderStyle.FixedSingle;
            txtCity.ForeColor = SystemColors.Window;
            txtCity.Location = new Point(393, 44);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(312, 23);
            txtCity.TabIndex = 12;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblCity.ForeColor = SystemColors.ControlLightLight;
            lblCity.Location = new Point(393, 12);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(71, 29);
            lblCity.TabIndex = 11;
            lblCity.Text = "Cidade:";
            // 
            // txtDistrict
            // 
            txtDistrict.BackColor = Color.FromArgb(17, 17, 17);
            txtDistrict.BorderStyle = BorderStyle.FixedSingle;
            txtDistrict.ForeColor = SystemColors.Window;
            txtDistrict.Location = new Point(16, 276);
            txtDistrict.Name = "txtDistrict";
            txtDistrict.Size = new Size(312, 23);
            txtDistrict.TabIndex = 10;
            // 
            // lblDistrict
            // 
            lblDistrict.AutoSize = true;
            lblDistrict.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblDistrict.ForeColor = SystemColors.ControlLightLight;
            lblDistrict.Location = new Point(16, 244);
            lblDistrict.Name = "lblDistrict";
            lblDistrict.Size = new Size(67, 29);
            lblDistrict.TabIndex = 9;
            lblDistrict.Text = "Bairro:";
            // 
            // txtComplement
            // 
            txtComplement.BackColor = Color.FromArgb(17, 17, 17);
            txtComplement.BorderStyle = BorderStyle.FixedSingle;
            txtComplement.ForeColor = SystemColors.Window;
            txtComplement.Location = new Point(16, 218);
            txtComplement.Name = "txtComplement";
            txtComplement.Size = new Size(312, 23);
            txtComplement.TabIndex = 8;
            // 
            // lblComplement
            // 
            lblComplement.AutoSize = true;
            lblComplement.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblComplement.ForeColor = SystemColors.ControlLightLight;
            lblComplement.Location = new Point(15, 186);
            lblComplement.Name = "lblComplement";
            lblComplement.Size = new Size(121, 29);
            lblComplement.TabIndex = 7;
            lblComplement.Text = "Complemento";
            // 
            // txtNumber
            // 
            txtNumber.BackColor = Color.FromArgb(17, 17, 17);
            txtNumber.BorderStyle = BorderStyle.FixedSingle;
            txtNumber.ForeColor = SystemColors.Window;
            txtNumber.Location = new Point(16, 160);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(312, 23);
            txtNumber.TabIndex = 6;
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblNumber.ForeColor = SystemColors.ControlLightLight;
            lblNumber.Location = new Point(14, 128);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(79, 29);
            lblNumber.TabIndex = 5;
            lblNumber.Text = "Número:";
            // 
            // txtStreet
            // 
            txtStreet.BackColor = Color.FromArgb(17, 17, 17);
            txtStreet.BorderStyle = BorderStyle.FixedSingle;
            txtStreet.ForeColor = SystemColors.Window;
            txtStreet.Location = new Point(16, 102);
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new Size(312, 23);
            txtStreet.TabIndex = 4;
            // 
            // lblStreet
            // 
            lblStreet.AutoSize = true;
            lblStreet.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblStreet.ForeColor = SystemColors.ControlLightLight;
            lblStreet.Location = new Point(15, 70);
            lblStreet.Name = "lblStreet";
            lblStreet.Size = new Size(48, 29);
            lblStreet.TabIndex = 3;
            lblStreet.Text = "Rua:";
            // 
            // txtType
            // 
            txtType.BackColor = Color.FromArgb(17, 17, 17);
            txtType.BorderStyle = BorderStyle.FixedSingle;
            txtType.ForeColor = SystemColors.Window;
            txtType.Location = new Point(16, 44);
            txtType.Name = "txtType";
            txtType.Size = new Size(312, 23);
            txtType.TabIndex = 2;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblType.ForeColor = SystemColors.ControlLightLight;
            lblType.Location = new Point(14, 12);
            lblType.Name = "lblType";
            lblType.Size = new Size(49, 29);
            lblType.TabIndex = 1;
            lblType.Text = "Tipo:";
            // 
            // lblAddressRegister
            // 
            lblAddressRegister.AutoSize = true;
            lblAddressRegister.Font = new Font("Bahnschrift", 36F, FontStyle.Regular, GraphicsUnit.Point);
            lblAddressRegister.ForeColor = SystemColors.Control;
            lblAddressRegister.Location = new Point(12, 5);
            lblAddressRegister.Name = "lblAddressRegister";
            lblAddressRegister.Size = new Size(229, 58);
            lblAddressRegister.TabIndex = 1;
            lblAddressRegister.Text = "Endereço";
            // 
            // frmAddressRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(800, 450);
            Controls.Add(lblAddressRegister);
            Controls.Add(panel1);
            Name = "frmAddressRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddressRegister";
            Load += frmAddressRegister_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblAddressRegister;
        private Label lblType;
        private TextBox txtType;
        private Label lblState;
        private TextBox txtCity;
        private Label lblCity;
        private TextBox txtDistrict;
        private Label lblDistrict;
        private TextBox txtComplement;
        private Label lblComplement;
        private TextBox txtNumber;
        private Label lblNumber;
        private TextBox txtStreet;
        private Label lblStreet;
        private ComboBox cboState;
        private TextBox txtNote;
        private Label lblNote;
        private TextBox txtZipCode;
        private Label lblZipCode;
        private Button btnClose;
        private Button btnRegister;
    }
}