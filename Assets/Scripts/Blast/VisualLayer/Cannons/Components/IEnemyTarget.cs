using UnityEngine;

namespace Blast.VisualLayer.Cannons.Components
{
	public interface IEnemyTarget
	{
		Vector3 CurrentPosition { get; }
	}
}