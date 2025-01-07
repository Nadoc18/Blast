using System.Collections.Generic;
using Blast.DataTypes;
using Blast.VisualLayer.Cannons.Components;
using Blast.VisualLayer.Enemies;
using Blast.VisualLayer.Factories;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.CannonStudio.Handlers
{
	public class StartCannonStudioHandler : IInitializable
	{
		[Inject]
		private bool _dontInstantiateCannon;

		[Inject]
		private PlayerCannonType _cannonType;

		[Inject]
		private Transform _parentTransform;
		
		[Inject]
		private PlayerCannonFactory _cannonFactory;

		[Inject]
		private List<IEnemySpawner> _enemySpawners;
		
		private IEnemyTarget _cannonInstance;
		
		public void Initialize()
		{
			if (_dontInstantiateCannon)
			{
				return;
			}

			_cannonInstance = _cannonFactory.Create(_cannonType, _parentTransform);
			foreach (var enemySpawner in _enemySpawners)
			{
				enemySpawner.Spawn(_cannonInstance);
			}
		}
	}
}