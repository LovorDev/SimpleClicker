using System;
using System.Collections.Generic;
using System.Linq;
using Clicker.Scripts.Runtime.Model;
using UnityEngine;

namespace Clicker.Scripts.Runtime.Config
{
    [CreateAssetMenu(fileName = nameof(ShopConfig), menuName = "Clicker/" + nameof(ShopConfig), order = 0)]
    public class ShopConfig : ScriptableObject
    {
        public Dictionary<ItemType, ItemConfig> ShopItemConfigsMap => _shopItemConfigsMap ?? _itemConfigs.ToDictionary(x => x.ItemType, y => y);

        private readonly Dictionary<ItemType, ItemConfig> _shopItemConfigsMap;

        [SerializeField]
        private ItemConfig[] _itemConfigs;
    }

    [Serializable]
    public class ItemConfig
    {
        [field: SerializeField]
        public ItemType ItemType { get; private set; }

        [field: SerializeField]
        public List<ValueCostPair> ValueCostPairs { get; private set; }
    }

    [Serializable]
    public class ValueCostPair
    {
        [field: SerializeField]
        public double Value { get; private set; }

        [field: SerializeField]
        public double Cost { get; private set; }
    }
}