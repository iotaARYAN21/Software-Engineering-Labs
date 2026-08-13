namespace Persistance
{
    public class HttpManager : ProtocolManager
    {
        private int MessageCount=0;
        public virtual void SendMessage()
        {
          Console.WriteLine("Sending message via HTTP\n");
          MessageCount++;   
        }
        public virtual int RetrieveMessageCount()
        {
            return MessageCount;
        }
    }
}