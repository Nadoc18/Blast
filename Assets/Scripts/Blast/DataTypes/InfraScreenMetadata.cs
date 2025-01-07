using System;
using UnityEngine;

namespace Blast.DataTypes
{
	[Serializable]
	public class InfraScreenMetadata
	{
		[SerializeField]
		private InfraScreenType _type;

		[SerializeField]
		private int _sceneBuildIndex;
		
		public InfraScreenType Type => _type;

		public int SceneBuildIndex => _sceneBuildIndex;
	}
}