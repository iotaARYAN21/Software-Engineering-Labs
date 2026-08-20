namespace ProtocolManager
{
    public interface IListener
    {
        void OnFileChanged(string msg);
        void OnFileCreated(string msg);
        void OnFileDeleted(string msg);
        void OnFileRenamed(string msg);
    }
}