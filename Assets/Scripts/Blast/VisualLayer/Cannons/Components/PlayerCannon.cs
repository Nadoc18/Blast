using Blast.ServiceLayer.Signals.Payloads;
using Blast.VisualLayer.Components;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Cannons.Components
{
    public class PlayerCannon : MonoBehaviour
    {
        #region Injets
        #endregion

        #region Editor

        [SerializeField]
        private Damageable _damageable;

        #endregion
        
        #region Methods

        private void Awake()
        {
            if (_damageable == null)
            {
                _damageable = GetComponent<Damageable>();
            }

            enabled = _damageable != null;
        }

        private void Start()
        {
            _damageable.Destroyed += OnCannonDestroyed;
        }

        private void OnCannonDestroyed()
        {
            // TODO: Raise notification about player cannon destroyed
        }

        #endregion
    }
}