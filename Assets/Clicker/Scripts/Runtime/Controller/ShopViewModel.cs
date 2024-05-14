using System;
using System.Globalization;
using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.View;
using R3;
using TMPro;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Controller
{
    public class ShopViewModel : IInitializable, IDisposable
    {
        private readonly IClickModel _clickModel;

        private DisposableBag _dispose;
        private readonly ShopView _shopView;
        public ShopViewModel(IClickModel clickModel, ShopView shopView)
        {
            _clickModel = clickModel;
            _shopView = shopView;
        }
        public void Dispose()
        {
            _dispose.Dispose();
        }

        public void Initialize()
        {
            _clickModel.ShopItems.Select(_shopView.ShopItemViewsMap, (x, y) => (x, y[x.ItemType])).Subscribe(Bind);
        }

        private void Bind((ShopItem, ShopItemView) shopItemPair)
        {
            var (shopItem, itemView) = shopItemPair;
            BindToText(shopItem.Cost, itemView.Cost);
            BindToText(shopItem.Value, itemView.Value);
        }

        private void BindToText(Observable<double> property, TMP_Text textField)
        {
            property
                .Subscribe(textField, (x, text) => text.text = x.ToString(CultureInfo.InvariantCulture))
                .AddTo(ref _dispose);
        }
    }
}