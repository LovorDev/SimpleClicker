using Clicker.Scripts.Runtime.Config;
using Clicker.Scripts.Runtime.Controller;
using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.Service;
using Clicker.Scripts.Runtime.View;
using UnityEngine;
using UnityEngine.Pool;
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

        [SerializeField]
        private ShopItemView _shopItemPrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ClickerModel>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.RegisterInstance(_shopConfig);
            
            RegisterServices(builder);

            builder.RegisterEntryPoint<Startup>();
            
            builder.RegisterBuildCallback(_ =>
            {
                var shopScope = CreateChild(ShopScope);
                var enemyScope = CreateChild(EnemyScope);
            });
        }
        private void EnemyScope(IContainerBuilder builder)
        {
            builder.RegisterInstance(_enemyView);

            builder.RegisterEntryPoint<EnemyController>();
            builder.RegisterEntryPoint<EnemyViewModel>();

            builder.Register<EnemyBinder>(Lifetime.Transient).AsImplementedInterfaces();
        }
        private void ShopScope(IContainerBuilder builder)
        {
            builder.RegisterInstance(_shopView);

            builder.RegisterInstance(_shopItemPrefab);
            builder.RegisterInstance(CreateShopItemPool());

            builder.Register<ShopItemViewFactory>(Lifetime.Scoped).As<IFactory<ShopItemView>>();

            builder.RegisterEntryPoint<ShopItemModelService>().As<IShopItemModelService>();
            
            builder.RegisterEntryPoint<ShopItemsViewModel>();
        }
        private  void RegisterServices(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<PlayerPrefsSaver>().As<ISaveSystem>();
        }
        private IObjectPool<ShopItemView> CreateShopItemPool()
        {
            return new ObjectPool<ShopItemView>(() => Instantiate(_shopItemPrefab, _shopView.ItemsParent),
                x => x.gameObject.SetActive(true),
                x => x.gameObject.SetActive(false),
                Destroy);
        }
    }
}