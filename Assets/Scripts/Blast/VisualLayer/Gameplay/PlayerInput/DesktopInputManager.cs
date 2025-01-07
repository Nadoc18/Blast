using UnityEngine;

namespace Blast.VisualLayer.Gameplay.PlayerInput
{
	public class DesktopInputManager : IPlayerInput
	{
		#region Consts

		private const string ROTATION_AXIS_NAME = "Horizontal";
		
		#endregion
		
		#region Properties

		public float RotationInput => Input.GetAxisRaw(ROTATION_AXIS_NAME);

		public bool IsFireRequested => Input.GetKeyDown(KeyCode.Space);

		#endregion
	}
}