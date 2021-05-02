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
    }
}
