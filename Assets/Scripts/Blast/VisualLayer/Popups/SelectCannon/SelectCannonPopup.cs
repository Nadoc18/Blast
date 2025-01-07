using System.Collections.Generic;
using System.Linq;
using Blast.DataLayer;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Blast.VisualLayer.Popups.SelectCannon
{
    public class SelectCannonPopup : Popup
    {
        #region Factories

        public class Factory : PlaceholderFactory<SelectCannonPopup>
        {
        }

        #endregion
        
        #region Editor

        [SerializeField]
        private Button _okButton;

        [SerializeField]
        private Transform _togglesParentTransform;
        
        #endregion
        
        #region Fields

        private SelectCannonToggle _selectedToggle;

        private List<SelectCannonToggle> _toggles = new();

        private UniTaskCompletionSource<SelectCannonPopupResult> _completion = new();

        #endregion
        
        #region Injects

        [Inject]
        private IDataLayer _dataLayer;

        [Inject]
        private SelectCannonToggle.Factory _selectCannonToggle;
        
        #endregion
        
        #region Methods

        private void Start()
        {
            CreateCannonToggles();
            _okButton.interactable = IsAnyToggleSelected();
        }

        private void CreateCannonToggles()
        {
            var availableCannons = _dataLayer.Metadata.GetCannonsMatadata();
            foreach (var cannonMetadata in availableCannons)
            {
                var toggle = _selectCannonToggle.Create(_togglesParentTransform, cannonMetadata);
                toggle.Clicked += OnToggleClicked;
                _toggles.Add(toggle);
            }
        }

        private void OnToggleClicked(SelectCannonToggle sender)
        {
            DeselectAllToggles();
            _selectedToggle = sender;
            _selectedToggle.Select();
            _okButton.interactable = IsAnyToggleSelected();
        }

        public void OnCloseButtonClick()
        {
            var r = new SelectCannonPopupResult { IsCanceled = true };
            _completion.TrySetResult(r);
            Close();
        }

        public void OnOkButtonClick()
        {
            var r = new SelectCannonPopupResult
            {
                IsCanceled = false,
                SelectedCannonType = _selectedToggle.CannonMetadata.CannonType
            };
            _completion.TrySetResult(r);
            Close();
        }

        public UniTask<SelectCannonPopupResult> WaitForResult()
        {
            return _completion.Task;
        }

        private void DeselectAllToggles()
        {
            _toggles.ForEach(t => t.Deselect());
        }

        private bool IsAnyToggleSelected()
        {
            return _toggles.Count(t => t.IsSelected) > 0;
        }

        #endregion
    }
}