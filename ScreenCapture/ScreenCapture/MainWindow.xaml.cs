using System;
using System.Drawing; // Requires System.Drawing or System.Drawing.Common
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WpfApp = System.Windows.Application;

namespace ScreenCaptureWPF
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer _captureTimer;
        private int _numberOfCaptures = 0;

        // Saves to the folder where the application executable is running
        private string _saveDirectory = @"E:\Software Eng\Software-Engineering-Labs\Ss\";

        public MainWindow()
        {
            InitializeComponent();

            // Initialize WPF Timer
            _captureTimer = new DispatcherTimer();
            _captureTimer.Tick += CaptureTimer_Tick;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TimeStepTextBox.Text, out int timeStep))
            {
                // Set the interval based on the user's input
                _captureTimer.Interval = TimeSpan.FromSeconds(timeStep);

                // Do an immediate capture, then start the timer loop
                PerformScreenCapture();
                _captureTimer.Start();

                StatusTextBlock.Text = $"Capturing screen every {timeStep} seconds...";
            }
            else
            {
                System.Windows.MessageBox.Show("Please enter a valid number of seconds.");
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _captureTimer.Stop();
            StatusTextBlock.Text = "Screen capture stopped.";
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            WpfApp.Current.Shutdown();
        }

        private void CaptureTimer_Tick(object? sender, EventArgs e)
        {
            PerformScreenCapture();
        }

        private void PerformScreenCapture()
        {
            try
            {
                _numberOfCaptures++;

                // Format timestamp as HHMM (e.g., 0435 for 4:35)
                string timeStamp = DateTime.Now.ToString("HHmm");
                string fileName = $"Capture{_numberOfCaptures}_{timeStamp}.jpg";
                string fullPath = Path.Combine(_saveDirectory, fileName);

                // Grab the primary monitor bounds using Windows Forms interop
                Rectangle bounds = System.Windows.Forms.Screen.PrimaryScreen!.Bounds;

                // Create the blank bitmap and graphics canvas
                using (Bitmap captureBitmap = new Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                {
                    using (Graphics captureGraphics = Graphics.FromImage(captureBitmap))
                    {
                        // Copy pixels from screen to the bitmap
                        captureGraphics.CopyFromScreen(bounds.Location, System.Drawing.Point.Empty, bounds.Size);
                    }

                    // Save the image to the hard drive
                    captureBitmap.Save(fullPath, ImageFormat.Jpeg);

                    // Convert the GDI+ Bitmap into a WPF ImageSource and apply it to the UI
                    CaptureImage.Source = ConvertBitmapToImageSource(captureBitmap);
                }
            }
            catch (Exception ex)
            {
                _captureTimer.Stop();
                System.Windows.MessageBox.Show($"Capture failed: {ex.Message}");
            }
        }

        // Helper method: WPF cannot directly display System.Drawing.Bitmap.
        // We write it to a memory stream, then load that stream into a WPF BitmapImage.
        private BitmapImage ConvertBitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }
    }
}