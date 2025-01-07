using System;
using Blast.DataLayer;
using Blast.DataTypes;
using Blast.ServiceLayer.GameScenes;
using Blast.VisualLayer.Loader;
using Blast.VisualLayer.Popups.SelectCannon;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Blast.VisualLayer.SelectLevel.Handlers
{
	public class EnterLevelHandler : IEnterLevelHandler
	{
		[Inject]
		private IDataLayer _dataLayer;

		[Inject]
		private ILoader _loader;

		[Inject]
		private IGameScenesService _scenesService;

		[Inject]
		private SelectCannonPopup.Factory _selectCannonPopup;
		
		public async void Execute(GameLevelType levelType)
		{
			var popup = _selectCannonPopup.Create();
			var result = await popup.WaitForResult();
			if (result.IsCanceled)
			{
				return;
			}

			var metadata = _dataLayer.Metadata.GetLevelMetadata(levelType);
			metadata.SetCannon(result.SelectedCannonType);
		
			_loader.ResetData();
			await _loader.FadeIn();
			_loader.SetProgress(0.1f, "Initializing");
			await UniTask.Delay(TimeSpan.FromSeconds(1));
			_scenesService.UnloadInfraScreen(InfraScreenType.SelectLevel);
			_loader.SetProgress(0.2f, "Loading the level scene");
			await UniTask.Delay(TimeSpan.FromSeconds(1));
			
			await _scenesService.LoadLevelSceneIfNotLoaded(metadata.LevelType);
			_loader.SetProgress(0.3f, "Loading the dependencies");
			await UniTask.Delay(TimeSpan.FromSeconds(1));
			await _scenesService.LoadInfraSceneIfNotLoaded(InfraScreenType.Loader);
			await _scenesService.LoadInfraSceneIfNotLoaded(InfraScreenType.GamePopups);
			_loader.SetProgress(0.8f, "Entering the level");
			await UniTask.Delay(TimeSpan.FromSeconds(1));
			await _loader.FadeOut();
		}
	}
}