using System.Threading;
using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.View;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Controller
{
    public class EnemyController : IInitializable
    {
        private readonly IClickModel _clickModel;
        private readonly IEnemyModel _enemyModel;
        private readonly EnemyView _enemyView;
        private ShopItemLevel _clickItemLevel;

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

        private void OnEnemyClick()
        {
            var currentEnemy = _enemyModel.Enemy.CurrentValue;
            var currentHp = currentEnemy.Hp.CurrentValue;
            var click = _clickModel.ShopItems[ItemType.Click].CurrentValue.Value;

            // var chance = _clickModel.ShopItemsMap[ItemType.CritChance].Value.CurrentValue <= Random.value;

            currentEnemy.Hp.OnNext(currentHp with { Current = currentHp.Current - click });
        }
    }
}