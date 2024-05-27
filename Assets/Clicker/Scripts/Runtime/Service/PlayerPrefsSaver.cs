using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Clicker.Scripts.Runtime.Service
{
    public class PlayerPrefsSaver : ISaveSystem
    {
        public void Save<T>(string key, T obj)
        {
            PlayerPrefs.SetString(key, JsonUtility.ToJson(obj));
        }
        public UniTask<T> Load<T>(string key, T defaultValue = default)
        {
            return new UniTask<T>(PlayerPrefs.HasKey(key) ? JsonUtility.FromJson<T>(PlayerPrefs.GetString(key)) : defaultValue);
        }
    }
}