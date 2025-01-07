using System.Collections.Generic;
using Blast.Extensions;
using Blast.ServiceLayer.Signals.Payloads;
using Blast.VisualLayer.Cannons.Components;
using Blast.VisualLayer.Enemies.Components;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Enemies.Spawners
{
	public class EnemyTurretSpawner : MonoBehaviour, IEnemySpawner
	{
		#region Injects

		[Inject]
		private EnemyTurret.Factory _turretFactory;
		
		#endregion

		#region Fields

		private EnemyTurret _turret;

		#endregion
		
		#region Methods

		public void Spawn(IEnemyTarget target)
		{
			_turret = _turretFactory.Create(target);
		}

		#endregion
	}
}