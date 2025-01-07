namespace Blast.VisualLayer.Components
{
	public interface IDamageable
	{
		void Damage(int damageToApply);
		
		int Health { get; }
		
		bool IsDestroyed { get; }
	}
}