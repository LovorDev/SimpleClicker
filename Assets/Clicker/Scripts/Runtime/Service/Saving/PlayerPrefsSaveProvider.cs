using Cysharp.Threading.Tasks;
using SaveSystem;
using UnityEngine;

namespace Clicker.Scripts.Runtime.Service
{
    public class PlayerPrefsSaveProvider : ISaveProvider
    {
        public UniTask<bool> TrySave<T>(string key, T obj)
        {
            PlayerPrefs.SetString(key, JsonUtility.ToJson(obj));
            return new UniTask<bool>(true);
        }

        public UniTask<T> Load<T>(string key, T defaultValue = default) where T : ISavedData
        {
            return new UniTask<T>(PlayerPrefs.HasKey(key)
                ? JsonUtility.FromJson<T>(PlayerPrefs.GetString(key))
                : defaultValue);
        }
    }
}