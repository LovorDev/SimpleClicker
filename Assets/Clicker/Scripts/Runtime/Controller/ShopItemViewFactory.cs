using Clicker.Scripts.Runtime.View;
using R3;
using UnityEngine.Pool;

namespace Clicker.Scripts.Runtime.Controller
{
    public class ShopItemViewFactory : IFactory<ShopItemView>
    {
        private readonly IObjectPool<ShopItemView> _pool;

        public ShopItemViewFactory(IObjectPool<ShopItemView> pool)
        {
            _pool = pool;
        }

        public ShopItemView Create()
        {
            return _pool.Get();
        }
        public void Release(ShopItemView obj)
        {
            _pool.Release(obj);
        }
    }
}