using System;
using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.View;
using DG.Tweening;
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
                enemy.Hp.Select(x => (float)(x.Current / x.Max)).Subscribe( hp => view.HpBar.value = hp).AddTo(ref _disposable);
                view.Image.sprite = enemy.Sprite;
                view.Name.text = enemy.Name;
            }
        }
        
        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
    
    public class EnemyViewModel : ViewModel<IEnemyModel, EnemyView>
    {
        public EnemyViewModel(IBinder<IEnemyModel, EnemyView> binder, IEnemyModel model, EnemyView view) : base(binder, model, view)
        {
        }
        protected override void OnInitialize()
        {
            _model.Enemy.SkipWhile(x => x == null).Subscribe(EnemyViewAppear).AddTo(ref _disposable);
        }

        private void EnemyViewAppear(Enemy enemy)
        {
            _view.CanvasGroup.DOFade(1, .2f);
        }
    }
}