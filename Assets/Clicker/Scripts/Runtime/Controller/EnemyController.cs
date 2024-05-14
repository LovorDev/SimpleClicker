using System.Threading;
using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.View;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Controller
{
    public class EnemyController : IInitializable, IAsyncStartable
    {
        private readonly IClickModel _clickModel;
        private readonly IEnemyModel _enemyModel;
        private readonly EnemyView _enemyView;
        private ShopItem _clickItem;

        public EnemyController(IEnemyModel enemyModel, EnemyView enemyView, IClickModel clickModel)
        {
            _enemyModel = enemyModel;
            _enemyView = enemyView;
            _clickModel = clickModel;
        }

        public void Initialize()
        {
            _enemyView.ClickButton.onClick.AddListener(OnEnemyClick);
        }
        public async UniTask StartAsync(CancellationToken cancellation)
        {
            _clickItem = await _clickModel.ShopItems.FirstAsync(x=>x.ItemType == ItemType.Click, cancellationToken: cancellation);
        }

        private void OnEnemyClick()
        {
            var currentEnemy = _enemyModel.Enemy.CurrentValue;
            var currentHp = currentEnemy.Hp.CurrentValue;
            var click = _clickItem.Value.CurrentValue;

            // var chance = _clickModel.ShopItemsMap[ItemType.CritChance].Value.CurrentValue <= Random.value;

            currentEnemy.Hp.OnNext(currentHp with { Current = currentHp.Current - click });
        }
    }
}