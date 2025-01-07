using System;
using Blast.DataTypes;

namespace Blast.DataLayer.Balances
{
	public interface IPlayerBalances
	{
		#region Events

		event Action CoinsBalanceChange;

		event Action GemsBalanceChange;

		#endregion

		#region Methods

		void AddCoins(int coinsToAdd);

		bool TakeCoins(int coinsToTake);

		void AddGems(int gemsToAdd);

		bool TakeGems(int gemsToTake);

		void AddCurrency(CurrencyType currencyType, int amount);

		#endregion

		#region Properties

		int Coins { get; }
		
		int Gems { get; }

		#endregion
	}
}