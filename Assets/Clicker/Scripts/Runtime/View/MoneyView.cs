using TMPro;
using UnityEngine;

namespace Clicker.Scripts.Runtime.View
{
    public class MoneyView : MonoBehaviour
    {
        [field: SerializeField]
        public TMP_Text MoneyText { get; private set; }
    }
}