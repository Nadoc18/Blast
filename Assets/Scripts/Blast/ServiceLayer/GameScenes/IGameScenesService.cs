using Blast.DataTypes;
using Cysharp.Threading.Tasks;

namespace Blast.ServiceLayer.GameScenes
{
    public interface IGameScenesService
    {
        UniTask LoadInfraSceneIfNotLoaded(InfraScreenType sceneType);
        UniTask LoadLevelSceneIfNotLoaded(GameLevelType levelType);
        UniTask UnloadInfraScreen(InfraScreenType sceneType);
        UniTask UnloadLevelScene(GameLevelType levelType);
    }
}