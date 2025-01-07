using UnityEngine;

namespace Blast.Utils.Animation
{
    public class SetAnimatorTrigger : SetAnimatorParam
    {
        #region Methods

        public override void Set()
        {
            _targetAnimator.SetTrigger(_name);
        }

        #endregion
    }
}