using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Scripts.Runtime.View
{
    public class ShopItemView : MonoBehaviour
    {
        [field: SerializeField]
        public TMP_Text ItemType { get; private set; }

        [field: SerializeField]
        public TMP_Text Value { get; private set; }

        [field: SerializeField]
        public TMP_Text Cost { get; private set; }

        [field: SerializeField]
        public Button Click { get; private set; }
    }
}