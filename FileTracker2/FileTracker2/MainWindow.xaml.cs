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

            
            FileWatching();

            
            string filePath = path + "FileWatcherTester.txt";

            if (File.Exists(filePath))
            {
                content = File.ReadAllText(filePath);
                textBox.Text = content;
            }
        }

        private void FileWatching()
        {
            watcher = new FileSystemWatcher(path);

                     watcher.Filter = "FileWatcherTester.txt";

           
            watcher.NotifyFilter =
                NotifyFilters.LastWrite |
                NotifyFilters.Size |
                NotifyFilters.FileName;

            
            watcher.Changed += UpdateBox;

           
            watcher.EnableRaisingEvents = true;
        }

        private void UpdateBox(object sender, FileSystemEventArgs e)
        {
            try
            {
                
                content = File.ReadAllText(e.FullPath);

               
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