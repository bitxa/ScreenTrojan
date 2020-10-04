using System;
using System.Drawing;
using System.Drawing.Imaging;


namespace ScreenTrojan
{
   public class Screenshot
    {
        public Image FullScreenshotWithClass(String filepath, String filename, ImageFormat format)
        {
            ScreenCapture sc = new ScreenCapture();
            Image img = sc.CaptureScreen();

            string fullpath = filepath + "\\" + filename;

            img.Save(fullpath, format);
            return img;
            
        }

       
    // Y usalo de la siguiente manera:

} }
