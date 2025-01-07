using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Blast.VisualLayer.Gameplay.Handlers
{
	public class MockBackClickHandler : IHudBackClickHandler
	{
		public async UniTask Execute()
		{
			Debug.Log("<-");
		}
	}
}