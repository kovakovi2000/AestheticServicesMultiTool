namespace AestheticServicesMultiTool
{
    partial class FormLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.btn_Login = new AltoControls.AltoButton();
            this.panel_grab = new System.Windows.Forms.Panel();
            this.btn_Minimalize = new AltoControls.AltoButton();
            this.btn_Close = new AltoControls.AltoButton();
            this.altoSlidingLabel1 = new AltoControls.AltoSlidingLabel();
            this.NotyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tb_Username = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tmr_Rotator = new System.Windows.Forms.Timer(this.components);
            this.lbl_ErrorOutput = new System.Windows.Forms.Label();
            this.panel_grab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Login
            // 
            this.btn_Login.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(38)))), ((int)(((byte)(82)))));
            this.btn_Login.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(91)))), ((int)(((byte)(106)))));
            this.btn_Login.BackColor = System.Drawing.Color.Transparent;
            this.btn_Login.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Login.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btn_Login.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(18)))), ((int)(((byte)(62)))));
            this.btn_Login.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(86)))));
            this.btn_Login.Location = new System.Drawing.Point(74, 361);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Radius = 15;
            this.btn_Login.Size = new System.Drawing.Size(180, 33);
            this.btn_Login.Stroke = false;
            this.btn_Login.StrokeColor = System.Drawing.Color.Gray;
            this.btn_Login.TabIndex = 0;
            this.btn_Login.Text = "Login";
            this.btn_Login.Transparency = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // panel_grab
            // 
            this.panel_grab.Controls.Add(this.btn_Minimalize);
            this.panel_grab.Controls.Add(this.btn_Close);
            this.panel_grab.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_grab.Location = new System.Drawing.Point(0, 0);
            this.panel_grab.Name = "panel_grab";
            this.panel_grab.Size = new System.Drawing.Size(330, 38);
            this.panel_grab.TabIndex = 2;
            this.panel_grab.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_grab_MouseDown);
            this.panel_grab.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_grab_MouseMove);
            this.panel_grab.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_grab_MouseUp);
            // 
            // btn_Minimalize
            // 
            this.btn_Minimalize.Active1 = System.Drawing.Color.Gray;
            this.btn_Minimalize.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Minimalize.BackColor = System.Drawing.Color.Transparent;
            this.btn_Minimalize.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Minimalize.Font = new System.Drawing.Font("Consolas", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Minimalize.ForeColor = System.Drawing.Color.Black;
            this.btn_Minimalize.Inactive1 = System.Drawing.Color.Silver;
            this.btn_Minimalize.Inactive2 = System.Drawing.Color.Gray;
            this.btn_Minimalize.Location = new System.Drawing.Point(261, 3);
            this.btn_Minimalize.Name = "btn_Minimalize";
            this.btn_Minimalize.Radius = 10;
            this.btn_Minimalize.Size = new System.Drawing.Size(30, 30);
            this.btn_Minimalize.Stroke = false;
            this.btn_Minimalize.StrokeColor = System.Drawing.Color.Gray;
            this.btn_Minimalize.TabIndex = 3;
            this.btn_Minimalize.Text = "_";
            this.btn_Minimalize.Transparency = false;
            this.btn_Minimalize.Click += new System.EventHandler(this.btn_Minimalize_Click);
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
            this.btn_Close.Location = new System.Drawing.Point(297, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Radius = 10;
            this.btn_Close.Size = new System.Drawing.Size(30, 30);
            this.btn_Close.Stroke = false;
            this.btn_Close.StrokeColor = System.Drawing.Color.Gray;
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "X";
            this.btn_Close.Transparency = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // altoSlidingLabel1
            // 
            this.altoSlidingLabel1.Location = new System.Drawing.Point(0, 400);
            this.altoSlidingLabel1.Name = "altoSlidingLabel1";
            this.altoSlidingLabel1.Size = new System.Drawing.Size(330, 15);
            this.altoSlidingLabel1.Slide = true;
            this.altoSlidingLabel1.TabIndex = 4;
            this.altoSlidingLabel1.Text = "                                                                        MultiTool" +
    " Design By Kova                                                                 " +
    "       ";
            // 
            // NotyIcon
            // 
            this.NotyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotyIcon.Icon")));
            this.NotyIcon.Text = "Aesthetic Services";
            this.NotyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseClick);
            // 
            // tb_Username
            // 
            this.tb_Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Username.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.tb_Username.ForeColor = System.Drawing.Color.DimGray;
            this.tb_Username.Location = new System.Drawing.Point(27, 271);
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.Size = new System.Drawing.Size(276, 21);
            this.tb_Username.TabIndex = 5;
            this.tb_Username.Text = "Username";
            this.tb_Username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Username.Enter += new System.EventHandler(this.tb_Username_Enter);
            this.tb_Username.Leave += new System.EventHandler(this.tb_Username_Leave);
            // 
            // tb_Password
            // 
            this.tb_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Password.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.tb_Password.ForeColor = System.Drawing.Color.DimGray;
            this.tb_Password.Location = new System.Drawing.Point(27, 308);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(276, 21);
            this.tb_Password.TabIndex = 5;
            this.tb_Password.Text = "Password";
            this.tb_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Password.Enter += new System.EventHandler(this.tb_Password_Enter);
            this.tb_Password.Leave += new System.EventHandler(this.tb_Password_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(74, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // tmr_Rotator
            // 
            this.tmr_Rotator.Interval = 1;
            this.tmr_Rotator.Tick += new System.EventHandler(this.tmr_Rotator_Tick);
            // 
            // lbl_ErrorOutput
            // 
            this.lbl_ErrorOutput.AutoSize = true;
            this.lbl_ErrorOutput.ForeColor = System.Drawing.Color.Red;
            this.lbl_ErrorOutput.Location = new System.Drawing.Point(24, 342);
            this.lbl_ErrorOutput.Name = "lbl_ErrorOutput";
            this.lbl_ErrorOutput.Size = new System.Drawing.Size(0, 13);
            this.lbl_ErrorOutput.TabIndex = 7;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(330, 415);
            this.Controls.Add(this.lbl_ErrorOutput);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_Username);
            this.Controls.Add(this.altoSlidingLabel1);
            this.Controls.Add(this.panel_grab);
            this.Controls.Add(this.btn_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.Text = "MainFrom";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panel_grab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AltoControls.AltoButton btn_Login;
        private System.Windows.Forms.Panel panel_grab;
        private AltoControls.AltoButton btn_Close;
        private AltoControls.AltoButton btn_Minimalize;
        private AltoControls.AltoSlidingLabel altoSlidingLabel1;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer tmr_Rotator;
        private System.Windows.Forms.Label lbl_ErrorOutput;
        public System.Windows.Forms.NotifyIcon NotyIcon;
    }
}

