using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.Service;
using Clicker.Scripts.Runtime.View;
using R3;
using UnityEngine;

namespace Clicker.Scripts.Runtime.Controller
{
    public sealed class ShopItemViewModel : ViewModel<ShopItemModel, ShopItemView>
    {
        private readonly IShopModel _shopModel;
        private readonly IShopItemModelService _service;
        public ShopItemViewModel(IBinder<ShopItemModel, ShopItemView> binder, ShopItemModel model, ShopItemView view,
            IShopModel shopModel, IShopItemModelService service)
            : base(binder, model, view)
        {
            _shopModel = shopModel;
            _service = service;
        }
        protected override void OnInitialize()
        {
            _model.TryUpgrade.Subscribe(TryBuy);
        }

        private void TryBuy(ItemType obj)
        {
            if (_shopModel.TryBuy(_model.Value.CurrentValue))
            {
                _service.Upgrade(_model);
                Debug.Log("Buy: " + _model);
            }
        }
    }
}