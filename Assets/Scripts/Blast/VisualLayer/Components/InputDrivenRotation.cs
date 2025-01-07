using Blast.DataTypes;
using Blast.VisualLayer.Gameplay.PlayerInput;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Components
{
	public class InputDrivenRotation : MonoBehaviour
	{
		#region Consts

		private const float ROTATION_SPEED_FACTOR = 0.1f;

		#endregion
		
		#region Editor

		[SerializeField]
		private Transform _rotationPivot;

		[SerializeField]
		[Range(-1f, 1f)]
		private float _rotation = 0f;

		[SerializeField]
		[Range(1f, 100f)]
		private float _speed = 5;
		
		[SerializeField]
		[Range(1f, 180f)]
		private uint _maxRotationAndle = 40;

		[SerializeField]
		private CannonRotationAxis _cannonRotationAxis;
		
		#endregion

		#region Fields

		private float _rotationFactor;
		
		#endregion
		
		#region Injects

		[Inject]
		private IPlayerInput _input;
		
		#endregion
		
		#region Methods

		private void Update()
		{
			SetRotation(_input.RotationInput);
			RotateVisually();
		}

		private void RotateVisually()
		{
			_rotationFactor = Mathf.Clamp(_rotationFactor + _rotation * Time.deltaTime, -1, 1);
			var angleInDegrees = _maxRotationAndle * _rotationFactor;
			var axis = ConvertRotationAxis(_cannonRotationAxis);
			_rotationPivot.localRotation = Quaternion.AngleAxis(angleInDegrees, axis);
		}

		private Vector3 ConvertRotationAxis(CannonRotationAxis axis)
		{
			return axis switch
			{
				CannonRotationAxis.Up => _rotationPivot.up,
				CannonRotationAxis.Right => _rotationPivot.right,
				CannonRotationAxis.Forward => _rotationPivot.forward,
				_ => ConvertRotationAxis(CannonRotationAxis.Up)
			};
		}

		public void SetRotation(float rotationForce)
		{
			_rotation = rotationForce * _speed * ROTATION_SPEED_FACTOR;
		}

		#endregion
	}
}