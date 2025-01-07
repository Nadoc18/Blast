using Blast.DataTypes;
using Blast.VisualLayer.Cannons.Components;
using Blast.VisualLayer.CannonStudio.Handlers;
using Blast.VisualLayer.Factories;
using Blast.VisualLayer.Gameplay.Handlers;
using Blast.VisualLayer.Gameplay.PlayerInput;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.CannonStudio.Installers
{
	public class CannonStudioInstaller : MonoInstaller<CannonStudioInstaller>
	{
		[SerializeField]
		private PlayerCannonType _cannonType;

		[SerializeField]
		private Transform _cannonParentTransform;

		[SerializeField]
		private bool _dontInstantiateCannon;
		
		public override void InstallBindings()
		{
			Container
				.Bind<IPlayerInput>()
				.To<DesktopInputManager>()
				.AsSingle()
				.IfNotBound();

			Container
				.BindInterfacesTo<MockBackClickHandler>()
				.AsSingle();

			Container
				.Bind<PlayerCannonType>()
				.FromInstance(_cannonType)
				.AsSingle();

			Container
				.Bind<Transform>()
				.FromInstance(_cannonParentTransform)
				.AsSingle();

			Container
				.Bind<bool>()
				.FromInstance(_dontInstantiateCannon)
				.AsSingle();

			Container
				.BindInterfacesTo<StartCannonStudioHandler>()
				.AsSingle()
				.NonLazy();
			
			Container
				.BindFactory<PlayerCannonType, Transform, IEnemyTarget, PlayerCannonFactory>()
				.FromFactory<PlayerCannonFactoryImplementation>();
		}
	}
}