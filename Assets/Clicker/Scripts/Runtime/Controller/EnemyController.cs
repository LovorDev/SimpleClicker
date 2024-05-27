using Clicker.Scripts.Runtime.Config;
using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.Service;
using Cysharp.Threading.Tasks;
using R3;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Controller
{
    public class EnemyController : IInitializable
    {
        private const string CurrentEnemy = nameof(CurrentEnemy);

        private readonly IEnemyModel _enemyModel;
        private readonly EnemiesConfig _enemiesConfig;
        private readonly ISaveSystem _saveSystem;
        public EnemyController(IEnemyModel enemyModel, EnemiesConfig enemiesConfig, ISaveSystem saveSystem)
        {
            _enemyModel = enemyModel;
            _enemiesConfig = enemiesConfig;
            _saveSystem = saveSystem;
        }

        public void Initialize()
        {
            LoadEnemy().Forget();
        }
        private async UniTaskVoid LoadEnemy()
        {
            var enemyLevel = await _saveSystem.Load<int>(CurrentEnemy);
            SetNewEnemy(enemyLevel).Forget();
        }

        private async UniTask SetNewEnemy(int level)
        {
            if (level >= _enemiesConfig.EnemyConfigs.Count)
            {
                _enemyModel.Enemy.OnCompleted();
                return;
            }
            var current = _enemiesConfig.EnemyConfigs[level];
            var newEnemy = new Enemy(current.HpMax, current.Sprite, current.Name);
            _enemyModel.Enemy.OnNext(newEnemy);

            await newEnemy.Hp.FirstAsync(x => x <= 0);
            SetNewEnemy(++level).Forget();
        }
    }
}