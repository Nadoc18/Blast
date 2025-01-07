using System;
using UnityEngine;

namespace Blast.DataTypes
{
	[Serializable]
	public class GameLevelMetadata
	{
		#region Editor

		[SerializeField]
		private GameLevelType _levelType;
		
		[SerializeField]
		private string _levelName;

		[SerializeField]
		private Sprite _sceneCoverSprite;

		[SerializeField]
		private int _levelSceneBuildIndex;

		[SerializeField]
		private PlayerCannonType _cannonType;
		
		#endregion

		#region Methods

		public void SetCannon(PlayerCannonType cannonType)
		{
			_cannonType = cannonType;
		}

		#endregion
		
		#region Properties

		public GameLevelType LevelType => _levelType;
		
		public string LevelName => _levelName;

		public Sprite SceneCoverSprite => _sceneCoverSprite;

		public int LevelSceneBuildIndex => _levelSceneBuildIndex;

		public PlayerCannonType CannonType => _cannonType;

		#endregion
	}
}