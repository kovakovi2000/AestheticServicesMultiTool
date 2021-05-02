using AltoControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AestheticServicesMultiTool.Lib
{
    static class UIEvent
    {
        internal static void tb_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == ((TextBox)sender).Name.Substring(3).Replace("_", " "))
                ((TextBox)sender).Text = string.Empty;
            if (((TextBox)sender).Name.Contains("Pass"))
                ((TextBox)sender).PasswordChar = '•';
        }

        internal static void tb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = ((TextBox)sender).Name.Substring(3).Replace("_", " ");
                if (((TextBox)sender).Name.Contains("Pass"))
                    ((TextBox)sender).PasswordChar = '\0';
            }
        }

        internal static void ctrl_Enter(object sender, EventArgs e)
        {
            (sender as Control).ForeColor = Color.Gray;
        }

        internal static void ctrl_Leave(object sender, EventArgs e)
        {
            (sender as Control).ForeColor = Color.White;
        }

        private static bool mov;
        private static int movX;
        private static int movY;

        internal static void panel_grab_MouseDown(object sender, MouseEventArgs e)
        {
            mov = true;
            movX = e.X + ((Control)sender).Location.X;
            movY = e.Y + ((Control)sender).Location.Y;
        }

        internal static void panel_grab_MouseMove(object sender, MouseEventArgs e)
        {
            Form form = (sender as Control).FindForm();
            if (mov)
                form.SetDesktopLocation(Control.MousePosition.X - movX, Control.MousePosition.Y - movY);
        }

        internal static void panel_grab_MouseUp(object sender, MouseEventArgs e)
        {
            mov = false;
        }
    }
}
