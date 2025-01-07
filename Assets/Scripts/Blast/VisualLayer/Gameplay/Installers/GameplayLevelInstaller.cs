using Blast.DataTypes;
using Blast.VisualLayer.Cannons.Components;
using Blast.VisualLayer.Factories;
using Blast.VisualLayer.Gameplay.Handlers;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Gameplay.Installers
{
	public class GameplayLevelInstaller : MonoInstaller<GameplayLevelInstaller>
	{
		#region Editor

		[SerializeField]
		private Transform _cannonParentTransform;

		[SerializeField]
		private GameLevelType _currentLevelType;

		#endregion

		#region Methods

		public override void InstallBindings()
		{
			Container
				.Bind<GameLevelType>()
				.FromInstance(_currentLevelType)
				.AsSingle();

			Container
				.Bind<Transform>()
				.FromInstance(_cannonParentTransform)
				.AsSingle();

			Container
				.BindInterfacesTo<GameplayLevelStartHandler>()
				.AsSingle()
				.NonLazy();
			
			Container
				.Bind<IHudBackClickHandler>()
				.To<HudBackClickHandler>()
				.AsSingle();
			
			Container
				.BindFactory<PlayerCannonType, Transform, IEnemyTarget, PlayerCannonFactory>()
				.FromFactory<PlayerCannonFactoryImplementation>();
		}

		#endregion
	}
}