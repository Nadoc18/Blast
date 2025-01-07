using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Loader
{
    public class LoaderInstaller : MonoInstaller<LoaderInstaller>
    {
        #region Loader

        [SerializeField]
        private Loader _loader;

        #endregion
        
        #region Methods

        public override void InstallBindings()
        {
            Container
                .Bind<ILoader>()
                .FromInstance(_loader)
                .AsSingle();
        }

        #endregion
    }
}