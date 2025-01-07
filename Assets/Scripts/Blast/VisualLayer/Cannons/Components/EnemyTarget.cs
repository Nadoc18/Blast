using UnityEngine;

namespace Blast.VisualLayer.Cannons.Components
{
	public class EnemyTarget : MonoBehaviour, IEnemyTarget
	{
		#region Properties

		public Vector3 CurrentPosition => transform.position;

		#endregion
	}
}