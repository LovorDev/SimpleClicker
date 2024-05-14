using Clicker.Scripts.Runtime.Config;
using Clicker.Scripts.Runtime.Model;
using R3;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Controller
{
    public class ShopUpgradeController : IInitializable
    {
        private readonly IClickModel _clickModel;
        private readonly ShopConfig _shopConfig;
        
        public ShopUpgradeController(ShopConfig shopConfig, IClickModel clickModel)
        {
            _shopConfig = shopConfig;
            _clickModel = clickModel;
        }

        public void Initialize()
        {
            _clickModel.ShopItems.Subscribe(EachItem);
        }
        private void EachItem(ShopItem shopItem)
        {
            shopItem.Level.Subscribe(shopItem, (i, x) => LevelChange(x, i));
        }
        private void LevelChange(ShopItem obj, int i)
        {
            var newValues = _shopConfig.ShopItemConfigsMap[obj.ItemType].ValueCostPairs[i];
            obj.Cost.Value = newValues.Cost;
            obj.Value.Value = newValues.Value;
        }
    }
}