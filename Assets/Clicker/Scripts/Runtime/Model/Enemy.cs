using R3;
using UnityEngine;

namespace Clicker.Scripts.Runtime.Model
{
    public sealed class Enemy
    {
        public Sprite Sprite { get; }
        public string Name { get; }
        public ReactiveProperty<Hp> Hp { get; }

        public Enemy(Hp hp, Sprite sprite, string name)
        {
            Hp = new ReactiveProperty<Hp>();
            Hp.OnNext(hp);

            Sprite = sprite;
            Name = name;
        }
    }
}