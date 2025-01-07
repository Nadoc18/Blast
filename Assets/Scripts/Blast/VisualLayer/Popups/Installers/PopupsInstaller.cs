using Blast.VisualLayer.Popups.DigitalStore;
using Blast.VisualLayer.Popups.SelectCannon;
using Blast.VisualLayer.Popups.YesNo;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Blast.VisualLayer.Popups.Installers
{
	public class PopupsInstaller : MonoInstaller<PopupsInstaller>
	{
		#region Editor

		[SerializeField]
		private RectTransform _parentTransform;

		[SerializeField]
		private DigitalStorePopup _digitalStorePopupPrefabRef;

		[SerializeField]
		private YesNoPopup _yesNoPopupPrefabRef;

		[SerializeField]
		private SelectCannonPopup _selectCannonPopupPrefabRef;
		
		#endregion

		#region Methods

		public override void InstallBindings()
		{
			Container
				.BindFactory<DigitalStorePopup, DigitalStorePopup.Factory>()
				.FromComponentInNewPrefab(_digitalStorePopupPrefabRef)
				.UnderTransform(_parentTransform)
				.AsSingle();

			Container
				.BindFactory<YesNoPopupArgs, YesNoPopup, YesNoPopup.Factory>()
				.FromComponentInNewPrefab(_yesNoPopupPrefabRef)
				.UnderTransform(_parentTransform)
				.AsSingle();

			Container
				.BindFactory<SelectCannonPopup, SelectCannonPopup.Factory>()
				.FromComponentInNewPrefab(_selectCannonPopupPrefabRef)
				.UnderTransform(_parentTransform)
				.AsSingle();
		}

		#endregion
	}
}