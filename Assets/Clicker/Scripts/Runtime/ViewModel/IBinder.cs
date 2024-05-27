using System;
using UnityEngine;

namespace Clicker.Scripts.Runtime.Controller
{
    public interface IBinder<in TM, in TV> : IDisposable where TV: Component
    {
        public void Bind(TM model, TV view);
    }
}