using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Edge_detection
{
    internal class ConvertToColor
    {
        internal static Bitmap RGB(Bitmap image, string color)
        {
            //Use the LockBits method to improve performance by locking the images' data into memory(RAM)
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            Bitmap coloredImage = new(image.Width, image.Height);
            BitmapData coloredData = coloredImage.LockBits(new Rectangle(0, 0, coloredImage.Width, coloredImage.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            //Create arrays for the pixel values of the images
            int bytes = imageData.Stride * imageData.Height;
            byte[] pixelBuffer = new byte[bytes];
            byte[] resultBuffer = new byte[bytes];

            //Copy the data from your image into your array
            Marshal.Copy(imageData.Scan0, pixelBuffer, 0, bytes);

            //Unlock the image data from memory
            image.UnlockBits(imageData);

            //Use an Action variable with a switch to avoid repeated code
            Action<int> processPixel = color switch
            {
                //Assign the original images pixel value to retain only the wanted color
                "Red" => j =>
                {
                    int i = j * 4;
                    resultBuffer[i] = 0;
                    resultBuffer[i + 1] = 0;
                    resultBuffer[i + 2] = pixelBuffer[i + 2];
                    resultBuffer[i + 3] = 255;
                },

                "Green" => j =>
                {
                    int i = j * 4;
                    resultBuffer[i] = 0;
                    resultBuffer[i + 1] = pixelBuffer[i + 1];
                    resultBuffer[i + 2] = 0;
                    resultBuffer[i + 3] = 255;
                },

                "Blue" => j =>
                {
                    int i = j * 4;
                    resultBuffer[i] = pixelBuffer[i];
                    resultBuffer[i + 1] = 0;
                    resultBuffer[i + 2] = 0;
                    resultBuffer[i + 3] = 255;
                },

                _ => throw new ArgumentException("Invalid color specified.")
            };

            //Use Parallel.For to make use of the multiple cores/threads if any on a cpu
            Parallel.For(0, bytes / 4, processPixel);

            Marshal.Copy(resultBuffer, 0, coloredData.Scan0, bytes);

            coloredImage.UnlockBits(coloredData);

            return coloredImage;
        }
    }
}
