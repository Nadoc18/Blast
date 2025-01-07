using Cysharp.Threading.Tasks;
using Zenject;

namespace Blast.VisualLayer.Popups.DigitalStore
{
    public class DigitalStorePopup : Popup
    {
        #region Factories

        public class Factory : PlaceholderFactory<DigitalStorePopup>
        {
        }

        #endregion
        
        #region Fields

        private UniTaskCompletionSource<DigitalStorePopupResult> _completion = new();

        #endregion
        
        #region Methods

        public UniTask<DigitalStorePopupResult> WaitForResult()
        {
            return _completion.Task;
        }

        public void OnPurchaseCurrencyPackButtonClick(CurrencyPackData currencyPackData)
        {
            var result = new DigitalStorePopupResult { IsCanceled = false, SelectedPack = currencyPackData };
            _completion.TrySetResult(result);
            Close();
        }

        public void OnCloseButtonClick()
        {
            var result = new DigitalStorePopupResult { IsCanceled = true };
            _completion.TrySetResult(result);
            Close();
        }

        #endregion
    }
}