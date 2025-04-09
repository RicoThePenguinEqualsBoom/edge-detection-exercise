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
    internal class LayerMask
    {
        internal static Bitmap LayerMasking(Bitmap image, Bitmap mask, int color)
        {
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            BitmapData maskData = mask.LockBits(new Rectangle(0, 0, mask.Width, mask.Height), ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            Bitmap resultImage = new(image.Width, image.Height);
            BitmapData resultData = resultImage.LockBits(new Rectangle(0, 0, resultImage.Width, resultImage.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int bytes = imageData.Stride * imageData.Height;
            byte[] pixelBuffer = new byte[bytes];
            byte[] resultBuffer = new byte[bytes];
            byte[] maskBuffer = new byte[bytes];

            Marshal.Copy(imageData.Scan0, pixelBuffer, 0, bytes);
            Marshal.Copy(maskData.Scan0, maskBuffer, 0, bytes);

            image.UnlockBits(imageData);
            mask.UnlockBits(maskData);

            Parallel.For(0, bytes / 4, j =>
            {
                int i = j * 4;
                byte maskValue = maskBuffer[i + color];

                resultBuffer[i] = (byte)((pixelBuffer[i] * maskValue) / 255);
                resultBuffer[i + 1] = (byte)((pixelBuffer[i + 1] * maskValue) / 255);
                resultBuffer[i + 2] = (byte)((pixelBuffer[i + 2] * maskValue) / 255);
                resultBuffer[i + 3] = pixelBuffer[i + 3];
            });

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, bytes);
            resultImage.UnlockBits(resultData);

            return resultImage;
        }
    }
}
