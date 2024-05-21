using System;
using UnityEngine;

namespace Clicker.Scripts.Runtime.Config
{
    [Serializable]
    public class ValueCostPair
    {
        [field: SerializeField]
        public double Value { get; private set; }

        [field: SerializeField]
        public double Cost { get; private set; }
    }
}