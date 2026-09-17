using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileTracker2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string content = "";

        private FileSystemWatcher watcher;

        private string path =
            @"C:\Users\Aryan\OneDrive\Desktop\";

        public MainWindow()
        {
            InitializeComponent();

            // Start watching the folder
            FileWatching();

            // Load the initial content of the file
            string filePath = path + "FileWatcherTester.txt";

            if (File.Exists(filePath))
            {
                content = File.ReadAllText(filePath);
                textBox.Text = content;
            }
        }

        private void FileWatching()
        {
            // Create FileSystemWatcher
            watcher = new FileSystemWatcher(path);

            // Watch only this file
            watcher.Filter = "FileWatcherTester.txt";

            // Detect changes to the file
            watcher.NotifyFilter =
                NotifyFilters.LastWrite |
                NotifyFilters.Size |
                NotifyFilters.FileName;

            // Subscribe to Changed event
            watcher.Changed += UpdateBox;

            // Start watching
            watcher.EnableRaisingEvents = true;
        }

        private void UpdateBox(object sender, FileSystemEventArgs e)
        {
            try
            {
                // Read the updated file
                content = File.ReadAllText(e.FullPath);

                // Update WPF UI from the UI thread
                Dispatcher.Invoke(() =>
                {
                    textBox.Text = content;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}