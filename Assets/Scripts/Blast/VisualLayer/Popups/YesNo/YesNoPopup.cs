using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Blast.VisualLayer.Popups.YesNo
{
    public class YesNoPopup : Popup
    {
        #region Factories

        public class Factory : PlaceholderFactory<YesNoPopupArgs, YesNoPopup>
        {
        }

        #endregion
        
        #region Editor

        [SerializeField]
        private TextMeshProUGUI _yesButtonText;

        [SerializeField]
        private TextMeshProUGUI _noButtonText;
        
        [SerializeField]
        private GameObject _noButtonGameObject;

        [SerializeField]
        private TextMeshProUGUI _popupContent;
        
        #endregion
        
        #region Fields

        private UniTaskCompletionSource<YesNoPopupResult> _completion = new();

        #endregion
        
        #region Methods

        [Inject]
        public void Construct(YesNoPopupArgs args)
        {
            _popupContent.text = args.Text;
            _yesButtonText.text = args.YesCaption;
            _noButtonText.text = args.NoCaption;
            _noButtonGameObject.SetActive(args.IsNoButtonVisible);
        }

        public UniTask<YesNoPopupResult> WaitForResult()
        {
            return _completion.Task;
        }

        public void OnYesClick()
        {
            var r = new YesNoPopupResult { IsYes = true };
            _completion.TrySetResult(r);
            Close();
        }

        public void OnCancelClick()
        {
            var r = new YesNoPopupResult { IsYes = false };
            _completion.TrySetResult(r);
            Close();
        }

        #endregion
    }
}