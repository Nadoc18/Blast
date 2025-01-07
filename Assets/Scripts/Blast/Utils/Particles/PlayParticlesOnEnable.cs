using UnityEngine;

namespace Blast.Utils.Particles
{
    public class PlayParticlesOnEnable : MonoBehaviour
    {
        #region Editor
        
        [SerializeField]
        private ParticleSystem _particlesToPlay;

        [SerializeField]
        private bool _includeChildrenParticles = true;
        
        #endregion
        
        #region Methods

        private void Awake()
        {
            if (_particlesToPlay == null)
            {
                _particlesToPlay = GetComponent<ParticleSystem>();
            }
        }

        private void OnEnable()
        {
            _particlesToPlay.Play(_includeChildrenParticles);
        }

        #endregion
    }
}