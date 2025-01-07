using Blast.DataLayer;
using Blast.VisualLayer.Popups.DigitalStore;
using Zenject;

namespace Blast.VisualLayer.SelectLevel.Handlers
{
	public class HudPlusCurrencyClickHandler : IHudPlusCurrencyClickHandler
	{
		[Inject]
		private DigitalStorePopup.Factory _popupFactory;

		[Inject]
		private IDataLayer _dataLayer;
		
		public async void Execute()
		{
			var popup = _popupFactory.Create();
			var result = await popup.WaitForResult();
			if (result.IsCanceled)
			{
				return;
			}
			_dataLayer.Balances.AddCurrency(result.SelectedPack.CurrencyType, result.SelectedPack.AdditionAmount);
		}
	}
}