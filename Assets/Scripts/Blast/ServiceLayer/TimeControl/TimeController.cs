using UnityEngine;

namespace Blast.ServiceLayer.TimeControl
{
	public class TimeController : ITimeController
	{
		#region Methods

		public void PauseGameplay()
		{
			Time.timeScale = 0f;
		}

		public void UnpauseGameplay()
		{
			Time.timeScale = 1f;
		}

		#endregion
	}
}