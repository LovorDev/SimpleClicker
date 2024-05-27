namespace Clicker.Scripts.Runtime.Controller
{
    public interface IFactory<T>
    {
        T Create();
        void Release(T obj);
    }
}