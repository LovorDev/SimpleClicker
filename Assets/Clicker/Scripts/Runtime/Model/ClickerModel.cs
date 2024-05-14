using R3;

namespace Clicker.Scripts.Runtime.Model
{
    public class ClickerModel: IClickModel, IEnemyModel, IShopModel
    {
        public ReplaySubject<ShopItem> ShopItems { get; } = new ReplaySubject<ShopItem>();
        
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
    }
}