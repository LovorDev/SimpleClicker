using Clicker.Scripts.Runtime.Model;

namespace Clicker.Scripts.Runtime.Service
{
    public interface IShopItemModelService
    {
        public ShopItemModel Get(ItemType itemType);
        public void Upgrade(ShopItemModel model);
    }
}