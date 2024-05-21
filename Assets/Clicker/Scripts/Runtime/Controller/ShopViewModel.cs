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
            _clickModel.ItemInitialized -= OnItemInitialized;
        }

        public void Initialize()
        {
            _clickModel.ItemInitialized += OnItemInitialized;
        }
        
        private void OnItemInitialized()
        {
            foreach (var (itemType, value) in _clickModel.ShopItems) {
                var textField = _shopView.ShopItemViewsMap[itemType];
                value
                    .Subscribe(textField, (x, text) => {
                        text.Cost.text = x.Cost.ToString(CultureInfo.InvariantCulture);
                        text.Value.text = x.Value.ToString(CultureInfo.InvariantCulture);
                    })
                    .AddTo(ref _dispose);
            }
        }
    }
}