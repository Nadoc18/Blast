using System;
using Blast.DataTypes;
using Blast.ServiceLayer.GameScenes;
using Blast.ServiceLayer.TimeControl;
using Blast.VisualLayer.Loader;
using Blast.VisualLayer.Popups.YesNo;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Blast.VisualLayer.Gameplay.Handlers
{
	public class HudBackClickHandler : IHudBackClickHandler
	{
		[Inject]
		private ILoader _loader;

		[Inject]
		private IGameScenesService _sceneService;

		[Inject]
		private GameLevelType _currentLevelType;

		[Inject]
		private ITimeController _timeController;

		[Inject]
		private YesNoPopup.Factory _yesNoPopup;
		
		public async UniTask Execute()
		{
			_timeController.PauseGameplay();
			var popup = _yesNoPopup.Create(YesNoPopupArgs.Default);
			var result = await popup.WaitForResult();
			_timeController.UnpauseGameplay();
			if (result.IsNo)
			{
				return;
			}

			_loader.ResetData();
			await _loader.FadeIn();
			_loader.SetProgress(0.1f, "Going to the level selection");
			await UniTask.Delay(TimeSpan.FromSeconds(1));
			_loader.SetProgress(0.2f, "Unloading the level");
			await _sceneService.UnloadLevelScene(_currentLevelType);
			await UniTask.Delay(TimeSpan.FromSeconds(1));
			_loader.SetProgress(0.4f, "Loading levels list");
			await _sceneService.LoadInfraSceneIfNotLoaded(InfraScreenType.SelectLevel);
			await _sceneService.LoadInfraSceneIfNotLoaded(InfraScreenType.Loader);
			await _sceneService.LoadInfraSceneIfNotLoaded(InfraScreenType.GamePopups);
			await UniTask.Delay(TimeSpan.FromSeconds(1));
			_loader.SetProgress(0.9f, "Completing");
			await UniTask.Delay(TimeSpan.FromSeconds(1));
			await _loader.FadeOut();
		}
	}
}