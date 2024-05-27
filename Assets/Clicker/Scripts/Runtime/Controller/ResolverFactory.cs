using System;
using VContainer;

namespace Clicker.Scripts.Runtime.Controller
{
    public class ResolverFactory<T> : IFactory<T> where T : IDisposable
    {
        private readonly IObjectResolver _resolver;

        public ResolverFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        public T Create()
        {
            return _resolver.Resolve<T>();
        }
        public void Release(T obj)
        {
            obj.Dispose();
        }
    }
}