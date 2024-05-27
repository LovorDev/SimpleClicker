using System;
using R3;
using UnityEngine;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Controller
{
    public class ViewModel<TM, TV> : IInitializable, IDisposable where TV : Component
    {
        protected readonly IBinder<TM, TV> _binder;
        protected readonly TM _model;
        protected readonly TV _view;
        protected DisposableBag _disposable;

        public ViewModel(IBinder<TM, TV> binder, TM model, TV view)
        {
            _binder = binder;
            _model = model;
            _view = view;
        }
        public void Dispose()
        {
            _binder?.Dispose();
        }

        public void Initialize()
        {
            Bind();
            OnInitialize();
        }
        protected virtual void OnInitialize() { }
        private void Bind()
        {
            _binder.Bind(_model, _view);
        }
    }
}