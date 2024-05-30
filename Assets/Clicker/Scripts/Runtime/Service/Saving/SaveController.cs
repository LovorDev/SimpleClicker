using System.Collections.Generic;
using SaveSystem;
using VContainer.Unity;

namespace Clicker.Scripts.Runtime.Service
{
    public class SaveController : SaveSystem.SaveController , IInitializable
    {
        public SaveController(IEnumerable<IWriteSaveContext<ISavedData>> saveSystems, IEnumerable<ISaveProvider> saveProviders) : base(saveSystems, saveProviders)
        {
        }
    }
}