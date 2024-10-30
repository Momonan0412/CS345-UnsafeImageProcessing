using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Image_Processing
{
    public partial class Form1 : Form
    {
        Bitmap _loadedImage, _processedImage;
        BitmapData loadedData, processedData;

        int height;
        int width;
        int stride;
        int[] histogram;
        //Bitmap bitMapHisto;
        public Form1()
        {
            InitializeComponent();
        }
        private void setProcessedImage()
        {
            // Create a new bitmap rather than modifying _loadedImage directly,
            // you ensure that the original image remains unchanged. 
            //_processedImage = new Bitmap(_loadedImage.Width, _loadedImage.Height);
            this._processedImage = new Bitmap(_loadedImage.Width, _loadedImage.Height);
        }
        private void setUnlockedBitmapData()
        {
            // Unlock the bits
            // Locking the image with LockBits allows you to work with the image data directly
            // using pointers, making it more efficient than methods like GetPixel/SetPixel,
            // especially in large-scale or high-performance tasks. This is often done in an unsafe { } block because it involves direct memory access, which allows you to bypass some of the overhead and perform more intensive pixel manipulation.
            _loadedImage.UnlockBits(loadedData);
            _processedImage.UnlockBits(processedData);
        }
        private void setLockedBitmapData()
        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap.lockbits?view=net-8.0&redirectedfrom=MSDN#System_Drawing_Bitmap_LockBits_System_Drawing_Rectangle_System_Drawing_Imaging_ImageLockMode_System_Drawing_Imaging_PixelFormat_
            // Locks a `Bitmap` in memory for direct pixel access,
            // making it faster to read/write pixel data.
            // Useful for high-performance image processing, allowing direct access to pixel data.
            this.loadedData = _loadedImage.LockBits(
                new Rectangle(0, 0, _loadedImage.Width, _loadedImage.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb
                );
            this.processedData = _processedImage.LockBits(
                new Rectangle(0, 0, _processedImage.Width, _processedImage.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb
                );
        }
        private void setDefaults()
        {
            this.height = _loadedImage.Height;
            this.width = _loadedImage.Width;
            this.stride = loadedData.Stride;
        }
        private void setPictureBoxTwoImage()
        {
            this.pictureBox2.Image = _processedImage;
        }
        private void imagePointerHandler(string processDefiner)
        {

            if (_loadedImage == null)
            {
                return;
            }
            this.setProcessedImage();
            this.setLockedBitmapData();
            this.setDefaults();
            unsafe
            {
                // Scan0 gives the memory address of the first byte in the bitmap data
                // for each locked bitmap(_loadedImage and _processedImage).
                // loadedData.Scan0 and processedData.Scan0 are converted to byte* pointers,
                // allowing us to navigate each byte in the images’ pixel data.
                // With byte* pointers to the bitmap data, you can perform low-level,
                // efficient operations on the raw bytes that represent pixel colors.
                byte* sourcePointer = (byte*)loadedData.Scan0;
                byte* destinationPointer = (byte*)processedData.Scan0;

                // https://stackoverflow.com/questions/12405938/save-time-with-parallel-for-loop
                if (processDefiner == "Mirror")
                {
                    // The Parallel.For(0, height, y => { ... }) loop allows each row (y)
                    // to be processed independently by different threads.
                    // This means that multiple rows can be handled simultaneously,
                    // leading to faster processing, especially for large images.
                    Parallel.For(0, height, y =>
                    {
                        for (int x = 0; x < width / 2; x++)
                        {
                            // Inside the inner loop, the code calculates the left and
                            // right pixel indices for mirroring.
                            // The left pixel is at (y * stride + x * 3),
                            // while the right pixel is at (y * stride + (width - x - 1) * 3).
                            int indexLeft = y * stride + x * 3; // Left pixel index
                            int indexRight = y * stride + (width - x - 1) * 3; // Right pixel index

                            // Swap the pixel data for Blue, Green, and Red
                            byte tempBlue = sourcePointer[indexLeft];
                            byte tempGreen = sourcePointer[indexLeft + 1];
                            byte tempRed = sourcePointer[indexLeft + 2];

                            // Assign the left pixel to the right pixel
                            destinationPointer[indexLeft] = sourcePointer[indexRight];       // Blue
                            destinationPointer[indexLeft + 1] = sourcePointer[indexRight + 1]; // Green
                            destinationPointer[indexLeft + 2] = sourcePointer[indexRight + 2]; // Red

                            // Assign the right pixel to the left pixel
                            destinationPointer[indexRight] = tempBlue;       // Blue
                            destinationPointer[indexRight + 1] = tempGreen;  // Green
                            destinationPointer[indexRight + 2] = tempRed;     // Red
                        }
                    });
                }
                else
                {
                    Parallel.For(0, height, y =>
                    //for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            int index = y * stride + x * 3;

                            // Copy pixel data
                            // In 24bpp images, each pixel is represented by 3 bytes (for RGB).
                            // In 32bpp images, each pixel is represented by 4 bytes(for ARGB).

                            byte blue = sourcePointer[index];
                            byte green = sourcePointer[index + 1];
                            byte red = sourcePointer[index + 2];
                            switch (processDefiner)
                            {
                                case "PixelCopy":
                                    destinationPointer[index] = sourcePointer[index];         // Blue
                                    destinationPointer[index + 1] = sourcePointer[index + 1]; // Green
                                    destinationPointer[index + 2] = sourcePointer[index + 2]; // Red
                                    break;
                                case "Histogram":
                                case "Grayscale":
                                    byte grayValue = (byte)((red + green + blue) / 3);
                                    destinationPointer[index] = grayValue;
                                    destinationPointer[index + 1] = grayValue;
                                    destinationPointer[index + 2] = grayValue;
                                    if (processDefiner == "Histogram") {
                                        histogram[grayValue]++;
                                    }
                                    break;
                                case "Inversion":
                                    byte deductBlue = (byte)Math.Max(0, 255 - blue);
                                    byte deductGreen = (byte)Math.Max(0, 255 - green);
                                    byte deductRed = (byte)Math.Max(0, 255 - red);
                                    destinationPointer[index] = deductBlue;
                                    destinationPointer[index + 1] = deductGreen;
                                    destinationPointer[index + 2] = deductRed;
                                    break;
                                case "Sepia":
                                    // https://stackoverflow.com/questions/1061093/how-is-a-sepia-tone-created
                                    // int outputRed = (inputRed * .393) + (inputGreen *.769) + (inputBlue * .189);
                                    // int outputGreen = (inputRed * .349) + (inputGreen * .686) + (inputBlue * .168);
                                    // int outputBlue = (inputRed * .272) + (inputGreen * .534) + (inputBlue * .131);
                                    byte outputRed = (byte)((red * .393) + (green * .769) + (blue * .189));
                                    byte outputGreen = (byte)((red * .349) + (green * .686) + (blue * .168));
                                    byte outputBlue = (byte)((red * .272) + (green * .534) + (blue * .131));
                                    destinationPointer[index] = outputBlue;
                                    destinationPointer[index + 1] = outputGreen;
                                    destinationPointer[index + 2] = outputRed;
                                    break;
                                default:
                                    return;
                            }
                        }
                    });
                }
            }
            this.setUnlockedBitmapData();
            this.setPictureBoxTwoImage();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _loadedImage = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = _loadedImage;
        }

        // Pointer Function
        private void pixelCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imagePointerHandler("PixelCopy");
            //Color pixel;
            //for (int x = 0; x < _loadedImage.Width; x++) {
            //    for (int y = 0; y < _loadedImage.Height; y++) {
            //        pixel = _loadedImage.GetPixel(x, y);
            //        _processedImage.SetPixel(x, y, pixel);
            //    } 
            //}
            //pictureBox2.Image = _processedImage;
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _processedImage.Save(saveFileDialog1.FileName, _loadedImage.RawFormat);
        }

        private void grayscallingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imagePointerHandler("Grayscale");
            //Color pixel;
            //int average;

            //for (int x = 0; x < _loadedImage.Width; x++)
            //{
            //    for (int y = 0; y < _loadedImage.Height; y++)
            //    {
            //        pixel = _loadedImage.GetPixel(x, y);
            //        average = (int)(pixel.R + pixel.G + pixel.B) / 3;
            //        Color gray = Color.FromArgb(average, average, average);
            //        _processedImage.SetPixel(x, y, gray);
            //    }
            //}
        }

        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imagePointerHandler("Inversion");

        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imagePointerHandler("Sepia");
        }

        private void mirrorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.imagePointerHandler("Mirror");
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.histogram = new int[256];
            // Gets the histogram Frequency Using Grayscaling
            this.imagePointerHandler("Histogram");
            Bitmap _newProcessedImage = new Bitmap(256, 256*2, PixelFormat.Format24bppRgb);
            BitmapData newProcessedData = _newProcessedImage.LockBits(
                new Rectangle(0, 0, _newProcessedImage.Width, _newProcessedImage.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb
                );
            int newStride = newProcessedData.Stride;
            int width = _newProcessedImage.Width;
            int height = _newProcessedImage.Height;
            unsafe {
                byte* bitptr = (byte*)newProcessedData.Scan0;
                // Draw histogram bars based on frequency
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        int index = y * newStride + x * 3; // Correctly calculate the index using newStride
                        bitptr[index] = 255;      // Blue
                        bitptr[index + 1] = 255;  // Green
                        bitptr[index + 2] = 255;  // Red
                    }
                }
                // Now draw the histogram bars based on frequency
                Parallel.For(0, 256, x =>
                {
                    int barHeight = Math.Min(histogram[x] / 5, height); // Scale down the height of the bar
                    for (int y = 0; y < barHeight; y++) // Start from the top
                    {
                        int index = (height - 1 - y) * newStride + x * 3;
                        // 44,62,117
                        bitptr[index] = 117;          // Blue
                        bitptr[index + 1] = 62;      // Green
                        bitptr[index + 2] = 44;      // Red
                    }
                });
            }
            _newProcessedImage.UnlockBits(newProcessedData);
            this.pictureBox2.Image = _newProcessedImage;
        }
    }
}
