using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Weapons.Projectiles
{
	[CreateAssetMenu(
		menuName = "Blast/Weapons/Projectiles/Projectile Factory Installer",
		fileName = "Projectile Factory Installer")]
	public class ProjectileFactoryInstaller : ScriptableObjectInstaller<ProjectileFactoryInstaller>
	{
		#region Editor

		[SerializeField]
		private GameObject _projectileCorePrefabRef;
		
		[SerializeField]
		private GameObject _muzzleFlashPrefabRef;
		
		[SerializeField]
		private GameObject _collisionExplosionPrefabRef;

		#endregion

		#region Methods

		public override void InstallBindings()
		{
			Container
				.Bind<GameObject>()
				.WithId(WeaponsBindingIds.MuzzleFlashPrefabRef)
				.FromInstance(_muzzleFlashPrefabRef)
				.AsTransient();
			
			Container
				.Bind<GameObject>()
				.WithId(WeaponsBindingIds.CollisionExplosionPrefabRef)
				.FromInstance(_collisionExplosionPrefabRef)
				.AsTransient();
			
			Container
				.BindFactory<Vector3, Projectile, Projectile.Factory>()
				.FromComponentInNewPrefab(_projectileCorePrefabRef)
				.AsSingle();
		}

		#endregion
	}
}