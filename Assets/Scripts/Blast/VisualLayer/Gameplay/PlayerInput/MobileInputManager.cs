using Blast.VisualLayer.Components.UI.Joystick;
using UnityEngine;

namespace Blast.VisualLayer.Gameplay.PlayerInput
{
	public class MobileInputManager : MonoBehaviour, IPlayerInput
	{
		#region Editor

		[SerializeField]
		private Joystick _joystick;
		
		#endregion
		
		#region Properties

		public float RotationInput => _joystick.Horizontal;

		public bool IsFireRequested => _joystick.IsPressed;

		#endregion
	}
}