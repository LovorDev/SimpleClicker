using System.Collections.Generic;
using Clicker.Scripts.Runtime.Config;
using Clicker.Scripts.Runtime.Model;
using ObservableCollections;
using R3;
using SaveSystem;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Service
{
    public class ShopItemModelService : IInitializable, IShopItemModelService
    {
        private readonly ClickerModel _clickerModel;
        private readonly ISaveContext<ShopItemsSavedData> _saveContext;
        private readonly ShopConfig _shopConfig;

        private Dictionary<ItemType, int> _itemsLevel = new Dictionary<ItemType, int>();

        public ShopItemModelService(ISaveContext<ShopItemsSavedData> saveContext, ShopConfig shopConfig, ClickerModel clickerModel)
        {
            _saveContext = saveContext;
            _shopConfig = shopConfig;
            _clickerModel = clickerModel;
        }

        public void Initialize()
        {
            _clickerModel.ShopItemModels.ObserveAdd().Select(x => x.Value).Subscribe(ActualizeModel);
            _saveContext.LoadingData.Subscribe(OnNewData);
        }
        private void OnNewData(ISavedData obj)
        {
            _itemsLevel = ((ShopItemsSavedData)obj).ItemsLevel;
            foreach (var item in _clickerModel.ShopItemModels)
            {
                ActualizeModel(item);
            }
        }

        public ShopItemModel Get(ItemType itemType)
        {
            return new ShopItemModel(itemType, new ReactiveProperty<double>(0),
                new ReactiveProperty<double>(0), new ReactiveCommand<ItemType>());
        }
        public void Upgrade(ShopItemModel model)
        {
            var newLevel = _itemsLevel[model.ItemType] + 1;
            _itemsLevel[model.ItemType] = newLevel;

            UpdateModel(model, newLevel);
        }

        private void ActualizeModel(KeyValuePair<ItemType, IShopItemModel> itemModel)
        {
            var level = 0;
            var itemType = itemModel.Key;

            if (!_itemsLevel.TryAdd(itemType, level))
            {
                level = _itemsLevel[itemType];
            }

            var model = itemModel.Value;

            UpdateModel((ShopItemModel) model, level);
        }
        private void UpdateModel(ShopItemModel model, int level)
        {
            var newValues = _shopConfig.ShopItemConfigsMap[model.ItemType].ValueCostPairs[level];

            model.NextCost(newValues.Cost);
            model.NextValue(newValues.Value);
        }
    }
}