using System;
using System.Globalization;
using Clicker.Scripts.Runtime.Controller;
using Clicker.Scripts.Runtime.Model;
using Clicker.Scripts.Runtime.View;
using R3;

namespace Clicker.Scripts.Runtime.Root
{
    public class MoneyBinder : IBinder<IMoneyModel, MoneyView>
    {
        private IDisposable _disposable;
        public void Bind(IMoneyModel model, MoneyView view)
        {
            _disposable =  model.Gold.Subscribe(x => view.MoneyText.text = $"{x.ToString(CultureInfo.InvariantCulture)} $");
        }
        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}