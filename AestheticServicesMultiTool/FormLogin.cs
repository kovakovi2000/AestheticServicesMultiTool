using AestheticServicesMultiTool.Lib;
using AestheticServicesMultiTool.Properties;
using AltoControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace AestheticServicesMultiTool
{
    public partial class FormLogin : Form
    {
        private string UserRegex = @"^[A-Za-z0-9_.\-]+$";

        private bool Logined = false;

        FormMain fmain;

        public FormLogin()
        {
            InitializeComponent();
            this.btn_register.Enter += new System.EventHandler(Lib.UIEvent.ctrl_Enter);
            this.btn_register.Leave += new System.EventHandler(Lib.UIEvent.ctrl_Leave);
            this.tb_Password.Enter += new System.EventHandler(Lib.UIEvent.tb_Enter);
            this.tb_Password.Leave += new System.EventHandler(Lib.UIEvent.tb_Leave);
            this.tb_Username.Enter += new System.EventHandler(Lib.UIEvent.tb_Enter);
            this.tb_Username.Leave += new System.EventHandler(Lib.UIEvent.tb_Leave);
            this.btn_Login.Enter += new System.EventHandler(Lib.UIEvent.ctrl_Enter);
            this.btn_Login.Leave += new System.EventHandler(Lib.UIEvent.ctrl_Leave);
            this.panel_grab.MouseDown += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseDown);
            this.panel_grab.MouseMove += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseMove);
            this.panel_grab.MouseUp += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseUp);

            lbl_ErrorOutput.BackColor = Color.FromArgb(0, 0, 0, 0);
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0, 0);
            NotyIcon.ContextMenu = new ContextMenu(
                        new MenuItem[]
                        {
                            new MenuItem("Show", iShow),
                            new MenuItem("-"),
                            new MenuItem("Exit", iExit)
                        });
            Console.WriteLine("\n\n---------------------------------------------------\n\n");
            bool suc;
            Console.WriteLine(LocalSecurity.FingerPrint.Value(out suc));
            Console.WriteLine("\n" + suc);
            Console.WriteLine("\n\n---------------------------------------------------\n\n");
        }

        private void iShow(object sender, EventArgs e)
        {
            NotyIcon.Visible = false;
            if (Logined)
            {
                fmain.Show();
                this.Hide();
            }
            else
                this.Show();

        }

        private void iExit(object sender, EventArgs e)
        {
            NotyIcon.Visible = false;
            Application.Exit();
        }
        delegate void SetBackColor(Control control, Color color);
        private void SetControlBackColor(Control control, Color color)
        {
            if (control.InvokeRequired)
            {
                SetBackColor d = new SetBackColor(SetControlBackColor);
                this.BeginInvoke(d, new object[] { control, color });
            }
            else
                control.BackColor = color;
        }

        private void SetAltoBackColor(Control control, Color color)
        {
            if (control.InvokeRequired)
            {
                SetBackColor d = new SetBackColor(SetAltoBackColor);
                this.BeginInvoke(d, new object[] { control, color });
            }
            else
                ((AltoTextBox)control).Br = color;
        }

        delegate void SetEnable(Control control, bool enable);
        private void SetControlEnable(Control control, bool enable)
        {
            if (control.InvokeRequired)
            {
                SetEnable d = new SetEnable(SetControlEnable);
                this.BeginInvoke(d, new object[] { control, enable });
            }
            else
                control.Enabled = enable;
        }

        private void BlinkRedBackColor(Control control)
        {
            new Thread(() => 
            {
                for (int i = 0; i < 3; i++)
                {
                    SetControlBackColor(control, Color.Red);
                    //SetAltoBackColor(Controls[Controls.IndexOfKey(control.Name + "_bg")], Color.Red);
                    Thread.Sleep(200);
                    SetControlBackColor(control, Color.White);
                    //SetAltoBackColor(Controls[Controls.IndexOfKey(control.Name + "_bg")], Color.White);
                    Thread.Sleep(200);
                }
            }).Start();
        }

        private object getTextBoxGB(TextBox textbox)
        {
            foreach (Control item in Controls)
                if ((textbox.Name + "_bg") == item.Name)
                    return item;
            return null;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            lbl_ErrorOutput.Text = "\0";
            if (tb_Password.Text.Length < 10)
            {
                lbl_ErrorOutput.Text = "The password is too short (minimum 10)";
                BlinkRedBackColor(tb_Password);
                return;
            }
            if (tb_Username.Text.Length < 4)
            {
                lbl_ErrorOutput.Text = "The username is too short (minimum 4)";
                BlinkRedBackColor(tb_Username);
                return;
            }
            if (tb_Password.Text.Length > 32)
            {
                lbl_ErrorOutput.Text = "The password is too long (maximum 32)";
                BlinkRedBackColor(tb_Password);
                return;
            }
            if (tb_Username.Text.Length > 32)
            {
                lbl_ErrorOutput.Text = "The username is too long (maximum 32)";
                BlinkRedBackColor(tb_Username);
                return;
            }

            StartAccountCheck(tb_Username.Text, tb_Password.Text);
            //MessageBox.Show($"Entered:\n" +
            //    $"Username:\"{(_userEnter ? tb_Username.Text : _user)}\"\n" +
            //    $"Password:\"{(_passEnter ? tb_Password.Text : _pass)}\"");
        }

        private void StartAccountCheck(string Username, string Password)
        {
            //temp for test
            Thread Main = Thread.CurrentThread;
            Rotate(true);
            new Thread(() => LoginCheck(Username, Password)).Start();
        }

        #region RotationLogo
        private void Rotate(bool DoRotate)
        {
            if (DoRotate)
            {
                SafelyCallMeFromAnyThread(new Action(() => tmr_Rotator.Start()));
                SetControlEnable(btn_Login, false);
                SetControlEnable(tb_Username, false);
                SetControlEnable(tb_Password, false);
                tb_Username.BackColor = Color.White;
                tb_Password.BackColor = Color.White;
            }
            else
            {
                SetControlEnable(btn_Login, true);
                SetControlEnable(tb_Username, true);
                SetControlEnable(tb_Password, true);

                SafelyCallMeFromAnyThread(new Action(() => tmr_Rotator.Stop()));
                pictureBox1.Image = Resources.AC_Neon_Logo_png_3_rak;
            }
        }

        int RotationLoop = 0;
        private void tmr_Rotator_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = RotateImageN(Resources.AC_Neon_Logo_png_3_rak, RotationLoop += 2);
        }
        #endregion

        Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
        public void SafelyCallMeFromAnyThread(Action a)
        {
            dispatcher.Invoke(a);
        }
        private void LoginCheck(string username, string password)
        {
            
            Thread.Sleep(5000);
            if (username == "Kova" && password == "asd123asd123")
            {
                SafelyCallMeFromAnyThread(new Action(() => 
                {
                    fmain = new FormMain(this);
                    Logined = true;
                    fmain.Show();
                    this.Hide();
                }));
                Rotate(false);
            }
            else
            {
                Rotate(false);
                MessageBox.Show("Incorrect");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            NotyIcon.Visible = false;
            Application.Exit();
        }

        private void btn_Minimalize_Click(object sender, EventArgs e)
        {
            this.Hide();
            NotyIcon.Visible = true;
        }

        private void Icon_MouseClick(object sender, MouseEventArgs e)
        {
            iShow(sender, e);
        }

        public static Bitmap RotateImageN(Bitmap b, float angle)
        {
            //Create a new empty bitmap to hold rotated image.
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //Make a graphics object from the empty bitmap.
            Graphics g = Graphics.FromImage(returnBitmap);
            //move rotation point to center of image.
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //Rotate.        
            g.RotateTransform(angle);
            //Move image back.
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //Draw passed in image onto graphics object.
            //Found ERROR 1: Many people do g.DwarImage(b,0,0); The problem is that you re giving just the position
            //Found ERROR 2: Many people do g.DrawImage(b, new Point(0,0)); The size still not present hehe :3

            g.DrawImage(b, 0, 0, b.Width, b.Height);  //My Final Solution :3
            return returnBitmap;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Console.WriteLine("\nOpenSSL");
            Console.WriteLine(System.Web.HttpUtility.UrlEncode(Crypto.OpenSSL_CBC.EncryptString("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec faucibus, urna vel rhoncus faucibus, odio massa tempor velit, efficitur malesuada sem leo eu lacus. Etiam laoreet laoreet consectetur. Vestibulum nec magna eget quam convallis semper ac eu ligula. Nunc ante libero, tincidunt ac blandit quis, tempor ut nulla. Donec aliquet lorem eu est finibus, id lobortis diam accumsan. Integer maximus sem id lacinia ultricies. Vestibulum molestie odio at fringilla euismod. Morbi ultricies justo vel ipsum feugiat mattis. Morbi suscipit sed tortor nec interdum. Vivamus quam mi, sollicitudin id viverra in, sodales a nulla. Sed porta aliquet erat, a scelerisque nulla ullamcorper et. Quisque mattis varius nibh, id fringilla massa tincidunt id.")));
            Console.WriteLine(Crypto.OpenSSL_CBC.DecryptString("/2ssGbvgNlkqzRoSHcIU6A=="));

            Console.WriteLine("\nOrderedShuffle");
            Console.WriteLine(System.Web.HttpUtility.UrlEncode(Crypto.OrderedShuffle.EncryptString("Ez egy szoveg")));
            Console.WriteLine(Crypto.OrderedShuffle.DecryptString("AsEJarElsgpJa"));
            //MessageBox.Show(GetHWIDsCheckLink());
            fmain = new FormMain(this);
            Logined = true;
            fmain.Show();
            this.Hide();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            new FormRegister().ShowDialog();
        }

        //private void tb_Enter(object sender, EventArgs e)
        //{
        //    if (((TextBox)sender).Text == ((TextBox)sender).Name.Substring(3).Replace("_", " "))
        //        ((TextBox)sender).Text = string.Empty;
        //    if (((TextBox)sender).Name.Contains("Pass"))
        //        ((TextBox)sender).PasswordChar = '•';
        //}

        //private void tb_Leave(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(((TextBox)sender).Text))
        //    {
        //        ((TextBox)sender).Text = ((TextBox)sender).Name.Substring(3).Replace("_", " ");
        //        if (((TextBox)sender).Name.Contains("Pass"))
        //            ((TextBox)sender).PasswordChar = '\0';
        //    }
        //}

        private void tb_BackColorChanged(object sender, EventArgs e)
        {
            (Controls[Controls.IndexOfKey((sender as TextBox).Name + "_bg")] as AltoTextBox).Br = (sender as TextBox).BackColor;
        }
    }
}