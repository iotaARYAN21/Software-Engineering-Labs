namespace Persistance
{
    public class ExtendedTcpManager : TcpManager
    {
        private int MessageCount=0;
        public override void SendMessage()
        {
            // base.SendMessage();
            Console.WriteLine("Sending message via ExtendedTcpManager\n");
            MessageCount++;
        }
        public override int RetrieveMessageCount()
        {
            return MessageCount;
            // base.RetrieveMessageCount();
        }
    }
}