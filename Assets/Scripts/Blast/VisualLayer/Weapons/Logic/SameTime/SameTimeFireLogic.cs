using Blast.VisualLayer.Weapons.Projectiles;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Weapons.Logic.SameTime
{
	public class SameTimeFireLogic : IWeaponLogic
	{
		#region Injects

		[Inject]
		private WeaponLogicParams _weaponLogicParams;

		[Inject]
		private Projectile.Factory _projectileFactory;
		
		#endregion

		#region Fields

		private float _lastLaunchTime;

		#endregion
		
		#region Methods

		public bool Fire(Transform[] launchingPoints)
		{
			if (launchingPoints == null || launchingPoints.Length <= 0)
			{
				return false;
			}

			var isInDelay = Time.time - _lastLaunchTime < _weaponLogicParams.LaunchDelay;
			if (isInDelay)
			{
				return false;
			}

			for(var i=0; i < launchingPoints.Length; i++)
			{
				var lp = launchingPoints[i];
				var projectile = _projectileFactory.Create(lp.position);
				projectile.Fire(lp.forward, _weaponLogicParams.ProjectileSpeed,
					_weaponLogicParams.ProjectileMaxDistance, _weaponLogicParams.Damage);
			}

			_lastLaunchTime = Time.time;
			return true;
		}

		#endregion
	}
}