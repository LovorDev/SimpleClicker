using R3;
using UnityEngine;

namespace Clicker.Scripts.Runtime.Model
{
    public sealed class Enemy
    {
        public Sprite Sprite { get; }
        public string Name { get; }
        public double HpMax { get; }
        public ReactiveProperty<double> Hp { get; }

        public ReactiveCommand<Unit> Click { get; }
        public Enemy(double hp, Sprite sprite, string name)
        {
            HpMax = hp;
            Hp = new ReactiveProperty<double>(hp);
            Sprite = sprite;
            Name = name;
            Click = new ReactiveCommand<Unit>();
        }
    }
}