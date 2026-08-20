using ProtocolManager;

namespace Networking
{
    class Listener : IListener
    {
        public void OnFileChanged(string msg)
        {
            Console.WriteLine(msg);
        }

        public void OnFileCreated(string msg)
        {
            
            Console.WriteLine(msg);
        }

        public void OnFileDeleted(string msg)
        {
            Console.WriteLine(msg);
        }

        public void OnFileRenamed(string msg)
        {
            Console.WriteLine(msg);
        }
    } 
    internal class Program
    {
        static void Main(string[] args)
        {
            ICommunicator comm = new TcpManager();
            comm.SendMessage("Hello");

            IListener l = new Listener();
            comm.Subscribe(l);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}