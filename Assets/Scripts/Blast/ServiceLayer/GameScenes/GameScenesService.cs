using Blast.DataLayer;
using Blast.DataTypes;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace Blast.ServiceLayer.GameScenes
{
    public class GameScenesService : IGameScenesService
    {
        #region Injects

        [Inject]
        private IDataLayer _dataLayer;

        [Inject]
        private ZenjectSceneLoader _sceneLoader;
        
        #endregion
        
        #region Methods

        public async UniTask LoadInfraSceneIfNotLoaded(InfraScreenType sceneType)
        {
            if (IsInfraSceneLoaded(sceneType))
            {
                return;
            }

            var metadata = _dataLayer.Metadata.GetInfraScreenMetadata(sceneType);
            await _sceneLoader.LoadSceneAsync(metadata.SceneBuildIndex, LoadSceneMode.Additive);
        }

        public async UniTask LoadLevelSceneIfNotLoaded(GameLevelType levelType)
        {
            if (IsLevelSceneLoaded(levelType))
            {
                return;
            }
            var metadata = _dataLayer.Metadata.GetLevelMetadata(levelType);
            await _sceneLoader.LoadSceneAsync(metadata.LevelSceneBuildIndex, LoadSceneMode.Additive);
        } 
        
        public async UniTask UnloadInfraScreen(InfraScreenType sceneType)
        {
            var metadata = _dataLayer.Metadata.GetInfraScreenMetadata(sceneType);
            await SceneManager.UnloadSceneAsync(metadata.SceneBuildIndex);
        }

        public async UniTask UnloadLevelScene(GameLevelType levelType)
        {
            var metadata = _dataLayer.Metadata.GetLevelMetadata(levelType);
            await SceneManager.UnloadSceneAsync(metadata.LevelSceneBuildIndex);
        }

        private bool IsLevelSceneLoaded(GameLevelType levelType)
        {
            try
            {
                var levelMetadata = _dataLayer.Metadata.GetLevelMetadata(levelType);
                var scene = SceneManager.GetSceneByBuildIndex(levelMetadata.LevelSceneBuildIndex);
                return scene.isLoaded;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        private bool IsInfraSceneLoaded(InfraScreenType sceneType)
        {
            try
            {
                var screenMetadata = _dataLayer.Metadata.GetInfraScreenMetadata(sceneType);
                var scene = SceneManager.GetSceneByBuildIndex(screenMetadata.SceneBuildIndex);
                return scene.isLoaded;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        #endregion
    }
}