namespace ProtocolManager
{
    public interface ICommunicator
    {
        void SendMessage(string msg);
        void Subscribe(IListener listener);
    }
}