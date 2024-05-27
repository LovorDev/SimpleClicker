using ObservableCollections;
using R3;

namespace Clicker.Scripts.Runtime.Model
{
    public class ClickerModel : IEnemyModel, IShopModel
    {
        public ObservableList<ItemType> ShopItems { get; } = new ObservableList<ItemType>();

        public ObservableDictionary<ItemType, ShopItemModel> ShopItemModels { get; } =
            new ObservableDictionary<ItemType, ShopItemModel>();
        public ReactiveProperty<Enemy> Enemy { get; } = new ReactiveProperty<Enemy>();
        public ReactiveProperty<double> Gold { get; } = new ReactiveProperty<double>(300);

        public bool TryBuy(double gold)
        {
            if (Gold.CurrentValue < gold)
            {
                return false;
            }

            Gold.Value -= gold;
            return true;
        }
    }
}