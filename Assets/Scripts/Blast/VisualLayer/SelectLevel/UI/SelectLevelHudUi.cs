using Blast.DataLayer;
using Blast.VisualLayer.SelectLevel.Handlers;
using TMPro;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.SelectLevel.UI
{
    public class SelectLevelHudUi : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private TextMeshProUGUI _coinsBalanceText;

        [SerializeField]
        private TextMeshProUGUI _gemsBalanceText;
        
        #endregion
        
        #region Injects

        [Inject]
        private IHudPlusCurrencyClickHandler _hudPLustClickHandler;

        [Inject]
        private IDataLayer _dataLayer;
        
        #endregion
        
        #region Methods

        private void Start()
        {
            InitializeView();
        }

        private void InitializeView()
        {
            _dataLayer.Balances.CoinsBalanceChange += SyncUiWithData;
            _dataLayer.Balances.GemsBalanceChange += SyncUiWithData;
            SyncUiWithData();
        }

        private void SyncUiWithData()
        {
            _coinsBalanceText.text = _dataLayer.Balances.Coins.ToString();
            _gemsBalanceText.text = _dataLayer.Balances.Gems.ToString();
        }

        public async void OnSettingsButtonClick()
        {
        }

        public async void OnCoinsPlusButtonClick()
        {
            _hudPLustClickHandler.Execute();
        }
        
        public async void OnGemsPlusButtonClick()
        {
            _hudPLustClickHandler.Execute();
        }

        #endregion
    }
}