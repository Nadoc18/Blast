using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Gameplay.Score.Installers
{
	[CreateAssetMenu(
		menuName = "Blast/Gameplay/Gameplay Score Calculator Installer", 
		fileName = "Gameplay Score Calculator Installer")]
	public class GameplayScoreCalculatorInstaller : ScriptableObjectInstaller<GameplayScoreCalculatorInstaller>
	{
		[SerializeField]
		private ScoreCalculationParams _params;

		public override void InstallBindings()
		{
			Container
				.Bind<ScoreCalculationParams>()
				.FromInstance(_params)
				.AsSingle();

			Container
				.BindInterfacesTo<GameScoreCalculator>()
				.AsSingle()
				.NonLazy();
		}
	}
}