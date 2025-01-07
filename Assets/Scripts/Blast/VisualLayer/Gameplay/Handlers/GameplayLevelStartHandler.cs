using System.Collections.Generic;
using Blast.DataLayer;
using Blast.DataTypes;
using Blast.VisualLayer.Cannons.Components;
using Blast.VisualLayer.Enemies;
using Blast.VisualLayer.Factories;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Gameplay.Handlers
{
	public class GameplayLevelStartHandler : IInitializable
	{
		#region Injects

		[Inject]
		private GameLevelType _currentLevelType;

		[Inject]
		private IDataLayer _dataLayer;
		
		[Inject]
		private PlayerCannonFactory _cannonFactory;

		[Inject]
		private Transform _cannonParentTransform;

		[Inject] 
		private List<IEnemySpawner> _enemySpawners;
		
		#endregion

		#region Fields

		private IEnemyTarget _enemyTarget;

		#endregion
		
		#region Methods

		public void Initialize()
		{
			var levelMetadata = _dataLayer.Metadata.GetLevelMetadata(_currentLevelType);
			_enemyTarget = _cannonFactory.Create(levelMetadata.CannonType, _cannonParentTransform);
			foreach (var enemySpawner in _enemySpawners)
			{
				enemySpawner.Spawn(_enemyTarget);
			}
		}

		#endregion
	}
}