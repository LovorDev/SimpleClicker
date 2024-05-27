using R3;

namespace Clicker.Scripts.Runtime.Model
{
    public interface IMoneyModel
    {
        ReactiveProperty<double> Gold { get; }
        bool TryBuy(double gold);
    }
}