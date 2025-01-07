using System;
using Blast.DataTypes;
using UnityEngine;

namespace Blast.DataLayer.Balances
{
	[Serializable]
	public class PlayerBalances : IPlayerBalances
	{
		#region Events

		public event Action CoinsBalanceChange;

		public event Action GemsBalanceChange;
        
		#endregion
        
		#region Editor

		[SerializeField]
		private int _coins;

		[SerializeField]
		private int _gems;

		#endregion
        
		#region Methods

		public void AddCoins(int coinsToAdd)
		{
			if (coinsToAdd <= 0)
			{
				return;
			}
			_coins += coinsToAdd;
			CoinsBalanceChange?.Invoke();
		}

		public bool TakeCoins(int coinsToTake)
		{
			if (coinsToTake <= 0 || coinsToTake > _coins)
			{
				return false;
			}

			_coins -= coinsToTake;
			CoinsBalanceChange?.Invoke();
			return true;
		}

		public void AddGems(int gemsToAdd)
		{
			if (gemsToAdd <= 0)
			{
				return;
			}
			_gems += gemsToAdd;
			GemsBalanceChange?.Invoke();
		}

		public bool TakeGems(int gemsToTake)
		{
			if (gemsToTake <= 0 || gemsToTake > _gems)
			{
				return false;
			}

			_gems -= gemsToTake;
			GemsBalanceChange?.Invoke();
			return true;
		}

		public void AddCurrency(CurrencyType currencyType, int amount)
		{
			switch (currencyType)
			{
				case CurrencyType.Coins:
					AddCoins(amount);
					break;
				case CurrencyType.Gems:
					AddGems(amount);
					break;
			}
		}

		#endregion
        
		#region Properties

		public int Coins => _coins;

		public int Gems => _gems;

		#endregion
	}
}