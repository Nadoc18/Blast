using System;
using Blast.DataTypes;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Blast.VisualLayer.Popups.SelectCannon
{
    public class SelectCannonToggle : MonoBehaviour
    {
        #region Events

        public event Action<SelectCannonToggle> Clicked;

        #endregion

        #region Factories

        public class Factory : PlaceholderFactory<Transform, CannonMetadata, SelectCannonToggle>
        {
        }

        #endregion
        
        #region Editor

        [SerializeField]
        private Outline _outline;

        [SerializeField]
        private Image _targetImage;
        
        #endregion

        #region Methods

        [Inject]
        public void Construct(Transform parentTransform, CannonMetadata cannonMetadata)
        {
            transform.SetParent(parentTransform);
            CannonMetadata = cannonMetadata;
            _targetImage.sprite = cannonMetadata.CannonPreviewSprite;
        }

        public void OnToggleClick()
        {
            Clicked?.Invoke(this);
        }

        public void Select()
        {
            _outline.enabled = true;
            IsSelected = true;

        }

        public void Deselect()
        {
            _outline.enabled = false;
            IsSelected = false;
        }

        #endregion

        #region Properties

        public CannonMetadata CannonMetadata { get; private set; }
        
        public bool IsSelected { get; private set; }

        #endregion
    }
}