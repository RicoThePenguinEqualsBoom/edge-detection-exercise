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
    internal class Blur
    {
        internal static Bitmap ConvolutionBlur(Bitmap image, double[,] filterMatrix, double factor = 1)
        {
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            Bitmap blurredImage = new(image.Width, image.Height);

            BitmapData resultData = blurredImage.LockBits(new Rectangle(0, 0, blurredImage.Width, blurredImage.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int bytes = imageData.Stride * imageData.Height;    
            byte[] pixelBuffer = new byte[bytes];
            byte[] resultBuffer = new byte[bytes];

            Marshal.Copy(imageData.Scan0, pixelBuffer, 0, bytes);
            image.UnlockBits(imageData);

            int filterWidth = filterMatrix.GetLength(1);

            int filterOffset = (filterWidth - 1) / 2;
            int calcOffset;
            int byteOffset;
            int imageStride = imageData.Stride;

            double blue;
            double green;
            double red;

            for (int offsetY = filterOffset; offsetY < image.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < image.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;

                    byteOffset = offsetY * imageStride + offsetX * 4;

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset + (filterX * 4) + (filterY * imageStride);

                            blue += pixelBuffer[calcOffset] * filterMatrix[filterY + filterOffset, filterX + filterOffset];
                            green += pixelBuffer[calcOffset + 1] * filterMatrix[filterY + filterOffset, filterX + filterOffset];
                            red += pixelBuffer[calcOffset + 2] * filterMatrix[filterY + filterOffset, filterX + filterOffset];
                        }
                    }

                    blue = factor * blue;
                    green = factor * green;
                    red = factor * red;

                    blue = Math.Clamp(blue, 0, 255);
                    green = Math.Clamp(green, 0, 255);
                    red = Math.Clamp(red, 0, 255);

                    resultBuffer[byteOffset] = (byte)blue;
                    resultBuffer[byteOffset + 1] = (byte)green;
                    resultBuffer[byteOffset + 2] = (byte)red;
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, bytes);
            blurredImage.UnlockBits(resultData);

            return blurredImage;
        }

        internal static Bitmap MedianBlur(Bitmap image, int matrixSize = 3)
        {
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            Bitmap medianImage = new(image.Width, image.Height);
            BitmapData resultData = medianImage.LockBits(new Rectangle(0, 0, medianImage.Width, medianImage.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int bytes = imageData.Stride * imageData.Height;
            byte[] pixelBuffer = new byte[bytes];
            byte[] resultBuffer = new byte[bytes];

            Marshal.Copy(imageData.Scan0, pixelBuffer, 0, bytes);

            image.UnlockBits(imageData);

            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset;
            int byteOffset;
            int imageHeight = image.Height;
            int imageWidth = image.Width;
            int imageStride = imageData.Stride;

            List<int> neighbourPixels = [];
            byte[] middlePixel;

            for (int offsetY = filterOffset; offsetY < imageHeight - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < imageWidth - filterOffset; offsetX++)
                {
                    byteOffset = offsetY * imageStride + offsetX * 4;

                    neighbourPixels.Clear();

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset + (filterX * 4) + (filterY * imageStride);
                            neighbourPixels.Add(BitConverter.ToInt32(pixelBuffer, calcOffset));
                        }
                    }

                    neighbourPixels.Sort();

                    middlePixel = BitConverter.GetBytes(neighbourPixels[filterOffset]);

                    resultBuffer[byteOffset] = middlePixel[0];
                    resultBuffer[byteOffset + 1] = middlePixel[1];
                    resultBuffer[byteOffset + 2] = middlePixel[2];
                    resultBuffer[byteOffset + 3] = middlePixel[3];
                }
            }

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, bytes);

            medianImage.UnlockBits(resultData);

            return medianImage;
        }
    }

    internal static class Matrix
    {
        internal static double[,] Mean
        {
            get
            {
                return new double[,]
                {
                    {1, 1, 1},
                    {1, 1, 1},
                    {1, 1, 1}
                };
            }
        }

        internal static double[,] Gaussian
        {
            get
            {
                return new double[,]
                {
                    {1, 2, 1},
                    {2, 4, 2},
                    {1, 2, 1}
                };
            }
        }
    }

}
