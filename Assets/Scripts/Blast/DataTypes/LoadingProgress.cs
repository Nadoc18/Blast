namespace Blast.DataTypes
{
	public struct LoadingProgress
	{
		public LoadingProgress(float progress, string message)
		{
			Progress = progress;
			Message = message;
		}

		public float Progress;
		public string Message;
	}
}