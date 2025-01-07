using Blast.DataTypes;
using Blast.VisualLayer.SelectLevel.Components;
using Blast.VisualLayer.SelectLevel.Handlers;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.SelectLevel.Installers
{
	public class SelectLevelScreenInstaller : MonoInstaller<SelectLevelScreenInstaller>
	{
		#region Editor

		[SerializeField]
		private RectTransform _buttonsListParentTransform;

		[SerializeField]
		private EnterLevelButton _enterLEvelButtonPrefabRef;

		#endregion

		#region Methods

		public override void InstallBindings()
		{
			Container
				.BindFactory<GameLevelMetadata, EnterLevelButton, EnterLevelButton.Factory>()
				.FromComponentInNewPrefab(_enterLEvelButtonPrefabRef)
				.UnderTransform(_buttonsListParentTransform)
				.AsSingle();

			Container
				.Bind<IEnterLevelHandler>()
				.To<EnterLevelHandler>()
				.AsSingle();

			Container
				.Bind<IHudPlusCurrencyClickHandler>()
				.To<HudPlusCurrencyClickHandler>()
				.AsSingle();
			
			Container
				.BindInterfacesTo<SelectLevelScreenInitHandler>()
				.AsSingle()
				.NonLazy();
		}

		#endregion
	}
}