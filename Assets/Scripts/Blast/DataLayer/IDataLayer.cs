using Blast.DataLayer.Balances;
using Blast.DataLayer.Metadata;
using UnityEngine;

namespace Blast.DataLayer
{
	public interface IDataLayer
	{
		IGameMetadata Metadata { get; }

		IPlayerBalances Balances { get; }
	}
}