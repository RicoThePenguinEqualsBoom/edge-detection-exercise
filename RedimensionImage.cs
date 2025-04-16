using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edge_detection
{
    internal class RedimensionImage
    {
        internal static Bitmap ScaleImage(Bitmap image, int resizeTo)
        {
            double ratio;
            int newWidth, newHeight;

            //If image is square and one side is equal to the resizing value then no need for resizing else just resize one side
            //Can be modified with a switch to determine which side to resize
            if (image.Width == image.Height)
            {
                if (image.Width == resizeTo) { return image; }
                else
                {
                    ratio = (double)resizeTo / image.Width;
                    newWidth = newHeight = (int)(ratio * image.Width);
                }
            }
            else
            {
                //Using whichever side is larger and the resizing value,
                //determine how much smaller the smaller side needs to be
                if (image.Width > image.Height)
                {
                    ratio = (double)resizeTo / image.Width;
                    newHeight = (int)(ratio * image.Height);
                    newWidth = resizeTo;
                }
                else
                {
                    ratio = (double)resizeTo / image.Height;
                    newWidth = (int)(ratio * image.Width);
                    newHeight = resizeTo;
                }
            }

            //Use the new sizes to create a new image and use the system.drawing Nuget to map the original onto it
            Bitmap resizedImage = new(newWidth, newHeight);
            using (var g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            image.Dispose();
            return resizedImage;
        }
    }
}
