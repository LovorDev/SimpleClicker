using Cysharp.Threading.Tasks;

namespace Clicker.Scripts.Runtime.Service
{
    public interface ISaveSystem
    {
        public void Save<T>(string key, T obj);
        public UniTask<T> Load<T>(string key, T defaultValue = default);
    }
}