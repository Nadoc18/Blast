namespace Blast.VisualLayer.Popups.YesNo
{
	public struct YesNoPopupArgs
	{
		public string Text;
		public string YesCaption;
		public string NoCaption;
		public bool IsNoButtonVisible;

		public static YesNoPopupArgs Default => new()
		{
			Text = "Are you sure?",
			YesCaption = "OK",
			NoCaption = "Cancel",
			IsNoButtonVisible = true
		};
	}
}