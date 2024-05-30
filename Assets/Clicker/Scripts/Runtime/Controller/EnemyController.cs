using Clicker.Scripts.Runtime.Config;
using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.Service;
using Cysharp.Threading.Tasks;
using R3;
using SaveSystem;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Controller
{
    public class EnemyController : IInitializable
    {
        private readonly IEnemyModel _enemyModel;
        private readonly EnemiesConfig _enemiesConfig;
        private readonly ISaveContext<EnemySavedData> _saveContext;
        public EnemyController(IEnemyModel enemyModel, EnemiesConfig enemiesConfig, ISaveContext<EnemySavedData> saveContext)
        {
            _enemyModel = enemyModel;
            _enemiesConfig = enemiesConfig;
            _saveContext = saveContext;
        }

        public void Initialize()
        {
            _saveContext.LoadingData.Subscribe(OnDataChange);
        }
        private void OnDataChange(ISavedData enemyLevel)
        {          
            SetNewEnemy(((EnemySavedData)enemyLevel).Level).Forget();
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