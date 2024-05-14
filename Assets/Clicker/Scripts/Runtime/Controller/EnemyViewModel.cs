using System;
using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.View;
using DG.Tweening;
using R3;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Controller
{
    public class EnemyViewModel : IInitializable
    {
        private readonly IEnemyModel _enemyModel;
        private readonly EnemyView _enemyView;
        public EnemyViewModel(IEnemyModel enemyModel, EnemyView enemyView)
        {
            _enemyModel = enemyModel;
            _enemyView = enemyView;
        }
        public void Initialize()
        {
            _enemyModel.Enemy.SkipWhile(x=> x==null).Subscribe(OnNewEnemy);
        }

        private void OnNewEnemy(Enemy enemy)
        {
            EnemyViewAppear();
            enemy.Hp.Select(x => (float)(x.Current / x.Max)).Subscribe(OnHpChange);
            _enemyView.Image.sprite = enemy.Sprite;
            _enemyView.Name.text = enemy.Name;
        }

        private void OnHpChange(float hpPercent)
        {
            _enemyView.HpBar.value = hpPercent;
        }

        private void EnemyViewAppear()
        {
            _enemyView.CanvasGroup.DOFade(1, .2f);
        }
    }
}