using System;
using System.Collections.Generic;
using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.Service;
using Clicker.Scripts.Runtime.View;
using ObservableCollections;
using R3;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Controller
{
    public class ShopItemsViewModel : IInitializable, IDisposable
    {
        private readonly ClickerModel _model;
        private readonly IShopItemModelService _service;
        private readonly IFactory<ShopItemView> _shopItemViewFactory;
        private readonly IShopModel _shopModel;

        private readonly Dictionary<ItemType, ShopItemViewModel> _viewModels = new Dictionary<ItemType, ShopItemViewModel>();

        public ShopItemsViewModel(IFactory<ShopItemView> shopItemViewFactory, ClickerModel model,
            IShopItemModelService service, IShopModel shopModel)
        {
            _shopItemViewFactory = shopItemViewFactory;
            _model = model;
            _service = service;
            _shopModel = shopModel;
        }

        public void Initialize()
        {
            _model.ShopItems.ObserveAdd().Select(x=>x.Value).Subscribe(CreateViewModel);
            foreach (var modelShopItem in _model.ShopItems)
            {
                CreateViewModel(modelShopItem);
            }
            _model.ShopItems.ObserveRemove().Subscribe(OnRemove);
        }
        
        private void CreateViewModel(ItemType itemType)
        {
            var itemModel = _service.Get(itemType);
            
            _model.ShopItemModels.Add(itemType, itemModel);

            var view = _shopItemViewFactory.Create();

            var viewModel = new ShopItemViewModel(new ShopItemBinder(), itemModel, view, _shopModel, _service);
            viewModel.Initialize();
            _viewModels.Add(itemType, viewModel);
        }

        private void OnRemove(CollectionRemoveEvent<ItemType> itemTypeEvent)
        {
            var itemType = itemTypeEvent.Value;
            _viewModels[itemType].Dispose();
            _viewModels.Remove(itemType);
        }
        public void Dispose()
        {
            foreach (var viewModel in _viewModels)
            {
                viewModel.Value.Dispose();
            }
        }
    }
}