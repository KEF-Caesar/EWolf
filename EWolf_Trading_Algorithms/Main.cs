using EWolf_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWolf_Trading_Algorithms
{
	class Main
	{
		private Dictionary<string, Stock> Stocks;
		private Data D;

		public Main()
		{
			Stocks = new Dictionary<string, Stock> { };
			D = new Data();
			for (int i = 0; i < D.Tickers.Count; i++)
			{
				Stocks[D.Tickers[i]] = new Stock(D.Tickers[i]);
			}
		}
	}
}