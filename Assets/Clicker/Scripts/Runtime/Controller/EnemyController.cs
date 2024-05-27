using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.View;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Controller
{
    public class EnemyController : IInitializable
    {
        
        private readonly IEnemyModel _enemyModel;
        private readonly EnemyView _enemyView;
        private ShopItemLevel _clickItemLevel;

        public EnemyController(IEnemyModel enemyModel, EnemyView enemyView)
        {
            _enemyModel = enemyModel;
            _enemyView = enemyView;
        }

        public void Initialize()
        {
            _enemyView.ClickButton.onClick.AddListener(OnEnemyClick);
        }

        private void OnEnemyClick()
        {
            var currentEnemy = _enemyModel.Enemy.CurrentValue;
            var currentHp = currentEnemy.Hp.CurrentValue;
            // var click = _clickModel.ShopItems[ItemType.Click].CurrentValue.Value;

            // var chance = _clickModel.ShopItemsMap[ItemType.CritChance].Value.CurrentValue <= Random.value;

            currentEnemy.Hp.OnNext(currentHp with { Current = currentHp.Current - 5 });
        }
    }
}