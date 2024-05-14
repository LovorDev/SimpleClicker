using Clicker.Scripts.Runtime.Config;
using Clicker.Scripts.Runtime.Controller;
using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Root
{
    public class ClickerScope : LifetimeScope
    {
        [SerializeField]
        private ShopConfig _shopConfig;

        [SerializeField]
        private ShopView _shopView;

        [SerializeField]
        private EnemyView _enemyView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_shopConfig);
            builder.RegisterInstance(_shopView);
            builder.RegisterInstance(_enemyView);

            builder.Register<ClickerModel>(Lifetime.Scoped).AsImplementedInterfaces();

            builder.RegisterEntryPoint<EnemyController>();
            builder.RegisterEntryPoint<EnemyViewModel>();
            builder.RegisterEntryPoint<ShopController>();
            builder.RegisterEntryPoint<ShopUpgradeController>();
            builder.RegisterEntryPoint<ShopViewModel>();
        }
    }
}