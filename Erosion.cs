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
    internal class Erosion
    {
        internal static Bitmap Erode(Bitmap image, int matrixSize = 3)
        {
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            Bitmap erodedImage = new(image.Width, image.Height);
            BitmapData resultData = erodedImage.LockBits(new Rectangle(0, 0, erodedImage.Width, erodedImage.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int bytes = imageData.Stride * imageData.Height;
            byte[] pixelBuffer = new byte[bytes];

            byte[] resultBuffer = new byte[bytes];

            Marshal.Copy(imageData.Scan0, pixelBuffer, 0, bytes);
            image.UnlockBits(imageData);

            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset;
            int byteOffset;
            int imageStride = imageData.Stride;

            byte blue;
            byte green;
            byte red;

            for (int offsetY = filterOffset; offsetY < image.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < image.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY * imageStride + offsetX * 4;

                    blue = 255;
                    green = 255;
                    red = 255;

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset + (filterX * 4) + (filterY * imageStride);

                            blue = Math.Min(blue, pixelBuffer[calcOffset]);
                            green = Math.Min(green, pixelBuffer[calcOffset + 1]);
                            red = Math.Min(red, pixelBuffer[calcOffset + 2]);
                        }
                    }

                    resultBuffer[byteOffset] = blue;
                    resultBuffer[byteOffset + 1] = green;
                    resultBuffer[byteOffset + 2] = red;
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            erodedImage.UnlockBits(resultData);

            return erodedImage;
        }
    }
}
