using Clicker.Scripts.Runtime.Config;
using Clicker.Scripts.Runtime.Controller;
using Clicker.Scripts.Runtime.Extensions;
using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.Service;
using Clicker.Scripts.Runtime.View;
using SaveSystem;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;
using VContainer.Unity;
using SaveController = Clicker.Scripts.Runtime.Service.SaveController;

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
        
        [SerializeField]
        private MoneyView _moneyView;

        [SerializeField]
        private EnemiesConfig _enemiesConfig;
        

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ClickerModel>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.RegisterInstance(_shopConfig);
            
            RegisterSaver(builder);

            builder.RegisterEntryPoint<Startup>();

            builder.RegisterInstance(_moneyView);
            builder.RegisterEntryPoint<ViewModel<IMoneyModel, MoneyView>>(Lifetime.Scoped);
            builder.Register<MoneyBinder>(Lifetime.Transient).AsImplementedInterfaces();
            
            builder.RegisterBuildCallback(_ =>
            {
                var shopScope = CreateChild(ShopScope);
                var enemyScope = CreateChild(EnemyScope);
            });
        }
        private void EnemyScope(IContainerBuilder builder)
        {
            builder.RegisterInstance(_enemiesConfig);
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
        private  void RegisterSaver(IContainerBuilder builder)
        {
            builder.RegisterSavedContext<ShopItemsSavedData>(Lifetime.Singleton);
            builder.RegisterSavedContext<EnemySavedData>(Lifetime.Singleton);
            
            builder.Register<PlayerPrefsSaveProvider>(Lifetime.Singleton).As<ISaveProvider>();
            
            builder.RegisterEntryPoint<SaveController>();
        }
        private void S(IWriteSaveContext<ISavedData> s)
        {
            
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