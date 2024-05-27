using System;
using System.Linq;
using Clicker.Scripts.Runtime.Config;
using Clicker.Scripts.Runtime.Model;
using IInitializable = VContainer.Unity.IInitializable;

namespace Clicker.Scripts.Runtime.Root
{
    public class Startup : IInitializable
    {
        private readonly ClickerModel _model;
        private readonly ShopConfig _shopConfig;

        public Startup(ShopConfig shopConfig, ClickerModel model)
        {
            _shopConfig = shopConfig;
            _model = model;
        }

        public void Initialize()
        {
            foreach (var item in _shopConfig.ItemConfigs)
            {
                _model.ShopItems.Add(item.ItemType);
            }
        }
    }
}