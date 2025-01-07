using Blast.DataLayer;
using Blast.ServiceLayer.Signals.Payloads;
using Zenject;

namespace Blast.VisualLayer.Gameplay.Score
{
	public class GameScoreCalculator : IInitializable
	{
		#region Injects

		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private IDataLayer _dataLayer;

		[Inject]
		private ScoreCalculationParams _params;
		
		#endregion
		
		#region Methods

		public void Initialize()
		{
			_signalBus.Subscribe<EnemyTurretDestroyed>(EnemyTurretDestroyedHandler);
			_signalBus.Subscribe<EnemyTurretFired>(EnemyTurretFiredHandler);
			_signalBus.Subscribe<EnemyTurretHit>(EnemyTurretHit);
			_signalBus.Subscribe<PlayerCannonFired>(PlayerCannonFiredHandler);
		}

		private void EnemyTurretDestroyedHandler(EnemyTurretDestroyed args)
		{
			_dataLayer.Balances.AddCoins(_params.EnemyDestroyed);
		}

		private void EnemyTurretFiredHandler(EnemyTurretFired args)
		{
			_dataLayer.Balances.AddCoins(_params.EnemyFire);
		}

		private void EnemyTurretHit(EnemyTurretHit args)
		{
			_dataLayer.Balances.AddCoins(_params.EnemyHit);
		}

		private void PlayerCannonFiredHandler(PlayerCannonFired args)
		{
		}
		
		#endregion
	}
}