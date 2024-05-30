using Clicker.Scripts.Runtime.Service;
using SaveSystem;
using VContainer;

namespace Clicker.Scripts.Runtime.Extensions
{
    public static class VContainerExtension
    {

        public static RegistrationBuilder RegisterSavedContext<T>(this IContainerBuilder builder, Lifetime lifetime) where T : class, ISavedData, new()
        {
            return builder.Register<WriteSaveContext<T>>(lifetime).AsImplementedInterfaces().As<IWriteSaveContext<ISavedData>>();
        }
    }
}