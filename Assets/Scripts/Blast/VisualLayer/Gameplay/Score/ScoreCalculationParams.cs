using System;
using UnityEngine;

namespace Blast.VisualLayer.Gameplay.Score
{
	[Serializable]
	public class ScoreCalculationParams
	{
		[SerializeField]
		private int _enemyHit;
		
		[SerializeField]
		private int _enemyDestroyed;

		[SerializeField]
		private int _enemyFire;

		[SerializeField]
		private int _playerFire;

		public int EnemyHit => _enemyHit;

		public int EnemyDestroyed => _enemyDestroyed;

		public int EnemyFire => _enemyFire;

		public int PlayerFire => _playerFire;
	}
}