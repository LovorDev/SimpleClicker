using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Scripts.Runtime.View
{
    public class EnemyView : MonoBehaviour
    {
        [field: SerializeField]
        public TMP_Text Name { get; private set; }

        [field: SerializeField]
        public Button ClickButton { get; private set; }

        [field: SerializeField]
        public CanvasGroup CanvasGroup { get; private set; }

        [field: SerializeField]
        public Slider HpBar { get; private set; }

        [field: SerializeField]
        public Image Image { get; private set; }
    }
}