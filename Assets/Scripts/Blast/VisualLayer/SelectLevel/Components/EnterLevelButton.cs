using Blast.DataTypes;
using Blast.VisualLayer.SelectLevel.Handlers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Blast.VisualLayer.SelectLevel.Components
{
    public class EnterLevelButton : MonoBehaviour
    {
        #region Factories

        public class Factory : PlaceholderFactory<GameLevelMetadata, EnterLevelButton>
        {
        }

        #endregion
        
        #region Editor

        [SerializeField]
        private TextMeshProUGUI _levelNameComponent;
        
        [SerializeField]
        private string _levelName;

        [SerializeField]
        private Image _buttonCoverImage;
        
        #endregion

        #region Injects

        [Inject]
        private IEnterLevelHandler _enterLevelHandler;
        
        #endregion

        #region Fields

        private GameLevelMetadata _levelMetadata;

        #endregion
        
        #region Methods

        [Inject]
        public void Construct(GameLevelMetadata levelMetadata)
        {
            _levelMetadata = levelMetadata;
            _levelName = _levelMetadata.LevelName;
            _levelNameComponent.text = _levelName;
            _buttonCoverImage.sprite = _levelMetadata.SceneCoverSprite;
        }

        private void OnValidate()
        {
            _levelNameComponent.text = _levelName;
        }

        public void OnClick()
        {
            _enterLevelHandler.Execute(_levelMetadata.LevelType);
        }

        #endregion
    }
}