using AestheticServicesMultiTool.Properties;
using AestheticServicesMultiTool.Tools;
using AltoControls;
using Siticone.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
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
            this.pnl_grab.MouseDown += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseDown);
            this.pnl_grab.MouseMove += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseMove);
            this.pnl_grab.MouseUp += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseUp);
            this.pictureBox10.MouseDown += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseDown);
            this.pictureBox10.MouseMove += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseMove);
            this.pictureBox10.MouseUp += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseUp);
            this.pictureBox9.MouseDown += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseDown);
            this.pictureBox9.MouseMove += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseMove);
            this.pictureBox9.MouseUp += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseUp);
            this.tb_BloodPoint.Enter += new System.EventHandler(Lib.UIEvent.tb_Enter);
            this.tb_BloodPoint.Leave += new System.EventHandler(Lib.UIEvent.tb_Leave);
        }

        private void btn_tab_Click(object sender, EventArgs e)
        {
            //foreach (Control item in pnl_tabs.Controls)
            //    if (item.Name.StartsWith("btn_tab_"))
            //        ((SiticoneButton)item).ForeColor = SkillCheckBot.SaveWhite;
            //((SiticoneButton)sender).ForeColor = Color.FromArgb(192, 0, 192);

            pcb_Selected.Location = ((SiticoneButton)sender).Location;
            tabCtrl.SelectedIndex = ((SiticoneButton)sender).Location.Y / 63;
            lbl_Tittle.Text = ((SiticoneButton)sender).Text;
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
            picbox_rc_SurvivalRank.Image = RankChanger.Img_RankSurvival[RankChanger.RankSurvival];
            picbox_rc_KillerRank.Image = RankChanger.Img_RankKiller[RankChanger.RankKiller];
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

        private void SetSliderText(AltoControls.SlideButton button, bool staydisabled = false)
        {
            button.Enabled = false;
            
            new Thread(() =>
            {
                Thread.Sleep(300);
                if(!staydisabled) SetControlEnable(button, true);
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

        private void tb_BloodPoint_TextChanged(object sender, EventArgs e)
        {
            int temp = 0;
            if (int.TryParse((sender as TextBox).Text, out temp))
            {
                if (temp > 1000000)
                    ((TextBox)sender).Text = 1000000.ToString();
                else if(temp < 0)
                    ((TextBox)sender).Text = 0.ToString();

                BloodPointModifier.BloodPoint = temp;
            }
            else
            {
                if (((TextBox)sender).Name.Substring(3).Replace("_", " ") != ((TextBox)sender).Text)
                    ((TextBox)sender).Text = "";
            }
        }

        private void sldbtn_ec_Click(object sender, EventArgs e)
        {
            foreach (Control item in (sender as Control).Parent.Controls)
                if (item != sender && item.Name.StartsWith("sldbtn_ec_"))
                {
                    (item as SlideButton).IsOn = false;
                    SetSliderText((SlideButton)item);
                }
            SetSliderText((SlideButton)sender, true);
        }

        private void btn_rc_SurvivalRank_Right_Click(object sender, EventArgs e)
        {
            RankChanger.RankSurvival++;
            if (RankChanger.RankSurvival > 19)
                RankChanger.RankSurvival = 0;
            picbox_rc_SurvivalRank.Image = RankChanger.Img_RankSurvival[RankChanger.RankSurvival];
        }
        
        private void btn_rc_SurvivalRank_Left_Click(object sender, EventArgs e)
        {
            RankChanger.RankSurvival--;
            if (RankChanger.RankSurvival < 0)
                RankChanger.RankSurvival = 19;
            picbox_rc_SurvivalRank.Image = RankChanger.Img_RankSurvival[RankChanger.RankSurvival];
        }

        private void btn_rc_KillerRank_Right_Click(object sender, EventArgs e)
        {

        }
        private void btn_rc_KillerRank_Left_Click(object sender, EventArgs e)
        {
            RankChanger.RankKiller--;
            if (RankChanger.RankKiller < 0)
                RankChanger.RankKiller = 19;
            picbox_rc_KillerRank.Image = RankChanger.Img_RankKiller[RankChanger.RankKiller];
        }

        private void rdbtn_ec_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as SiticoneCustomRadioButton).Checked)
                foreach (Control item in (sender as Control).Parent.Controls)
                {
                    if (item != sender && item.Name == "lbl_" + (sender as Control).Name)
                    {
                        item.ForeColor = Color.Lime;
                        break;
                    }
                }
            else
                foreach (Control item in (sender as Control).Parent.Controls)
                {
                    if (item != sender && item.Name == "lbl_" + (sender as Control).Name)
                    {
                        item.ForeColor = SkillCheckBot.SaveWhite;
                        break;
                    }
                }
        }

        private bool VisibleID = false;
        private void picbox_si_VisibleID_Click(object sender, EventArgs e)
        {
            VisibleID = !VisibleID;
            if (VisibleID)
            {
                (sender as PictureBox).Image = Resources.VisibleIconActive;
                tb_si_UserID.PasswordChar = '\0';
            }
            else
            {
                (sender as PictureBox).Image = Resources.VisibleIcon;
                tb_si_UserID.PasswordChar = '•';
            }
        }

        private Bitmap ToColorTone(Image image, Color? color = null, float brightness = 1.0f)
        {
            //creating a new bitmap image with selected color.
            float scale = 1f;

            float r = (color ?? Color.Black).R / 255f * scale;
            float g = (color ?? Color.Black).G / 255f * scale;
            float b = (color ?? Color.Black).B / 255f * scale;

            // Color Matrix
            float adjustedBrightness = brightness - 1.0f;
            ColorMatrix cm = new ColorMatrix(new float[][]
            {
                new float[] {r, 0, 0, 0, 0},
                new float[] {0, g, 0, 0, 0},
                new float[] {0, 0, b, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1 }
            });
            ImageAttributes ImAttribute = new ImageAttributes();
            ImAttribute.SetColorMatrix(cm);

            //Color Matrix on new bitmap image
            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width - 1, 0),
                new Point(0, image.Height - 1),
            };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            Bitmap myBitmap = new Bitmap(image.Width, image.Height);
            using (Graphics graphics = Graphics.FromImage(myBitmap))
            {
                graphics.DrawImage(image, points, rect, GraphicsUnit.Pixel, ImAttribute);
            }
            return myBitmap;
        }

        private void picbox_si_VisibleID_MouseEnter(object sender, EventArgs e)
        {
            if (VisibleID)
            {
                (sender as PictureBox).Image = ToColorTone(Resources.VisibleIconActive, null, 1.1f);
            }
            else
            {
                (sender as PictureBox).Image = ToColorTone(Resources.VisibleIcon, null, 1.1f);
            }
        }

        private void picbox_si_VisibleID_MouseLeave(object sender, EventArgs e)
        {
            if (VisibleID)
            {
                (sender as PictureBox).Image = Resources.VisibleIconActive;
            }
            else
            {
                (sender as PictureBox).Image = Resources.VisibleIcon;
            }
        }

        private void btn_si_CustomAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "dbd save files (*.txt, *.json)|*.txt;*.json";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                tb_si_CustomPath.Text = selectedFileName;
            }
        }
    }
}
