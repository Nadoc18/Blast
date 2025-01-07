using UnityEngine;

namespace Blast.VisualLayer.Weapons.Logic
{
	public interface IWeaponLogic
	{
		bool Fire(Transform[] launchingPoints);
	}
}