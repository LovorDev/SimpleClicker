using System.Collections.Generic;
using System.Linq;
using Clicker.Scripts.Runtime.Model;
using UnityEngine;

namespace Clicker.Scripts.Runtime.View
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField]
        private List<ShopItemView> _shopItems;

        [field: SerializeField]
        public Transform ItemsParent { get; private set; }
    }
}