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
		public List<Position> Positions;
		public Dictionary<string, List<Deal>> Deals;
		Data D;

		void Open_Deal_1()
		{
		}

		void Close_Deal_1()
		{
		}

		public void Tick()
		{
			for (int i = 0; i < D.Companies.Count; i++)
			{
				for (int j = 0; j < D.Companies[i].Time_Frames.Count; j++)
					D.Companies[i].Update(D.Companies[i].Ticker, D.Companies[i].Time_Frames[j]);
			}
			Open_Deal_1();
			Close_Deal_1();
		}

		public Main()
		{
			Positions = new List<Position> { };
			Deals = new Dictionary<string, List<Deal>> { };
			D = new Data();
			for (int i = 0; i < D.Tickers.Count; i++)
			{
				Positions.Add(new Position(D.Tickers[i], 0));
				Deals[D.Tickers[i]] = new List<Deal> { };
			}
		}
	}
}