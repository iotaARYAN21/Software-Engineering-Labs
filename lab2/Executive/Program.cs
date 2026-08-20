using Persistance;

namespace Executive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProtocolManager httpManager = new HttpManager();
            httpManager.SendMessage();
            Console.WriteLine("Count of message sent by Http: "+httpManager.RetrieveMessageCount()+"\n");

            ProtocolManager tcpManager = new TcpManager();
            tcpManager.SendMessage();
            Console.WriteLine("Count of message sent by TCP "+tcpManager.RetrieveMessageCount()+"\n");

            TcpManager tcpManager2 = new TcpManager();
            tcpManager2.FileWatching("file.txt");

            ProtocolManager extendedTcpManager = new ExtendedTcpManager();
            extendedTcpManager.SendMessage();
            Console.WriteLine("Count of message sent by Extended Tcp Manager "+extendedTcpManager.RetrieveMessageCount()+"\n");

            ProtocolFactory factory = new ProtocolFactory();
            ProtocolManager p = factory.GetProtocolManager();
            p.SendMessage();
            Console.WriteLine("Count of message sent by Factory: "+p.RetrieveMessageCount()+"\n");
            // p.RetrieveMessageCount();
        }
    }
}