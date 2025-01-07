using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Blast.DataTypes
{
	[Serializable]
	public class CannonMetadata
	{
		#region Fields

		[SerializeField]
		private PlayerCannonType _cannonType;

		[SerializeField]
		private Object _cannonPrefabRef;

		[SerializeField]
		private Sprite _cannonPreviewSprite;
		
		#endregion
		
		#region Properties

		public PlayerCannonType CannonType => _cannonType;

		public Object CannonPrefabRef => _cannonPrefabRef;

		public Sprite CannonPreviewSprite => _cannonPreviewSprite;

		#endregion
	}
}