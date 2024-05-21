using System;
using System.Collections.Generic;
using R3;
using UnityEngine.UI;

namespace Clicker.Scripts.Runtime.Model
{
    public class ClickerModel: IClickModel, IEnemyModel, IShopModel
    {
        public event Action ItemInitialized = () => { };
        public Dictionary<ItemType, ReactiveProperty<ItemValueCost>> ShopItems { get; } = new ();
        
        public Dictionary<ItemType, ReactiveProperty<int>> ShopItemsLevel { get; } = new ();
        
        public ReactiveProperty<Enemy> Enemy { get; } = new ReactiveProperty<Enemy>();
        public ReactiveProperty<double> Gold { get; } = new ReactiveProperty<double>();

        public bool TryBuy(double gold)
        {
            if (Gold.CurrentValue < gold)
            {
                return false;
            }
            
            Gold.Value -= gold;
            return true;
        }

        public void CallInitialized()
        {
            ItemInitialized();
        }
    }
}