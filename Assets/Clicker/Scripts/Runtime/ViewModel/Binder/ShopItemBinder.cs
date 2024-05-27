using System;
using System.Globalization;
using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.View;
using R3;

namespace Clicker.Scripts.Runtime.Controller
{
    public sealed class ShopItemBinder : IBinder<ShopItemModel, ShopItemView>
    {
        private DisposableBag _disposable;
        public void Bind(ShopItemModel model, ShopItemView view)
        {
            view.ItemType.text = model.ItemType.ToString();

            model.Cost.Subscribe(x => view.Cost.text = x.ToString(CultureInfo.InvariantCulture)).AddTo(ref _disposable);
            model.Value.Subscribe(x => view.Value.text = x.ToString(CultureInfo.InvariantCulture)).AddTo(ref _disposable);
            view.Click.OnClickAsObservable().Subscribe((x) => model.TryUpgrade.Execute(model.ItemType)).AddTo(ref _disposable);
        }
        
        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}