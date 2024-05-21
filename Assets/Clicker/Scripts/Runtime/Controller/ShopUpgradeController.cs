using System;
using Clicker.Scripts.Runtime.Config;
using Clicker.Scripts.Runtime.Model;
using R3;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Controller
{
    public class ShopUpgradeController : IInitializable, IDisposable
    {
        private readonly IClickModel _clickModel;
        private readonly ShopConfig _shopConfig;
        private DisposableBag _dispose;

        public ShopUpgradeController(ShopConfig shopConfig, IClickModel clickModel)
        {
            _shopConfig = shopConfig;
            _clickModel = clickModel;
        }

        public void Initialize()
        {
            _clickModel.ItemInitialized += OnItemInitialized;
        }

        private void OnItemInitialized()
        {
            foreach (var (itemType, value) in _clickModel.ShopItemsLevel) {
                value.Subscribe(itemType, (i, x) => LevelChange(x, i)).AddTo(ref _dispose);
            }
        }
        private void LevelChange(ItemType itemType, int level)
        {
            var itemConfigs = _shopConfig.ShopItemConfigsMap[itemType].ValueCostPairs[level];
            var items = _clickModel.ShopItems[itemType];
            items.OnNext(new ItemValueCost(itemConfigs.Cost, itemConfigs.Value));
        }
        public void Dispose()
        {
            _dispose.Dispose();
            _clickModel.ItemInitialized -= OnItemInitialized;
        }
    }
}