using Blast.DataTypes;

namespace Blast.VisualLayer.SelectLevel.Handlers
{
    public interface IEnterLevelHandler
    {
        void Execute(GameLevelType levelType);
    }
}