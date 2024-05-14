using System.Collections.Generic;
using System.Linq;
using Clicker.Scripts.Runtime.Model;
using UnityEngine;

namespace Clicker.Scripts.Runtime.View
{
    public class ShopView : MonoBehaviour
    {
        public Dictionary<ItemType, ShopItemView> ShopItemViewsMap => _shopItemViewsMap ?? _shopItems.ToDictionary(x => x.ItemType, y => y);

        // [SerializeField]
        // private ShopItemView _clickView;
        //
        // [SerializeField]
        // private ShopItemView _critView;
        //
        // [SerializeField]
        // private ShopItemView _critChanceView;
        //
        // [SerializeField]
        // private ShopItemView _autoClickView;
        //
        // [SerializeField]
        // private ShopItemView _autoClickMultiplierView;

        [SerializeField]
        private List<ShopItemView> _shopItems;

        private readonly Dictionary<ItemType, ShopItemView> _shopItemViewsMap;
    }
}