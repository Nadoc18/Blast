using System;
using Blast.VisualLayer.Weapons.Logic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using Random = UnityEngine.Random;

namespace Blast.VisualLayer.Components
{
	public class AutomaticWeaponTrigger : MonoBehaviour
	{
		#region Events

		public event Action Triggered;

		#endregion
		#region Injects

		[Inject]
		private IWeaponLogic _weaponLogic;
		
		#endregion

		#region Editor

		[SerializeField]
		private float _triggerDelayMax;

		[SerializeField]
		private float _triggerDelayMin;
		
		[SerializeField]
		private Transform[] _launchingPoints;
		
		#endregion

		#region Fields

		private float _lastTimeFired;

		private float _currentDelay;
		
		#endregion
		
		#region Methods

		private void Start()
		{
			_lastTimeFired = Time.time;
			_currentDelay = Random.Range(_triggerDelayMin, _triggerDelayMax);
		}

		private void Update()
		{
			var isInDelay = Time.time < _lastTimeFired + _currentDelay;
			if (isInDelay)
			{
				return;
			}

			_weaponLogic.Fire(_launchingPoints);
			Triggered?.Invoke();
			
			_lastTimeFired = Time.time;
			_currentDelay = Random.Range(_triggerDelayMin, _triggerDelayMax);
		}

		#endregion
	}
}