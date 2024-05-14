using R3;

namespace Clicker.Scripts.Runtime.Model
{
    public interface IClickModel
    {
        public ReplaySubject<ShopItem> ShopItems { get; }
    }
}