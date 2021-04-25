using AestheticServicesMultiTool.Properties;
using AltoControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace AestheticServicesMultiTool
{
    public partial class FormLogin : Form
    {
        private bool mov;
        private int movX;
        private int movY;
        private string _pass = "";
        private string _user = "";

        FormMain fmain;

        public FormLogin()
        {
            InitializeComponent();
            lbl_ErrorOutput.BackColor = Color.FromArgb(0, 0, 0, 0);
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0, 0);
            NotyIcon.ContextMenu = new ContextMenu(
                        new MenuItem[]
                        {
                            new MenuItem("Show", Show),
                            new MenuItem("-"),
                            new MenuItem("Exit", Exit)
                        });
        }

        void Show(object sender, EventArgs e)
        {
            NotyIcon.Visible = false;
            this.Visible = true;
        }

        void Exit(object sender, EventArgs e)
        {
            NotyIcon.Visible = false;
            Application.Exit();
        }
        delegate void SetForeColor(Control control, Color color);
        private void SetControlForeColor(Control control, Color color)
        {
            if (control.InvokeRequired)
            {
                SetForeColor d = new SetForeColor(SetControlForeColor);
                this.BeginInvoke(d, new object[] { control, color });
            }
            else
                control.BackColor = color;
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
                    SetControlForeColor(control, Color.Red);
                    Thread.Sleep(200);
                    SetControlForeColor(control, Color.White);
                    Thread.Sleep(200);
                }
            }).Start();
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
            NotyIcon.Visible = false;
            this.Show();
        }

        private void panel_grab_MouseDown(object sender, MouseEventArgs e)
        {
            mov = true;
            movX = e.X;
            movY = e.Y;
        }

        private void panel_grab_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov)
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
        }

        private void panel_grab_MouseUp(object sender, MouseEventArgs e)
        {
            mov = false;
        }

        private void tb_Username_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = _user;
        }

        private void tb_Username_Leave(object sender, EventArgs e)
        {
            _user = ((TextBox)sender).Text;
            if (string.IsNullOrEmpty(_user))
                ((TextBox)sender).Text = "Username";
        }

        private void tb_Password_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).PasswordChar = '•';
            ((TextBox)sender).Text = _pass;
        }

        private void tb_Password_Leave(object sender, EventArgs e)
        {
            _pass = ((TextBox)sender).Text;
            if (string.IsNullOrEmpty(_pass))
            {
                ((TextBox)sender).Text = "Password";
                ((TextBox)sender).PasswordChar = '\0';
            }
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
    }
}
