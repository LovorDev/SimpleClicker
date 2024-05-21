using R3;

namespace Clicker.Scripts.Runtime.Model
{
    public class ShopItemLevel
    {
        public ItemType ItemType { get; }
        public ShopItemLevel(ItemType itemType)
        {
            ItemType = itemType;
        }
    }
}