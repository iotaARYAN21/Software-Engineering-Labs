namespace Persistance
{
    public class ProtocolFactory
    {
        public ProtocolManager GetProtocolManager()
        {
            return new HttpManager();
        }
    }
}