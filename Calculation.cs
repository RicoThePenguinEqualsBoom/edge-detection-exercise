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
    internal class Calculation
    {
        internal static Bitmap ArithmeticBlend(Bitmap image1, Bitmap image2, string operation)
        {
            BitmapData imageData1 = image1.LockBits(new Rectangle(0, 0, image1.Width, image1.Height), ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);
            BitmapData imageData2 = image2.LockBits(new Rectangle(0, 0, image2.Width, image2.Height), ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            Bitmap BlendedImage = new(image1.Width, image1.Height);
            BitmapData blendedData = BlendedImage.LockBits(new Rectangle(0, 0, BlendedImage.Width, BlendedImage.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int bytes = imageData1.Stride * imageData1.Height;
            byte[] pixelBuffer1 = new byte[bytes];
            byte[] pixelBuffer2 = new byte[bytes];

            Marshal.Copy(imageData1.Scan0, pixelBuffer1, 0, bytes);
            Marshal.Copy(imageData2.Scan0, pixelBuffer2, 0, bytes);

            image1.UnlockBits(imageData1);
            image2.UnlockBits(imageData2);

            Parallel.For(0, bytes / 4, j =>
            {
                int k = j * 4;
                pixelBuffer1[k] = Operation(pixelBuffer1[k], pixelBuffer2[k], operation);

                pixelBuffer1[k + 1] = Operation(pixelBuffer1[k + 1], pixelBuffer2[k + 1], operation);

                pixelBuffer1[k + 2] = Operation(pixelBuffer1[k + 2], pixelBuffer2[k + 2], operation);
            });

            Marshal.Copy(pixelBuffer1, 0, blendedData.Scan0, bytes);
            BlendedImage.UnlockBits(blendedData);

            return BlendedImage;
        }

        internal static byte Operation(byte image1, byte image2, string operation)
        {
            int intResult = operation switch
            {
                "+" => image1 + image2,
                "- (v1)" => image1 - image2,
                "- (v2)" => image2 - image1,
                "avg (best)" => (image1 + image2) / 2,
                _ => 0
            };

            byte result = (byte)Math.Clamp(intResult, 0, 255);

            return result;
        }
    }
}
