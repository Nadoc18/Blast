using Blast.VisualLayer.Cannons.Components;

namespace Blast.VisualLayer.Enemies
{
	public interface IEnemySpawner
	{
		void Spawn(IEnemyTarget target);
	}
}