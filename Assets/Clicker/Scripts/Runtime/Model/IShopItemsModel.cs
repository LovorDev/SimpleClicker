using System.Collections.Generic;
using ObservableCollections;

namespace Clicker.Scripts.Runtime.Model
{
    public interface IShopItemsModel
    {
        ObservableDictionary<ItemType, IShopItemModel> ShopItemModels { get; }
    }
}