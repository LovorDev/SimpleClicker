using System.Collections.Generic;
using System.Linq;
using Clicker.Scripts.Runtime.Model;
using SaveSystem;

namespace Clicker.Scripts.Runtime.Service
{
    public class EnemySavedData : ISavedData
    {
        public int Level;
        
        public ISavedData CompareRelevant(ISavedData other)
        {
            return Level > ((EnemySavedData)other).Level ? this : other;
        }
    }

    public class ShopItemsSavedData : ISavedData
    {
        public Dictionary<ItemType, int> ItemsLevel = new Dictionary<ItemType, int>();
        public ISavedData CompareRelevant(ISavedData other)
        {
            var otherCasted = (ShopItemsSavedData)other;
            var keys = otherCasted.ItemsLevel;
            if (otherCasted.ItemsLevel.Count != ItemsLevel.Count)
            {
                return otherCasted.ItemsLevel.Count > ItemsLevel.Count ? otherCasted : this;
            }

            return otherCasted.ItemsLevel.Sum(x => x.Value) > ItemsLevel.Sum(x => x.Value)
                ? otherCasted
                : this;
        }
    }}