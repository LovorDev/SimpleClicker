using System;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker.Scripts.Runtime.Config
{
    [Serializable]
    public class EnemyConfig
    {
        [field: SerializeField]
        public Sprite Sprite { get; private set; }

        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public double HpMax { get; private set; }
    }

    [CreateAssetMenu(fileName = nameof(EnemiesConfig), menuName = "Clicker/" + nameof(EnemiesConfig), order = 0)]
    public class EnemiesConfig : ScriptableObject
    {
        [field: SerializeField]
        public List<EnemyConfig> EnemyConfigs { get; private set; }
    }
}