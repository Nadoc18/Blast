using Blast.DataTypes;
using UnityEngine;

namespace Blast.VisualLayer.Popups.DigitalStore
{
    [CreateAssetMenu(menuName = "Blast/Data/Popups/Currency Pack Data", fileName = "Currency Pack Data")]
    public class CurrencyPackData : ScriptableObject
    {
        #region Fields

        [SerializeField]
        private string _packName;

        [SerializeField]
        private int _additionAmount;

        [SerializeField]
        private CurrencyType _currencyType;

        #endregion

        #region Popups

        public string PackName => _packName;

        public int AdditionAmount => _additionAmount;

        public CurrencyType CurrencyType => _currencyType;

        #endregion
    }
}