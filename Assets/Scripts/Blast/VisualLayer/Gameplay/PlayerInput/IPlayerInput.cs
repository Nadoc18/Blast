namespace Blast.VisualLayer.Gameplay.PlayerInput
{
	public interface IPlayerInput
	{
		float RotationInput { get; }
		bool IsFireRequested { get; }
	}
}