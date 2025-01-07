using System;
using Blast.DataLayer;
using Blast.DataLayer.Metadata;
using Blast.VisualLayer.Gameplay.Handlers;
using TMPro;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Gameplay.UI
{
    public class GameplayHudUi : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private TextMeshProUGUI _coinsBalanceText;

        [SerializeField]
        private TextMeshProUGUI _gemsBalanceText;
        
        #endregion
        
        #region Injects

        [Inject]
        private IHudBackClickHandler _backClickHandler;

        [Inject]
        private IDataLayer _dl;
        
        #endregion

        #region Methods

        private void Start()
        {
            InitializeView();
        }

        private void OnDestroy()
        {
            _dl.Balances.CoinsBalanceChange -= SyncUiWithData;
            _dl.Balances.GemsBalanceChange -= SyncUiWithData;
        }

        private void InitializeView()
        {
            _dl.Balances.CoinsBalanceChange += SyncUiWithData;
            _dl.Balances.GemsBalanceChange += SyncUiWithData;
            SyncUiWithData();
        }

        private void SyncUiWithData()
        {
            _coinsBalanceText.text = _dl.Balances.Coins.ToString();
            _gemsBalanceText.text = _dl.Balances.Gems.ToString();
        }

        public async void OnBackButtonClick()
        {
            await _backClickHandler.Execute();
        }

        #endregion
    }
}