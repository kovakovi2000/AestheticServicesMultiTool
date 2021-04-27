using AestheticServicesMultiTool.Properties;
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
        private static Color[,] SubImage;
        public static Color SaveWhite = Color.FromArgb(247, 247, 247);
        //private static Form OverLay = new Form();
        //private static Bitmap olRed;
        //private static Bitmap olBlue;
        //private static Bitmap olGreen;

        private static InputSimulator InSim = new InputSimulator();
        private static Random rnd = new Random();

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
            SubImage = RGBABytesToColorArray(GetRGBABytes(Resources.SkillSubImage));
        }

        private static bool WaitingForSkillCheck = false;
        private static Point SkillCheck = new Point(0, 0);
        private static void RefreshTick(object sender, EventArgs e)
        {
            Bitmap bitmap = capturearea(140, 140, 891, 470);
            Color[,] ColorArray = GetColorArray(bitmap);

            if (!WaitingForSkillCheck && 
                IsSkillcheck(ref ColorArray) &&
                (SkillCheck = GetSkillCheck(ref ColorArray)) != new Point(0, 0))
            {
                WaitingForSkillCheck = true;
                Console.WriteLine(SkillCheck.ToString());
                return;
            }
            if (WaitingForSkillCheck && !IsBright(ColorArray[SkillCheck.X, SkillCheck.Y], 250))
            {
                if (bHumanize)
                    Thread.Sleep(rnd.Next(50));

                InSim.Keyboard.KeyDown(VirtualKeyCode.SPACE);
                Thread.Sleep((rnd.Next(10) != 1) ? (50 + rnd.Next(50)) : (60 + rnd.Next(60)));
                InSim.Keyboard.KeyUp(VirtualKeyCode.SPACE);
                if (bShowPic)
                {
                    picbox_showpic.Image = bitmap;
                }
                WaitingForSkillCheck = false;
                Thread.Sleep(500);
            }
        }

        private static Color[,] GetColorArray(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            bmp.UnlockBits(bitmapData);
            IntPtr scan = bitmapData.Scan0;
            int abs = Math.Abs(bitmapData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[abs];
            Marshal.Copy(scan, rgbValues, 0, abs);
            Color[,] array = new Color[140, 140];
            int x = 0;
            int y = 0;
            for (int i = 0; i < rgbValues.Length; i += 4)
            {
                int avg = (rgbValues[i] + rgbValues[i + 1] + rgbValues[i + 2]) / 3;
                array[x, y] = SubImage[x, y].A != 255 ? Color.FromArgb(rgbValues[i + 3], rgbValues[i + 2], avg, avg) : Color.FromArgb(0,0,0,0);
                x++;
                if (x == 140)
                {
                    x = 0;
                    y++;
                }
            }
            return array;
        }

        private static bool IsSkillcheck(ref Color[,] colorArray)
        {
            if (
                    RGBSimularColor(colorArray[22, 59], Color.FromArgb(255, 237, 238, 238), 1) &&
                    RGBSimularColor(colorArray[23, 59], Color.FromArgb(255, 255, 255, 255), 1) &&
                    RGBSimularColor(colorArray[23, 58], Color.FromArgb(255, 247, 246, 246), 1) &&
                    RGBSimularColor(colorArray[24, 58], Color.FromArgb(255, 253, 253, 253), 1) &&
                    RGBSimularColor(colorArray[24, 57], Color.FromArgb(255, 253, 252, 252), 1) &&
                    RGBSimularColor(colorArray[25, 57], Color.FromArgb(255, 255, 255, 255), 1) &&
                    RGBSimularColor(colorArray[25, 58], Color.FromArgb(255, 202, 202, 202), 1)
               )
                return true;
            return false;
        }

        private static bool RGBSimularColor(Color color1, Color color2, int simularity)
        {
            if (
                    ((color1.R + simularity) >= color2.R && (color1.R - simularity) <= color2.R) &&
                    ((color1.G + simularity) >= color2.G && (color1.G - simularity) <= color2.G) &&
                    ((color1.B + simularity) >= color2.B && (color1.B - simularity) <= color2.B)
               )
                return true;
            return false;
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

        private static Color[,] RGBAMask(Color[,] image, Color[,] mask)
        {
            Color[,] output = new Color[image.GetLength(0), image.GetLength(1)];
            for (int x = 0; x < image.GetLength(0); x++)
                for (int y = 0; y < image.GetLength(1); y++)
                    if (mask[x, y].A == 255)
                        output[x, y] = Color.FromArgb(0, 0, 0, 0);
                    else
                        output[x, y] = image[x, y];
            return output;
        }

        private static Bitmap AGBtoBitmap(Color[,] image)
        {
            Bitmap bitmap = new Bitmap(image.GetLength(0), image.GetLength(1));
            for (int x = 0; x < image.GetLength(0); x++)
            {
                for (int y = 0; y < image.GetLength(1); y++)
                {
                    bitmap.SetPixel(x,y,image[x,y]);
                }
            }
            return bitmap;
        }

        private static Point GetSkillCheck(ref Color[,] ColorArray)
        {
            for (int i = 0; i < 136; i++)
                for (int j = 0; j < 136; j++)
                    if (IsBright(ColorArray[i, j], 250) && IsBright(ColorArray[i + 4, j], 250) && IsBright(ColorArray[i, j + 4], 250) && IsBright(ColorArray[i + 4, j + 4], 250))
                        return new Point(i+3, j+3);
            return new Point(0, 0);
        }

        private static Color[,] RGBABytesToColorArray(byte[] rgbValues)
        {
            Color[,] array = new Color[140, 140];
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < rgbValues.Length; i += 4)
            {
                int avg = (rgbValues[i] + rgbValues[i + 1] + rgbValues[i + 2]) / 3;
                Color color = (array[num, num2] = Color.FromArgb(rgbValues[i + 3], rgbValues[i+2], avg, avg));
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
