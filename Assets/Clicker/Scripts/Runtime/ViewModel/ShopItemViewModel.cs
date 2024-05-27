using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.Service;
using Clicker.Scripts.Runtime.View;
using R3;
using UnityEngine;

namespace Clicker.Scripts.Runtime.Controller
{
    public sealed class ShopItemViewModel : ViewModel<ShopItemModel, ShopItemView>
    {
        private readonly IMoneyModel _moneyModel;
        private readonly IShopItemModelService _service;
        public ShopItemViewModel(IBinder<ShopItemModel, ShopItemView> binder, ShopItemModel model, ShopItemView view,
            IMoneyModel moneyModel, IShopItemModelService service)
            : base(binder, model, view)
        {
            _moneyModel = moneyModel;
            _service = service;
        }
        protected override void OnInitialize()
        {
            _model.TryUpgrade.Subscribe(TryBuy);
        }

        private void TryBuy(ItemType obj)
        {
            if (_moneyModel.TryBuy(_model.Value.CurrentValue))
            {
                Debug.Log("Buy: " + _model);
                _service.Upgrade(_model);
            }
        }
    }
}