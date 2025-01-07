using Blast.DataLayer;
using Blast.DataTypes;
using Blast.VisualLayer.Cannons.Components;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Factories
{
	public class PlayerCannonFactory : PlaceholderFactory<PlayerCannonType, Transform, IEnemyTarget>
	{
	}

	public class PlayerCannonFactoryImplementation : IFactory<PlayerCannonType, Transform, IEnemyTarget>
	{
		[Inject]
		private IDataLayer _dataLayer;

		[Inject]
		private DiContainer _container;
		
		public IEnemyTarget Create(PlayerCannonType cannonType, Transform parentTransform)
		{
			var prefabRef = _dataLayer.Metadata.GetPrefabForCannon(cannonType);
			var cannonInstance = _container.InstantiatePrefab(prefabRef, parentTransform);
			var enemyTarget = cannonInstance.GetComponent<IEnemyTarget>();
			return enemyTarget;
		}
	}
}