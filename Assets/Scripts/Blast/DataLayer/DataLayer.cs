using Blast.DataLayer.Balances;
using Blast.DataLayer.Metadata;
using Zenject;

namespace Blast.DataLayer
{
	public class DataLayer : IDataLayer
	{
		[Inject]
		private IGameMetadata _metadata;

		[Inject]
		private IPlayerBalances _balances;
		
		public IGameMetadata Metadata => _metadata;

		public IPlayerBalances Balances => _balances;
	}
}