using System;
using UnityEngine;

namespace Blast.VisualLayer.Components
{
	public class Damageable : MonoBehaviour, IDamageable
	{
		#region Events

		public event Action<int> DamageReceived;

		public event Action Destroyed;
		
		#endregion
		
		#region Editor

		[SerializeField]
		[Range(0, 100)]
		private int _health = 100;

		[SerializeField]
		private GameObject _explosionEffectPrefabRef;
		
		#endregion

		#region Methods

		public void Damage(int damageToApply)
		{
			if (IsDestroyed)
			{
				Debug.LogWarning($"Cannot damage object {gameObject.name}. Its already destroyed");
				return;
			}
			_health = Mathf.Max(0, _health - damageToApply);
			DamageReceived?.Invoke(damageToApply);
			if (IsDestroyed)
			{
				PlayExplosionEffect();
				DestroyObject();
			}
		}

		private void DestroyObject()
		{
			Destroyed?.Invoke();
			DamageReceived = null;
			Destroyed = null;
			Destroy(gameObject);
		}

		private void PlayExplosionEffect()
		{
			Instantiate(_explosionEffectPrefabRef, transform.position, transform.rotation);
		}

		#endregion
		
		#region Properties

		public bool IsDestroyed => Health <= 0; 
		
		public int Health => _health;

		#endregion
	}
}