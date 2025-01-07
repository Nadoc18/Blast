using Blast.VisualLayer.Components;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Weapons.Projectiles
{
	public class Projectile : MonoBehaviour
	{
		#region Factory

		public class Factory : PlaceholderFactory<Vector3, Projectile>
		{
		}

		#endregion

		#region Editor

		[SerializeField]
		private Rigidbody _rb;

		#endregion
		
		#region Injections

		[Inject(Id = WeaponsBindingIds.MuzzleFlashPrefabRef)]
		private GameObject _muzzleFlashPrefabRef;

		[Inject(Id = WeaponsBindingIds.CollisionExplosionPrefabRef)]
		private GameObject _collisionExplosionPrefabRef;
		
		#endregion
		
		#region Fields

		private Vector3 _launchingPosition;

		private Quaternion _directionRotation;

		private float _speed;

		private float _maxDistance;

		private int _damage;
		
		#endregion
		
		#region Methods

		[Inject]
		private void Construct(Vector3 launchingPosition)
		{
			_launchingPosition = launchingPosition;
		}

		public void Fire(Vector3 direction, float speed, float maxDistance, int damage)
		{
			_speed = speed;
			_maxDistance = maxDistance;
			_damage = damage;
			_directionRotation = Quaternion.LookRotation(direction);
			transform.SetPositionAndRotation(_launchingPosition, _directionRotation);
			PlayMuzzleEffect(_launchingPosition, _directionRotation);
			_rb.velocity = transform.forward * _speed;
		}

		private void FixedUpdate()
		{
			ValidateMaxDistance();
		}

		private void ValidateMaxDistance()
		{
			if (Vector3.Distance(_launchingPosition, transform.position) > _maxDistance)
			{
				Destroy(gameObject);
			}
		}

		private void OnCollisionEnter(Collision other)
		{
			PlayCollisionEffectAt(other.contacts[0]);
			var damageable = other.gameObject.GetComponent<IDamageable>();
			damageable?.Damage(_damage);
			Destroy(gameObject);
		}

		private void PlayMuzzleEffect(Vector3 effectPosition, Quaternion effectRotation)
		{
			Instantiate(_muzzleFlashPrefabRef, effectPosition, effectRotation);
		}

		private void PlayCollisionEffectAt(ContactPoint contactPoint)
		{
			var hitPoint = contactPoint;
			Instantiate(_collisionExplosionPrefabRef, hitPoint.point,
				Quaternion.LookRotation(hitPoint.normal));
		}

		#endregion
	}
}