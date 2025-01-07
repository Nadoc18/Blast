using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Weapons.Logic.SameTime
{
	[CreateAssetMenu(
		menuName = "Blast/Weapons/Logic/Same Time Logic Installer",
		fileName = "Same Time Logic Installer")]
	public class SameTimeLogicInstaller : ScriptableObjectInstaller<SameTimeLogicInstaller>
	{
		[SerializeField]
		private WeaponLogicParams _logicParams;
		
		public override void InstallBindings()
		{
			Container
				.Bind<WeaponLogicParams>()
				.FromInstance(_logicParams)
				.AsSingle();

			Container
				.Bind<IWeaponLogic>()
				.To<SameTimeFireLogic>()
				.AsSingle();
		}
	}
}