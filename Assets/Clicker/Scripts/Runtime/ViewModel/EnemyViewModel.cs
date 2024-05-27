using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.View;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using R3;
using UnityEngine;

namespace Clicker.Scripts.Runtime.Controller
{
    public class EnemyViewModel : ViewModel<IEnemyModel, EnemyView>
    {
        private readonly IShopItemsModel _clickModel;
        public EnemyViewModel(IBinder<IEnemyModel, EnemyView> binder, IEnemyModel model, EnemyView view, IShopItemsModel clickModel) : base(binder, model, view)
        {
            _clickModel = clickModel;
        }
        protected override void OnInitialize()
        {
            _model.Enemy.SkipWhile(x => x == null).Subscribe(EnemyViewAppear).AddTo(ref _disposable);
        }

        private void EnemyViewAppear(Enemy enemy)
        {
            _view.CanvasGroup.DOFade(1, .2f);
            
            enemy.Click.Subscribe(TryDealDamage).AddTo(ref _disposable);
            
            void TryDealDamage(Unit _)
            {
                var currentHp = enemy.Hp.CurrentValue;
                var itemModels = _clickModel.ShopItemModels;
                var click = itemModels[ItemType.Click].Value.CurrentValue;

                var chance = itemModels[ItemType.CritChance].Value.CurrentValue <= Random.value;
                var critMp = itemModels[ItemType.Crit].Value.CurrentValue;
                
                enemy.Hp.OnNext(currentHp - (chance ? click * critMp : click));
            }
        }
    }
}