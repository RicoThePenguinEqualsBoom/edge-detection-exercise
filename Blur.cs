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

            //Define the width of the filter to be used
            int filterWidth = filterMatrix.GetLength(1);

            //Define any relevant offsets and reused/unsafe variables
            int filterOffset = (filterWidth - 1) / 2;
            int imageStride = imageData.Stride;
            int imageHeight = image.Height;
            int imageWidth = image.Width;

            //Define the size of processing chunks to avoid overlap and checkerboard patterns 
            int processorCount = Environment.ProcessorCount;
            int chunkSizeY = (imageHeight + processorCount - 1) / processorCount;
            int chunkSizeX = (imageWidth + processorCount - 1) / processorCount;
            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = processorCount
            };

            List<Tuple<int, int>> chunkRangesY = [];
            List<Tuple<int, int>> chunkRangesX = [];

            //Define where the chunks start and end 
            for (int i = 0; i < processorCount; i++)
            {
                int startY = Math.Max(i * chunkSizeY, filterOffset);
                int limitY = Math.Min(startY + chunkSizeY, imageHeight);
                int endY = Math.Min(limitY, imageHeight - filterOffset);
                chunkRangesY.Add(new Tuple<int, int>(startY, endY));

                int startX = Math.Max(i * chunkSizeX, filterOffset);
                int limitX = Math.Min(startX + chunkSizeX, imageWidth);
                int endX = Math.Min(limitX, imageWidth - filterOffset);
                chunkRangesX.Add(new Tuple<int, int>(startX, endX));
            }

            Parallel.For(0, processorCount, parallelOptions, chunkY =>
            {
                //Embed the start and end of the chunks into the Parallel.For
                var (startY, endY) = chunkRangesY[chunkY];

                Parallel.For(0, processorCount, parallelOptions, chunkX =>
                {
                    var (startX, endX) = chunkRangesX[chunkX];

                    for (int offsetY = startY; offsetY < endY; offsetY++)
                    {
                        for (int offsetX = startX; offsetX < endX; offsetX++)
                        {
                            double blue = 0;
                            double green = 0;
                            double red = 0;

                            //Define the offset to be able to affect pixel per pixel
                            //Instead of blue, green, red, alpha and only then next pixel
                            int byteOffset = offsetY * imageStride + offsetX * 4;

                            for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                            {
                                for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                                {
                                    int calcOffset = byteOffset + (filterX * 4) + (filterY * imageStride);

                                    //Make sure to actually use the filter or it'll just spit out the same image you put in
                                    red += pixelBuffer[calcOffset + 2] * filterMatrix[filterY + filterOffset, filterX + filterOffset];

                                    green += pixelBuffer[calcOffset + 1] * filterMatrix[filterY + filterOffset, filterX + filterOffset];

                                    blue += pixelBuffer[calcOffset] * filterMatrix[filterY + filterOffset, filterX + filterOffset];
                                }
                            }

                            //Make sure the color value is within the appropriate values
                            blue = Math.Clamp(blue, 0, 255);
                            green = Math.Clamp(green, 0, 255);
                            red = Math.Clamp(red, 0, 255);

                            resultBuffer[byteOffset] = (byte)blue;
                            resultBuffer[byteOffset + 1] = (byte)green;
                            resultBuffer[byteOffset + 2] = (byte)red;
                            resultBuffer[byteOffset + 3] = 255;

                        }
                    }
                });
            });

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

            //The same Parallel.For implementation doesn't play nice here so I'm not gonna touch it for a while
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
        //Define the matrixes for the different blur methods
        //Can add more and/or larger methods for more granular control
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
