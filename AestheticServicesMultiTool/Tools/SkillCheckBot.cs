using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace AestheticServicesMultiTool.Tools
{
    static class SkillCheckBot
    {
        public static Color SaveWhite = Color.FromArgb(247, 247, 247);

        private static InputSimulator InSim = new InputSimulator();
        private static Random rnd = new Random();
        private static bool WaitingForSkillCheck = false;

        public static int iRefreshRate = 60;

        public static bool bHumanize = true;
        private static bool bShowPic = false;
        public static bool bOverlay = false;

        public static PictureBox picbox_showpic;

        private static System.Windows.Forms.Timer tmr_fa = new System.Windows.Forms.Timer();

        public static bool BEnable 
        { 
            get => tmr_fa.Enabled; 
            set
            {
                tmr_fa.Interval = 1000 / iRefreshRate;
                if (value)
                    tmr_fa.Start();
                else
                    tmr_fa.Stop();

            } 
        }

        public static bool BShowPic 
        { 
            get => bShowPic; 
            set 
            { 
                bShowPic = value;
                if (!value && picbox_showpic != null)
                    picbox_showpic.Image = new Bitmap(1, 1);
            } 
        }

        static SkillCheckBot()
        {
            tmr_fa.Tick += new EventHandler(RefreshTick);
        }

        private static void RefreshTick(object sender, EventArgs e)
        {
            if (GetSkillCheck() != new Point(0, 0))
            {
                WaitingForSkillCheck = true;
                return;
            }
            if (WaitingForSkillCheck)
            {
                if (bHumanize)
                {
                    Thread.Sleep(rnd.Next(50));
                }
                InSim.Keyboard.KeyDown(VirtualKeyCode.SPACE);
                Thread.Sleep((rnd.Next(10) != 1) ? (50 + rnd.Next(50)) : (60 + rnd.Next(60)));
                InSim.Keyboard.KeyUp(VirtualKeyCode.SPACE);
                if (bShowPic)
                {
                    picbox_showpic.Image = capturearea(140, 140, 891, 470);
                }
                WaitingForSkillCheck = false;
                Thread.Sleep(500);
            }
        }

        private static Bitmap capturearea(int width, int height, int x, int y)
        {
            Control control = new Control();
            control.ClientSize = new Size(width, height);
            control.Location = new Point(x - 8, y - 30);
            Size clientSize = control.ClientSize;
            Bitmap bitmap = new Bitmap(clientSize.Width, clientSize.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(control.PointToScreen(new Point(0, 0)), new Point(0, 0), new Size(clientSize.Width, clientSize.Height));
            return bitmap;
        }
        private static bool IsBright(Color color, int brightness = 248)
        {
            if (color.R > brightness && color.G > brightness && color.B > brightness)
            {
                return true;
            }
            return false;
        }
        private static Point GetSkillCheck()
        {
            Bitmap bitmap = capturearea(140, 140, 891, 470);
            byte[] rGBABytes = GetRGBABytes(bitmap);
            Color[,] array = RGBABytesToColorArray(rGBABytes);
            for (int i = 0; i < 136; i++)
            {
                for (int j = 0; j < 136; j++)
                {
                    if (IsBright(array[i, j], 250) && IsBright(array[i + 4, j], 250) && IsBright(array[i, j + 4], 250) && IsBright(array[i + 4, j + 4], 250))
                    {
                        bitmap.SetPixel(i, j, Color.Red);
                        bitmap.SetPixel(i + 4, j, Color.Red);
                        bitmap.SetPixel(i, j + 4, Color.Red);
                        bitmap.SetPixel(i + 4, j + 4, Color.Red);
                        return new Point(891 + i, 470 + j);
                    }
                }
            }
            return new Point(0, 0);
        }
        private static Color[,] RGBABytesToColorArray(byte[] rgbValues)
        {
            Color[,] array = new Color[140, 140];
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < rgbValues.Length; i += 4)
            {
                Color color = (array[num, num2] = Color.FromArgb(rgbValues[i], rgbValues[i + 1], rgbValues[i + 2], rgbValues[i + 3]));
                num++;
                if (num == 140)
                {
                    num = 0;
                    num2++;
                }
            }
            return array;
        }

        private static byte[] GetRGBABytes(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            bmp.UnlockBits(bitmapData);
            IntPtr scan = bitmapData.Scan0;
            int num = Math.Abs(bitmapData.Stride) * bmp.Height;
            byte[] array = new byte[num];
            Marshal.Copy(scan, array, 0, num);
            return array;
        }
    }
}
