using Cysharp.Threading.Tasks;

namespace Blast.VisualLayer.Loader
{
    public interface ILoader
    {
        #region Methods

        void ResetData();
        
        UniTask FadeIn();

        UniTask FadeOut();

        void SetProgress(float progress, string text);

        #endregion
    }
}