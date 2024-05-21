using System;
using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using R3;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Controller
{
    public class ShopController : IInitializable, IDisposable
    {
        private readonly IClickModel _clickModel;
        private readonly IShopModel _shopModel;
        private readonly ShopView _shopView;
        private DisposableBag _dispose;
        public ShopController(IShopModel shopModel, IClickModel clickModel, ShopView shopView)
        {
            _shopModel = shopModel;
            _clickModel = clickModel;
            _shopView = shopView;
        }
        public void Dispose()
        {
            _dispose.Dispose();
            _clickModel.ItemInitialized -= OnItemInitialized;
        }

        public void Initialize()
        {
            _clickModel.ItemInitialized += OnItemInitialized;
        }

        private void OnItemInitialized()
        {
            foreach (var (itemType, itemLevel) in _clickModel.ShopItemsLevel)
            {
                _shopView.ShopItemViewsMap[itemType].Click.OnClickAsAsyncEnumerable()
                    .Where(_ => _shopModel.TryBuy(_clickModel.ShopItems[itemType].CurrentValue.Cost))
                    .Subscribe(_ => itemLevel.Value++)
                    .AddTo(ref _dispose);
            }
        }
    }
}