namespace AestheticServicesMultiTool
{
    partial class FormRegister
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
            this.btn_Register = new AltoControls.AltoButton();
            this.cb_acceptToS = new System.Windows.Forms.CheckBox();
            this.lbl_ToS = new System.Windows.Forms.Label();
            this.tb_Username_bg = new AltoControls.AltoTextBox();
            this.btn_Close = new AltoControls.AltoButton();
            this.panel_grab = new System.Windows.Forms.Panel();
            this.tb_Password_bg = new AltoControls.AltoTextBox();
            this.tb_Password_confirm_bg = new AltoControls.AltoTextBox();
            this.tb_Username = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.tb_Password_confirm = new System.Windows.Forms.TextBox();
            this.panel_grab.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Register
            // 
            this.btn_Register.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(38)))), ((int)(((byte)(82)))));
            this.btn_Register.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(91)))), ((int)(((byte)(106)))));
            this.btn_Register.BackColor = System.Drawing.Color.Transparent;
            this.btn_Register.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Register.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Register.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btn_Register.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(18)))), ((int)(((byte)(62)))));
            this.btn_Register.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(86)))));
            this.btn_Register.Location = new System.Drawing.Point(80, 204);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Radius = 15;
            this.btn_Register.Size = new System.Drawing.Size(170, 33);
            this.btn_Register.Stroke = false;
            this.btn_Register.StrokeColor = System.Drawing.Color.Gray;
            this.btn_Register.TabIndex = 5;
            this.btn_Register.Text = "Register";
            this.btn_Register.Transparency = false;
            // 
            // cb_acceptToS
            // 
            this.cb_acceptToS.AutoSize = true;
            this.cb_acceptToS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.cb_acceptToS.Location = new System.Drawing.Point(48, 183);
            this.cb_acceptToS.Name = "cb_acceptToS";
            this.cb_acceptToS.Size = new System.Drawing.Size(161, 17);
            this.cb_acceptToS.TabIndex = 3;
            this.cb_acceptToS.Text = "I have read and agree to the";
            this.cb_acceptToS.UseVisualStyleBackColor = true;
            this.cb_acceptToS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cb_acceptToS_KeyUp);
            // 
            // lbl_ToS
            // 
            this.lbl_ToS.AutoSize = true;
            this.lbl_ToS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ToS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lbl_ToS.Location = new System.Drawing.Point(201, 184);
            this.lbl_ToS.Name = "lbl_ToS";
            this.lbl_ToS.Size = new System.Drawing.Size(87, 13);
            this.lbl_ToS.TabIndex = 10;
            this.lbl_ToS.Text = "Terms of Service";
            // 
            // tb_Username_bg
            // 
            this.tb_Username_bg.BackColor = System.Drawing.Color.Transparent;
            this.tb_Username_bg.Br = System.Drawing.Color.White;
            this.tb_Username_bg.Enabled = false;
            this.tb_Username_bg.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.tb_Username_bg.ForeColor = System.Drawing.Color.DimGray;
            this.tb_Username_bg.Location = new System.Drawing.Point(12, 44);
            this.tb_Username_bg.Name = "tb_Username_bg";
            this.tb_Username_bg.Size = new System.Drawing.Size(314, 33);
            this.tb_Username_bg.TabIndex = 4;
            // 
            // btn_Close
            // 
            this.btn_Close.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Close.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Close.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Close.ForeColor = System.Drawing.Color.Black;
            this.btn_Close.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Close.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_Close.Location = new System.Drawing.Point(303, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Radius = 10;
            this.btn_Close.Size = new System.Drawing.Size(30, 30);
            this.btn_Close.Stroke = false;
            this.btn_Close.StrokeColor = System.Drawing.Color.Gray;
            this.btn_Close.TabIndex = 6;
            this.btn_Close.TabStop = false;
            this.btn_Close.Text = "X";
            this.btn_Close.Transparency = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // panel_grab
            // 
            this.panel_grab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel_grab.Controls.Add(this.btn_Close);
            this.panel_grab.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_grab.Location = new System.Drawing.Point(0, 0);
            this.panel_grab.Name = "panel_grab";
            this.panel_grab.Size = new System.Drawing.Size(338, 38);
            this.panel_grab.TabIndex = 11;
            // 
            // tb_Password_bg
            // 
            this.tb_Password_bg.BackColor = System.Drawing.Color.Transparent;
            this.tb_Password_bg.Br = System.Drawing.Color.White;
            this.tb_Password_bg.Enabled = false;
            this.tb_Password_bg.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.tb_Password_bg.ForeColor = System.Drawing.Color.DimGray;
            this.tb_Password_bg.Location = new System.Drawing.Point(12, 83);
            this.tb_Password_bg.Name = "tb_Password_bg";
            this.tb_Password_bg.Size = new System.Drawing.Size(314, 33);
            this.tb_Password_bg.TabIndex = 4;
            // 
            // tb_Password_confirm_bg
            // 
            this.tb_Password_confirm_bg.BackColor = System.Drawing.Color.Transparent;
            this.tb_Password_confirm_bg.Br = System.Drawing.Color.White;
            this.tb_Password_confirm_bg.Enabled = false;
            this.tb_Password_confirm_bg.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.tb_Password_confirm_bg.ForeColor = System.Drawing.Color.DimGray;
            this.tb_Password_confirm_bg.Location = new System.Drawing.Point(12, 122);
            this.tb_Password_confirm_bg.Name = "tb_Password_confirm_bg";
            this.tb_Password_confirm_bg.Size = new System.Drawing.Size(314, 33);
            this.tb_Password_confirm_bg.TabIndex = 4;
            // 
            // tb_Username
            // 
            this.tb_Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Username.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.tb_Username.ForeColor = System.Drawing.Color.DimGray;
            this.tb_Username.Location = new System.Drawing.Point(22, 50);
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.Size = new System.Drawing.Size(296, 21);
            this.tb_Username.TabIndex = 0;
            this.tb_Username.Text = "Username";
            this.tb_Username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Password
            // 
            this.tb_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Password.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.tb_Password.ForeColor = System.Drawing.Color.DimGray;
            this.tb_Password.Location = new System.Drawing.Point(22, 89);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(296, 21);
            this.tb_Password.TabIndex = 1;
            this.tb_Password.Text = "Password";
            this.tb_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Password_confirm
            // 
            this.tb_Password_confirm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Password_confirm.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.tb_Password_confirm.ForeColor = System.Drawing.Color.DimGray;
            this.tb_Password_confirm.Location = new System.Drawing.Point(22, 128);
            this.tb_Password_confirm.Name = "tb_Password_confirm";
            this.tb_Password_confirm.Size = new System.Drawing.Size(296, 21);
            this.tb_Password_confirm.TabIndex = 2;
            this.tb_Password_confirm.Text = "Password confirm";
            this.tb_Password_confirm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(338, 246);
            this.Controls.Add(this.tb_Password_confirm);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_Username);
            this.Controls.Add(this.panel_grab);
            this.Controls.Add(this.tb_Password_confirm_bg);
            this.Controls.Add(this.tb_Password_bg);
            this.Controls.Add(this.tb_Username_bg);
            this.Controls.Add(this.lbl_ToS);
            this.Controls.Add(this.cb_acceptToS);
            this.Controls.Add(this.btn_Register);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRegister";
            this.Text = "FormRegister";
            this.Load += new System.EventHandler(this.FormRegister_Load);
            this.panel_grab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AltoControls.AltoButton btn_Register;
        private System.Windows.Forms.CheckBox cb_acceptToS;
        private System.Windows.Forms.Label lbl_ToS;
        private AltoControls.AltoTextBox tb_Username_bg;
        private AltoControls.AltoButton btn_Close;
        private System.Windows.Forms.Panel panel_grab;
        private AltoControls.AltoTextBox tb_Password_bg;
        private AltoControls.AltoTextBox tb_Password_confirm_bg;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.TextBox tb_Password_confirm;
    }
}