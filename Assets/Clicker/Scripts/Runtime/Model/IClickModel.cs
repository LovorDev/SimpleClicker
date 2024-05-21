using System;
using System.Collections.Generic;
using R3;

namespace Clicker.Scripts.Runtime.Model
{
    public interface IClickModel
    {
        public event Action ItemInitialized;
        Dictionary<ItemType, ReactiveProperty<ItemValueCost>> ShopItems { get; }
        Dictionary<ItemType, ReactiveProperty<int>> ShopItemsLevel { get; }
    }
}