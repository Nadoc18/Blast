using UnityEngine;

namespace Blast.Utils.Animation
{
    public class SetAnimatorInt : SetAnimatorParam
    {
        #region Editor

        [SerializeField]
        private int _intValueToSet;

        #endregion
        #region Methods

        public override void Set()
        {
            _targetAnimator.SetInteger(_name, _intValueToSet);
        }

        #endregion
    }
}