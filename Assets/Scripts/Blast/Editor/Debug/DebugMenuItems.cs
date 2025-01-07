using Blast.VisualLayer.Popups.DigitalStore;
using Blast.VisualLayer.Popups.SelectCannon;
using Blast.VisualLayer.Popups.YesNo;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Blast.Editor.Debug
{
	public static class DebugMenuItems
	{
		[MenuItem("Blast/Popups/Select Cannon Popup")]
		public static void ShowSelectCannonPopup()
		{
			var context = Object.FindObjectOfType<SceneContext>();
			var factory = context.Container.Resolve<SelectCannonPopup.Factory>();
			factory.Create();
		}
		
		[MenuItem("Blast/Popups/Yes No Popup")]
		public static void ShowYesNoPopup()
		{
			var context = Object.FindObjectOfType<SceneContext>();
			var factory = context.Container.Resolve<YesNoPopup.Factory>();
			factory.Create(YesNoPopupArgs.Default);
		}
		
		[MenuItem("Blast/Popups/Digital Store Popup")]
		public static void ShowDigitalStorePopup()
		{
			var context = Object.FindObjectOfType<SceneContext>();
			var factory = context.Container.Resolve<DigitalStorePopup.Factory>();
			factory.Create();
		}
	}
}