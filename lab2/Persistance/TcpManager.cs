using System;
using System.IO;
namespace Persistance
{
    public class TcpManager : ProtocolManager
    {
        private int MessageCount=0;
        public virtual void SendMessage()
        {
            Console.WriteLine("Sending Message via TCP\n");
            MessageCount++;
        }
        public virtual int RetrieveMessageCount()
        {
            return MessageCount;
        }

        private void  OnChanged(object sender,FileSystemEventArgs e)
        {
            if(e.ChangeType != WatcherChangeTypes.Changed)
            {
                return ;
            }
            Console.WriteLine($"Changed: {e.Name}");
        }

        private void OnCreated(object sender,FileSystemEventArgs e)
        {
            string val = $"Created File: {e.FullPath}";
            Console.WriteLine(val);
        }

        private void OnDeleted(object sender,FileSystemEventArgs e)
        {
            Console.WriteLine($"Deleted File: {e.FullPath}");
        }

        private void OnRenamed(object sender,FileSystemEventArgs e)
        {
            Console.WriteLine($"Renamed file: {e.FullPath}");
        }
        public void FileWatching(string file)
        {
            using var watcher = new FileSystemWatcher("/home/iotaaryan/Downloads/");
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;

            watcher.Filter = file;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents=true;

            Console.WriteLine("Listening to changes\n");
            Console.ReadLine();
            
        }
    }
}