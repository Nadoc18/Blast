using Blast.DataLayer.Balances;
using Blast.DataLayer.Metadata;
using Blast.DataTypes;
using Blast.VisualLayer.Factories;
using UnityEngine;
using Zenject;

namespace Blast.DataLayer.Installers
{
	[CreateAssetMenu(
		menuName = "Blast/Data/Data Layer Installer", 
		fileName = "Data Layer Installer")]
	public class DataLayerInstaller : ScriptableObjectInstaller<DataLayerInstaller>
	{
		[SerializeField]
		private CannonMetadata[] _cannonMetadata;

		[SerializeField]
		private GameLevelMetadata[] _gameLevelsMetadata;

		[SerializeField]
		private InfraScreenMetadata[] _infraScreenMetadata;
		
		[SerializeField]
		private PlayerBalances _balances;
		
		public override void InstallBindings()
		{
			Container
				.Bind<IDataLayer>()
				.FromSubContainerResolve()
				.ByMethod(SubContainerBindings)
				.AsSingle();
		}

		private void SubContainerBindings(DiContainer subContainer)
		{
			subContainer.Bind<IDataLayer>().To<DataLayer>().AsSingle();
			subContainer.Bind<CannonMetadata[]>().FromInstance(_cannonMetadata).AsSingle();
			subContainer.Bind<GameLevelMetadata[]>().FromInstance(_gameLevelsMetadata).AsSingle();
			subContainer.Bind<InfraScreenMetadata[]>().FromInstance(_infraScreenMetadata).AsSingle();
			subContainer.Bind<IPlayerBalances>().To<PlayerBalances>().FromInstance(_balances).AsSingle();
			subContainer.Bind<IGameMetadata>().To<GameMetadata>().AsSingle();
		}
	}
}