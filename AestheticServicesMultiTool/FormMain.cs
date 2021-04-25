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
    public partial class FormMain : Form
    {
        private bool mov;
        private int movX;
        private int movY;
        private FormLogin flogin;
        public FormMain(FormLogin flogin)
        {
            this.flogin = flogin;
            InitializeComponent();
        }

        private void SetButtonSelected(object sender)
        {
            pcb_Selected.Location = ((Button)sender).Location;
            ((Button)sender).ForeColor = Color.FromArgb(192, 0, 192);
        }

        private void btn_tab_Click(object sender, EventArgs e)
        {
            foreach (Control item in pnl_tabs.Controls)
                if (item.Name.StartsWith("btn_tab_"))
                    ((Button)item).ForeColor = Color.White;

            SetButtonSelected(sender);
            lbl_Tittle.Text = ((Button)sender).Text.Substring(15);
        }

        private void pnl_grab_MouseDown(object sender, MouseEventArgs e)
        {
            mov = true;
            movX = e.X;
            movY = e.Y;
        }

        private void pnl_grab_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov)
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
        }

        private void pnl_grab_MouseUp(object sender, MouseEventArgs e)
        {
            mov = false;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            flogin.NotyIcon.Visible = false;
            Application.Exit();
        }

        private void btn_Minimalize_Click(object sender, EventArgs e)
        {
            this.Hide();
            flogin.NotyIcon.Visible = true;
        }
    }
}
