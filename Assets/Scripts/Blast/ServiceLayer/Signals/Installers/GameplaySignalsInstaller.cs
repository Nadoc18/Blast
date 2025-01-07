using Blast.ServiceLayer.Signals.Payloads;
using UnityEngine;
using Zenject;

namespace Blast.ServiceLayer.Signals.Installers
{
	[CreateAssetMenu(
		menuName = "Blast/Gameplay/Gameplay Signals Installer", 
		fileName = "Gameplay Signals Installer")]
	public class GameplaySignalsInstaller : ScriptableObjectInstaller<GameplaySignalsInstaller>
	{
		public override void InstallBindings()
		{
			SignalBusInstaller.Install(Container);
			Container.DeclareSignal<EnemyTurretDestroyed>();
			Container.DeclareSignal<EnemyTurretFired>();
			Container.DeclareSignal<EnemyTurretHit>();
			Container.DeclareSignal<PlayerCannonFired>();
		}
	}
}