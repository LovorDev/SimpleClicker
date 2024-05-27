using System;
using R3;

namespace Clicker.Scripts.Runtime.Model
{
    public class ShopItemModel : IShopItemModel
    {
        public ItemType ItemType { get; }
        public ReactiveCommand<ItemType> TryUpgrade { get; }
        public ReadOnlyReactiveProperty<double> Cost => _costField.ToReadOnlyReactiveProperty();
        public ReadOnlyReactiveProperty<double> Value => _valueField.ToReadOnlyReactiveProperty();
        
        private readonly ReactiveProperty<double> _costField;
        private readonly ReactiveProperty<double> _valueField;

        public ShopItemModel(ItemType itemType, ReactiveProperty<double> cost, ReactiveProperty<double> value,
            ReactiveCommand<ItemType> tryUpgrade)
        {
            ItemType = itemType;
            _costField = cost;
            _valueField = value;
            TryUpgrade = tryUpgrade;
        }

        public override string ToString()
        {
            return
                $"{nameof(ItemType)}: {ItemType}, {nameof(Cost)}: {Cost}, {nameof(Value)}: {Value}, {nameof(TryUpgrade)}: {TryUpgrade}";
        }
        public void NextCost(double newCost)
        {
            _costField.OnNext(newCost);
        }
        public void NextValue(double newValue)
        {
            _valueField.OnNext(newValue);
        }
    }

    public interface IShopItemModel
    {
        public ReadOnlyReactiveProperty<double> Cost { get; }
        public ReadOnlyReactiveProperty<double> Value { get; }
    }
}