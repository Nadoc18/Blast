using Blast.VisualLayer.Gameplay.PlayerInput;
using Blast.VisualLayer.Weapons.Logic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Blast.VisualLayer.Components
{
	public class InputDrivenWeaponTrigger : MonoBehaviour
	{
		#region Editor

		[SerializeField]
		private UnityEvent _onFire;

		[SerializeField]
		private Transform[] _launchingPoints;
		
		#endregion

		#region Injects

		[Inject]
		private IWeaponLogic _weaponLogic;

		[Inject]
		private IPlayerInput _playerInput;
		
		#endregion
		
		#region Methods

		private void Update()
		{
			if (_playerInput == null)
			{
				return;
			}

			if (_playerInput.IsFireRequested)
			{
				Fire();
			}
		}

		private void Fire()
		{
			if (_weaponLogic.Fire(_launchingPoints))
			{
				_onFire?.Invoke();
			}
		}

		#endregion
	}
}