using Blast.DataTypes;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Popups.SelectCannon
{
	public class SelectCannonPopupDependenciesInstaller : MonoInstaller<SelectCannonPopupDependenciesInstaller>
	{
		[SerializeField]
		private SelectCannonToggle _selectCannonTogglePrefabRef;
		
		public override void InstallBindings()
		{
			Container
				.BindFactory<Transform, CannonMetadata, SelectCannonToggle, SelectCannonToggle.Factory>()
				.FromComponentInNewPrefab(_selectCannonTogglePrefabRef)
				.AsSingle();
		}
	}
}