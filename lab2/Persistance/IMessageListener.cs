namespace Persistance
{
    public interface IMessageListener // any module that subsribe to this can get the data recieved here
    {
        void OnMessageRecieved(string message);
    }
}