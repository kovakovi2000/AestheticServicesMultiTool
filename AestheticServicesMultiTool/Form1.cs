using AestheticServicesMultiTool.Properties;
using AltoControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AestheticServicesMultiTool
{
    public partial class Form1 : Form
    {
        private bool mov;
        private int movX;
        private int movY;
        private string _pass = "";
        private string _user = "";

        private bool _passEnter = false;
        private bool _userEnter = false;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.FromArgb(0,0,0,0);
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

        private void btn_Login_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Entered:\n" +
                $"Username:\"{(_userEnter ? tb_Username.Text : _user)}\"\n" +
                $"Password:\"{(_passEnter ? tb_Password.Text : _pass)}\"");
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
            _userEnter = true;
        }

        private void tb_Username_Leave(object sender, EventArgs e)
        {
            _user = ((TextBox)sender).Text;
            if (string.IsNullOrEmpty(_user))
                ((TextBox)sender).Text = "Username";
            _userEnter = false;
        }

        private void tb_Password_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).PasswordChar = '•';
            ((TextBox)sender).Text = _pass;
            _passEnter = true;
        }

        private void tb_Password_Leave(object sender, EventArgs e)
        {
            _pass = ((TextBox)sender).Text;
            if (string.IsNullOrEmpty(_pass))
            {
                ((TextBox)sender).Text = "Password";
                ((TextBox)sender).PasswordChar = '\0';
            }
            _passEnter = false;
        }
    }
}
