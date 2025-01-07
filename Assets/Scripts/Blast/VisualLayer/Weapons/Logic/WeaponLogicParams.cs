using System;
using UnityEngine;

namespace Blast.VisualLayer.Weapons.Logic
{
	[Serializable]
	public class WeaponLogicParams
	{
		#region Fields

		[SerializeField]
		private float _projectileSpeed;

		[SerializeField]
		private int _damage;

		[SerializeField]
		private float _launchDelay;

		[SerializeField]
		private float _projectileMaxDistance;
		
		#endregion

		#region Properties

		public float ProjectileSpeed => _projectileSpeed;

		public int Damage => _damage;

		public float LaunchDelay => _launchDelay;

		public float ProjectileMaxDistance => _projectileMaxDistance;

		#endregion
	}
}