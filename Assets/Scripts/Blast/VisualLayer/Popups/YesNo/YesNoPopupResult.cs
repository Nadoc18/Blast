namespace Blast.VisualLayer.Popups.YesNo
{
    public struct YesNoPopupResult
    {
        public bool IsYes;

        public bool IsNo => !IsYes;
    }
}