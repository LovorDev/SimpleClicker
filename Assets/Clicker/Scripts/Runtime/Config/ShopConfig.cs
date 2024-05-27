using System.Collections.Generic;
using System.Linq;
using Clicker.Scripts.Runtime.Model;
using UnityEngine;

namespace Clicker.Scripts.Runtime.Config
{
    [CreateAssetMenu(fileName = nameof(ShopConfig), menuName = "Clicker/" + nameof(ShopConfig), order = 0)]
    public class ShopConfig : ScriptableObject
    {
        public Dictionary<ItemType, ItemConfig> ShopItemConfigsMap =>
            _shopItemConfigsMap ?? _itemConfigs.ToDictionary(x => x.ItemType, y => y);

        private readonly Dictionary<ItemType, ItemConfig> _shopItemConfigsMap;
        public ItemConfig[] ItemConfigs => _itemConfigs;

        [SerializeField]
        private ItemConfig[] _itemConfigs;
    }
}