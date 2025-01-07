using Blast.VisualLayer.Cannons.Components;
using Blast.VisualLayer.Enemies.Components;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Enemies.Installers
{
	public class EnemyTurretFactoryInstaller : MonoInstaller<EnemyTurretFactoryInstaller>
	{
		[SerializeField]
		private GameObject _enemyTurretPrefabRef;

		[SerializeField]
		private Transform _parentTransform;
		
		public override void InstallBindings()
		{
			Container
				.BindFactory<IEnemyTarget, EnemyTurret, EnemyTurret.Factory>()
				.FromComponentInNewPrefab(_enemyTurretPrefabRef)
				.UnderTransform(_parentTransform)
				.AsTransient();
		}
	}
}