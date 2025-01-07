using System;
using Blast.Extensions;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Blast.VisualLayer.Loader
{
    public class Loader : MonoBehaviour, ILoader
    {
        #region Editor

        [SerializeField]
        private Slider _loaderSlider;

        [SerializeField]
        private TextMeshProUGUI _loaderText;

        [SerializeField]
        private Animation _animationComponent;

        [SerializeField]
        private AnimationClip _fadeInClip;
        
        [SerializeField]
        private AnimationClip _fadeOutClip;
        
        #endregion

        #region Methods

        public void ResetData()
        {
            _loaderSlider.value = 0f;
            _loaderText.text = string.Empty;
        }

        public async UniTask FadeIn()
        {
            await _animationComponent.PlayClipAsync(_fadeInClip);
        }

        public async UniTask FadeOut()
        {
            await _animationComponent.PlayClipAsync(_fadeOutClip);
        }

        public void SetProgress(float progress, string text)
        {
            _loaderSlider.value = progress;
            _loaderText.text = text;
        }

        #endregion
    }
}