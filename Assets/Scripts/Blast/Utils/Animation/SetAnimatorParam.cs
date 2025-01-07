using UnityEngine;

namespace Blast.Utils.Animation
{
    public abstract class SetAnimatorParam : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        protected string _name;

        [SerializeField]
        protected Animator _targetAnimator;

        #endregion

        #region Methods

        public abstract void Set();

        #endregion
    }
}