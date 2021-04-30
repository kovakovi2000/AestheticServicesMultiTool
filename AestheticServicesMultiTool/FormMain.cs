using AestheticServicesMultiTool.Tools;
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
            tabCtrl.SelectedIndex = ((Button)sender).Location.Y / 63;
        }

        private void btn_tab_Click(object sender, EventArgs e)
        {
            foreach (Control item in pnl_tabs.Controls)
                if (item.Name.StartsWith("btn_tab_"))
                    ((Button)item).ForeColor = SkillCheckBot.SaveWhite;

            SetButtonSelected(sender);
            lbl_Tittle.Text = ((Button)sender).Text.Substring(15);
        }

        private void pnl_grab_MouseDown(object sender, MouseEventArgs e)
        {
            mov = true;
            movX = e.X + ((Control)sender).Location.X;
            movY = e.Y + ((Control)sender).Location.Y;
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

        private void FormMain_Load(object sender, EventArgs e)
        {
            TempUnlock.StatusUpdate += UnlockUpdateTest;
        }

        internal void UnlockUpdateTest(TempUnlock.eStatus status)
        {
            //I'm not sure is this need an Invoker
            lbl_ul_status.Text = $"Status: {status}";
            //throw new NotImplementedException();
        }

        private void sldbtn_scb_Enable_Click(object sender, EventArgs e)
        {
            SetSliderText((AltoControls.SlideButton)sender);
            SkillCheckBot.picbox_showpic = picbox_scb_showpic;
            SkillCheckBot.iRefreshRate = tbar_scb_refreshrate.Value;
            SkillCheckBot.BEnable = ((AltoControls.SlideButton)sender).IsOn;
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

        private void SetSliderText(AltoControls.SlideButton button)
        {
            button.Enabled = false;
            new Thread(() =>
            {
                Thread.Sleep(200);
                SetControlEnable(button, true);
            }).Start();
            if (button.IsOn)
            {
                foreach (Control item in button.Parent.Controls)
                    if (item.Name == ("lbl_" + button.Name))
                    {
                        ((Label)item).ForeColor = Color.Lime;
                        return;
                    }
            }
            else
            {
                foreach (Control item in button.Parent.Controls)
                    if (item.Name == ("lbl_" + button.Name))
                    {
                        ((Label)item).ForeColor = SkillCheckBot.SaveWhite;
                        return;
                    }
            }
        }

        private void tbar_scb_refreshrate_Scroll(object sender, EventArgs e)
        {
            if (((TrackBar)sender).Value < 5)
                ((TrackBar)sender).Value = 5;
            lbl_scb_refreshrate.Text = $"Refresh frame rate: {((TrackBar)sender).Value}fps";
            SkillCheckBot.iRefreshRate = ((TrackBar)sender).Value;
        }

        private void sldbtn_scb_humanize_Click(object sender, EventArgs e)
        {
            SetSliderText((AltoControls.SlideButton)sender);
            SkillCheckBot.bHumanize = ((AltoControls.SlideButton)sender).IsOn;
        }

        private void sldbtn_scb_overlay_Click(object sender, EventArgs e)
        {
            SetSliderText((AltoControls.SlideButton)sender);
            SkillCheckBot.bOverlay = ((AltoControls.SlideButton)sender).IsOn;
        }

        private void sldbtn_scb_showpicture_Click(object sender, EventArgs e)
        {
            SetSliderText((AltoControls.SlideButton)sender);
            SkillCheckBot.BShowPic = ((AltoControls.SlideButton)sender).IsOn;
        }

        private void btn_cg_grab_Click(object sender, EventArgs e)
        {
            tb_cg_cookie.Text = CookieGrab.Grab();
        }

        private void sldbtn_fm_Enable_Click(object sender, EventArgs e)
        {
            SetSliderText((AltoControls.SlideButton)sender);
            if (((AltoControls.SlideButton)sender).IsOn)
                TempUnlock.Proxy.StartProxy();
            else
                TempUnlock.Proxy.StopProxy();
        }

        private void btn_ul_Launch_Click(object sender, EventArgs e)
        {
            TempUnlock.LaunchGame();
        }
    }
}
