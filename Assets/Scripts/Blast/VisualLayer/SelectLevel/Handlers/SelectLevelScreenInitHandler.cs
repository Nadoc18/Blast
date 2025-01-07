using Blast.DataLayer;
using Blast.VisualLayer.SelectLevel.Components;
using Zenject;

namespace Blast.VisualLayer.SelectLevel.Handlers
{
	public class SelectLevelScreenInitHandler : IInitializable
	{
		[Inject]
		private IDataLayer _dataLayer;

		[Inject]
		private EnterLevelButton.Factory _enterLevelButton;
		
		public void Initialize()
		{
			var allLevels = _dataLayer.Metadata.GetLevelsMetadata();
			foreach (var levelMetadata in allLevels)
			{
				_enterLevelButton.Create(levelMetadata);
			}
		}
	}
}