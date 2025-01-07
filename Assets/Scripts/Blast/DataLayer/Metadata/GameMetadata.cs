using System.IO;
using System.Linq;
using Blast.DataTypes;
using UnityEngine;
using Zenject;

namespace Blast.DataLayer.Metadata
{
	public class GameMetadata : IGameMetadata
	{
		#region Injects

		[Inject]
		private CannonMetadata[] _cannonsMetadata;

		[Inject]
		private GameLevelMetadata[] _levelsMetadata;

		[Inject]
		private InfraScreenMetadata[] _infraScreenMetadata;
		
		#endregion
		
		#region Methods

		public Object GetPrefabForCannon(PlayerCannonType playerCannonType)
		{
			var map = _cannonsMetadata.FirstOrDefault(c => c.CannonType == playerCannonType);
			if (map == null)
			{
				throw new InvalidDataException($"Cannon type {playerCannonType} in not registered in metadata");
			}

			return map.CannonPrefabRef;
		}

		public GameLevelMetadata[] GetLevelsMetadata() => _levelsMetadata;

		public CannonMetadata[] GetCannonsMatadata() => _cannonsMetadata;

		public GameLevelMetadata GetLevelMetadata(GameLevelType levelType)
		{
			var result = _levelsMetadata.FirstOrDefault(m => m.LevelType == levelType);
			if (result == null)
			{
				throw new InvalidDataException($"{levelType} level isn't supported");
			}

			return result;
		}

		public InfraScreenMetadata GetInfraScreenMetadata(InfraScreenType screenType)
		{
			var result = _infraScreenMetadata.FirstOrDefault(m => m.Type == screenType);
			if (result == null)
			{
				throw new InvalidDataException($"{screenType} infra screen isn't supported");
			}

			return result;
		}

		public int GetSceneBuildIndexFor(InfraScreenType screenType)
		{
			var metadata = GetInfraScreenMetadata(screenType);
			return metadata.SceneBuildIndex;
		}

		#endregion
	}
}