using R3;

namespace Clicker.Scripts.Runtime.Model
{
    public struct ShopItem
    {
        public ItemType ItemType { get; }
        public ReactiveProperty<double> Value { get; }
        public ReactiveProperty<double> Cost { get; }
        public ReactiveProperty<int> Level { get; }
    }
}