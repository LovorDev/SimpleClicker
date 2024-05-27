using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.View;
using R3;

namespace Clicker.Scripts.Runtime.Controller
{
    public class EnemyBinder : IBinder<IEnemyModel, EnemyView>
    {
        private DisposableBag _disposable;
        public void Bind(IEnemyModel model, EnemyView view)
        {
            model.Enemy.SkipWhile(x => x == null).Subscribe(OnNewEnemy).AddTo(ref _disposable);
            void OnNewEnemy(Enemy enemy)
            {
                enemy.Hp.Select(x => (float)(x/ enemy.HpMax)).Subscribe( hp => view.HpBar.value = hp).AddTo(ref _disposable);
                
                view.ClickButton.OnClickAsObservable().Subscribe(enemy.Click.Execute);
                
                view.Image.sprite = enemy.Sprite;
                view.Name.text = enemy.Name;
            }
        }
        
        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}