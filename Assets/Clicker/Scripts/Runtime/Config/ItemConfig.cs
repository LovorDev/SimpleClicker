using System;
using System.Collections.Generic;
using Clicker.Scripts.Runtime.Model;
using UnityEngine;

namespace Clicker.Scripts.Runtime.Config
{
    [Serializable]
    public class ItemConfig
    {
        [field: SerializeField]
        public ItemType ItemType { get; private set; }

        [field: SerializeField]
        public List<ValueCostPair> ValueCostPairs { get; private set; }
    }
}