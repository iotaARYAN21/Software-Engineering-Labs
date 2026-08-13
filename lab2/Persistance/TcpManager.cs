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
    }
}