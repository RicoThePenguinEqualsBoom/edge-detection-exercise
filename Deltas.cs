using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Edge_detection
{
    //Could have put this all in Blur.cs but wanted to make sure to seperate the methods
    //Even though the code is exactly the same appart from nomenclature
    internal class Deltas
    {
        private static Bitmap DeltaFilter(Bitmap image, double[,] filterMatrix)
        {
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            Bitmap deltaImage = new(image.Width, image.Height);
            BitmapData deltaData = deltaImage.LockBits(new Rectangle(0, 0, deltaImage.Width, deltaImage.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);


            int bytes = imageData.Stride * imageData.Height;
            byte[] pixelBuffer = new byte[bytes];
            byte[] resultBuffer = new byte[bytes];

            Marshal.Copy(imageData.Scan0, pixelBuffer, 0, bytes);

            image.UnlockBits(imageData);

            int filterWidth = filterMatrix.GetLength(1);

            int filterOffset = (filterWidth - 1) / 2;
            int imageStride = imageData.Stride;
            int imageHeight = image.Height;
            int imageWidth = image.Width;

            int processorCount = Environment.ProcessorCount;
            int chunkSizeY = (imageHeight + processorCount - 1) / processorCount;
            int chunkSizeX = (imageWidth + processorCount - 1) / processorCount;
            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = processorCount
            };

            List<Tuple<int, int, int>> chunkRangesY = [];
            List<Tuple<int, int, int>> chunkRangesX = [];

            for (int i = 0; i < processorCount; i++)
            {
                int startY = i * chunkSizeY;
                int endY = Math.Min(startY + chunkSizeY, imageHeight);
                int limitY = Math.Min(endY, imageHeight - filterOffset);
                chunkRangesY.Add(new Tuple<int, int, int>(startY, endY, limitY));

                int startX = i * chunkSizeX;
                int endX = Math.Min(startX + chunkSizeX, imageWidth);
                int limitX = Math.Min(endX, imageWidth - filterOffset);
                chunkRangesX.Add(new Tuple<int, int, int>(startX, endX, limitX));
            }

            Parallel.For(0, processorCount, parallelOptions, chunkY =>
            {
                var (startY, endY, limitY) = chunkRangesY[chunkY];

                Parallel.For(0, processorCount, parallelOptions, chunkX =>
                {
                    var (startX, endX, limitX) = chunkRangesX[chunkX];

                    for (int offsetY = Math.Max(startY, filterOffset); offsetY < limitY; offsetY++)
                    {
                        for (int offsetX = Math.Max(startX, filterOffset); offsetX < limitX; offsetX++)
                        {
                            double blue = 0;
                            double green = 0;
                            double red = 0;

                            int byteOffset = offsetY * imageStride + offsetX * 4;

                            for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                            {
                                for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                                {
                                    int calcOffset = byteOffset + (filterX * 4) + (filterY * imageStride);

                                    red += pixelBuffer[calcOffset + 2] * filterMatrix[filterY + filterOffset, filterX + filterOffset];

                                    green += pixelBuffer[calcOffset + 1] * filterMatrix[filterY + filterOffset, filterX + filterOffset];

                                    blue += pixelBuffer[calcOffset] * filterMatrix[filterY + filterOffset, filterX + filterOffset];
                                }
                            }

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

            Marshal.Copy(resultBuffer, 0, deltaData.Scan0, bytes);

            deltaImage.UnlockBits(deltaData);

            return deltaImage;
        }

        internal static Bitmap DeltaX(Bitmap image, string operation)
        {
            Bitmap np = DeltaFilter(image, DeltaType.DeltaXnp);
            Bitmap pn = DeltaFilter(image, DeltaType.DeltaXpn);

            Bitmap deltaX = Calculation.ArithmeticBlend(np, pn, operation);

            return deltaX;
        }

        internal static Bitmap DeltaY(Bitmap image, string operation)
        {
            Bitmap np = DeltaFilter(image, DeltaType.DeltaYnp);
            Bitmap pn = DeltaFilter(image, DeltaType.DeltaYpn);

            Bitmap deltaY = Calculation.ArithmeticBlend(np, pn, operation);

            return deltaY;
        }

        internal static Bitmap Both(Bitmap dX, Bitmap dY, string operation)
        {
            Bitmap both = Calculation.ArithmeticBlend(dX, dY, operation);

            return both;
        }
    }

    internal class DeltaType
    {
        internal static double[,] DeltaXnp
        {
            get
            {
                return new double[,]
                {
                    { -1, -1, -1 },
                    { 0, 0, 0 },
                    { 1, 1, 1 }
                };
            }   
        }
    
        internal static double[,] DeltaXpn
        {
            get
            {
                return new double[,]
                {
                    { 1, 1, 1 },
                    { 0, 0, 0 },
                    { -1, -1, -1 }
                };
            }
        }

        internal static double[,] DeltaYnp
        {
            get
            {
                return new double[,]
                {
                    { -1, 0, 1 },
                    { -1, 0, 1 },
                    { -1, 0, 1 }
                };
            }
        }

        internal static double[,] DeltaYpn
        {
            get
            {
                return new double[,]
                {
                    { 1, 0, -1 },
                    { 1, 0, -1 },
                    { 1, 0, -1 }
                };
            }
        }
    }
}