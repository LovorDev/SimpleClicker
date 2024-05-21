using System;
using System.Linq;
using Clicker.Scripts.Runtime.Model;
using R3;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Controller
{
    public class ShopItemFactory : IInitializable
    {
        private ClickerModel _clickModel;
        private Func<ItemType, int> _shopItemResolve;

        public ShopItemFactory(ClickerModel clickModel, Func<ItemType, int> shopItemResolve)
        {
            _clickModel = clickModel;
            _shopItemResolve = shopItemResolve;
        }

        public void Initialize()
        {
            var values = Enum.GetValues(typeof(ItemType)).Cast<ItemType>();
            
            foreach (var  itemType in values) 
            {
                _clickModel.ShopItems[itemType] = new ReactiveProperty<ItemValueCost>();
                _clickModel.ShopItemsLevel[itemType] = new ReactiveProperty<int>(_shopItemResolve(itemType));
            }
            
            _clickModel.CallInitialized();
        }
        
    }
}