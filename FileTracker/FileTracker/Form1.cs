using System;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace FileTracker
{
    public partial class Form1 : Form
    {
        private string content;
        private FileSystemWatcher watcher;
        private string path= @"C:\Users\Aryan\OneDrive\Desktop\";
        public Form1()
        {
            InitializeComponent();
            FileWatching();
            textBox.Text = File.ReadAllText(path + "FileWatcherTester.txt");
        }
        private void updateBox(object sender,FileSystemEventArgs e)
        {
            // update the "content" variable here
            content = File.ReadAllText(e.FullPath);
            Invoke(() =>
            {
                textBox.Text = content;
            });
            //Invoke() = > execute this on the thread that owns this control.
            //as the file watcher event listening may run on different thread and
            //WinForms not allows other thread to manipulate the UI thread and can give exceptions.

        }
        private void OnError(object sender, ErrorEventArgs e) =>
            Console.WriteLine(e.GetException());
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            // provides the textbox content 
            //textBox.Text = content;
        }
        private void FileWatching()
        {
            // listen for file changes
            watcher = new FileSystemWatcher(path);
            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += updateBox;
            watcher.Created += updateBox;
            watcher.Deleted += updateBox;
            watcher.Renamed += updateBox;
            watcher.Error += OnError;
            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

  
        }
    }
}
