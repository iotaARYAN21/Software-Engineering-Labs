
using System;
using System.IO;
namespace ProtocolManager
{
    public class TcpManager : ICommunicator
    {
        private int MessageCount=0;
        FileSystemWatcher _fileWatcher;

        IListener _listener;
        public TcpManager()
        {
            _fileWatcher = new FileSystemWatcher();
            _fileWatcher.Path = "/home/iotaaryan/Downloads/";
            _fileWatcher.Filter = "file.txt";
            _fileWatcher.Changed += OnChanged;
            _fileWatcher.Created += OnCreated;
            _fileWatcher.Deleted += OnDeleted;
            _fileWatcher.Renamed += OnRenamed;
            _fileWatcher.EnableRaisingEvents=true;
        }
        private void  OnChanged(object sender,FileSystemEventArgs e)
        {
            if(e.ChangeType != WatcherChangeTypes.Changed)
            {
                return ;
            }
            // Console.WriteLine($"Changed: {e.Name}");
            _listener.OnFileChanged("File changed");
        }

        private void OnCreated(object sender,FileSystemEventArgs e)
        {
            _listener.OnFileCreated("File Created");
        }

        private void OnDeleted(object sender,FileSystemEventArgs e)
        {
            _listener.OnFileDeleted("File deleted");
        }

        private void OnRenamed(object sender,FileSystemEventArgs e)
        {
            _listener.OnFileRenamed("File Renamed");
        }
        public void SendMessage(string msg)
        {   Console.WriteLine("Sending Message via TCP\n");
            File.WriteAllText(_fileWatcher.Path+_fileWatcher.Filter,msg);
            MessageCount++;
        }
        public void Subscribe(IListener l)
        {
            _listener= l;
        }

        public virtual int RetrieveMessageCount()
        {
            return MessageCount;
        }

    }
}
