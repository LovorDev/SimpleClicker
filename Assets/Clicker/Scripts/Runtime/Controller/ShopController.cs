using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using R3;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Controller
{
    public class ShopController : IInitializable
    {
        private readonly IClickModel _clickModel;
        private readonly IShopModel _shopModel;
        private readonly ShopView _shopView;
        public ShopController(IShopModel shopModel, IClickModel clickModel, ShopView shopView)
        {
            _shopModel = shopModel;
            _clickModel = clickModel;
            _shopView = shopView;
        }

        public void Initialize()
        {
            _clickModel.ShopItems
                .Select(_shopView.ShopItemViewsMap, (x, y) => (x, y[x.ItemType]))
                .Subscribe(HandleClick);
        }

        private void HandleClick((ShopItem shopItem, ShopItemView shopItemView) shopItem)
        {
            var buyingSequence = shopItem.shopItemView.Click
                .OnClickAsAsyncEnumerable()
                .Select(x => new { shopItem.shopItem, IsBuy = _shopModel.TryBuy(shopItem.shopItem.Cost.CurrentValue) });
            
            buyingSequence
                .Where(x => x.IsBuy)
                .Subscribe(x => x.shopItem.Level.Value++);
        }
    }
}