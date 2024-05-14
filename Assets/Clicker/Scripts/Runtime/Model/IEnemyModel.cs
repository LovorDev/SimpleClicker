using R3;

namespace Clicker.Scripts.Runtime.Model
{
    public interface IEnemyModel
    {
        ReactiveProperty<Enemy> Enemy { get; }
    }
}