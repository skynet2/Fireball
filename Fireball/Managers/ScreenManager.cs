﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Forms;

namespace Fireball.Managers
{
    internal static class ScreenManager
    {
        public static Image GetScreenshot()
        {
            // var result = GetScreenSize();
            // var f = System.Windows.SystemParameters.WorkArea;
            // var t = SystemInformation.VirtualScreen;
            // Image bmp = new Bitmap(result[0], result[1]);
            // using (Graphics g = Graphics.FromImage(bmp))
            // {
            //     g.CopyFromScreen(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top, 0, 0, bmp.Size);
            // }
            //// Image screen = ScreenshotCapture.TakeScreenshot();
            // var capt = new ScreenCapture();
            int screenLeft = SystemInformation.VirtualScreen.Left;
            int screenTop = SystemInformation.VirtualScreen.Top;
            int screenWidth = SystemInformation.VirtualScreen.Width;
            int screenHeight = SystemInformation.VirtualScreen.Height;

            // Create a bitmap of the appropriate size to receive the screenshot.
            Bitmap bmp = new Bitmap(screenWidth, screenHeight);
           
                // Draw the screenshot into our bitmap.
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(screenLeft, screenTop, 0, 0, bmp.Size);
                }

            return bmp;
        }

        public static int[] GetScreenSize()
        {
            int minx, miny, maxx, maxy;
            minx = miny = int.MaxValue;
            maxx = maxy = int.MinValue;

            foreach (Screen screen in Screen.AllScreens)
            {
                var bounds = screen.Bounds;
                minx = Math.Min(minx, bounds.X);
                miny = Math.Min(miny, bounds.Y);
                maxx = Math.Max(maxx, bounds.Right);
                maxy = Math.Max(maxy, bounds.Bottom);
            }
            return new[] {maxx - minx, maxy - miny};//width,height
        }
        public static Image CropImage(Image srcImage, Rectangle cropArea)
        {
            Image rtnImage = new Bitmap(cropArea.Width, cropArea.Height);

            /*using (Graphics gfx = Graphics.FromImage(rtnImage))
            {
                gfx.DrawImage(srcImage, -cropArea.X, -cropArea.Y);
            }*/

            using (Graphics gfx = Graphics.FromImage(rtnImage))
            {

                gfx.DrawImage(srcImage, 0, 0, cropArea, GraphicsUnit.Pixel);
            }
            //rtnImage.Save("crop.png",ImageFormat.Png);
            return rtnImage;
        }
    }
}
