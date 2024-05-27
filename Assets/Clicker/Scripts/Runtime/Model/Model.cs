using R3;

namespace Clicker.Scripts.Runtime.Model
{
    public class ShopItemModel
    {
        public ShopItemModel(ItemType itemType, ReactiveProperty<double> cost, ReactiveProperty<double> value,
            ReactiveCommand<ItemType> tryUpgrade)
        {
            ItemType = itemType;
            Cost = cost;
            Value = value;
            TryUpgrade = tryUpgrade;
        }
        public ItemType ItemType { get; }
        public ReactiveProperty<double> Cost { get; }
        public ReactiveProperty<double> Value { get; }
        public ReactiveCommand<ItemType> TryUpgrade { get; }
        public override string ToString()
        {
            return
                $"{nameof(ItemType)}: {ItemType}, {nameof(Cost)}: {Cost}, {nameof(Value)}: {Value}, {nameof(TryUpgrade)}: {TryUpgrade}";
        }
    }
}