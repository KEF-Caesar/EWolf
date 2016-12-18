using EWolf_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using EWolf_Trading_Algorithms;

namespace EWolf_Test
{
	public class Magic
	{
		public Main F;
		double Number_of_Deals;
		double Total_PoL;
		double Total_Time;

		public void Print_Deal(string _Ticker, Deal _Deal)
		{
			DateTime _Open = _Deal.Orders[0].Date_Time;
			DateTime _Close = _Deal.Orders[1].Date_Time;
			double Price_Open = 0;
			double Price_Close = 0;
			int N = F.D.Companies[_Ticker].Candles["M1"].Count;
			List<Candle> C = F.D.Companies[_Ticker].Candles["M1"].ToList();
			for (int i = 0; i < N; i++)
			{
				if (C[i].Date_Time == _Open)
					Price_Open = C[i].Close;
				if (C[i].Date_Time == _Close)
					Price_Close = C[i].Close;
			}
			double PoL = Price_Close / Price_Open;
			string res = _Ticker + " " + Price_Open.ToString() + " " + Price_Close.ToString() + " " + PoL.ToString();
			Number_of_Deals += 1.0;
			Total_PoL += PoL;
			Total_Time += (_Close - _Open).TotalMinutes;
		}

		public void Run()
		{
			Number_of_Deals = 0;
			Total_PoL = 0;
			Total_Time = 0;
			Offline_Test Off_Test = new Offline_Test();
			F.Deal_Event += Print_Deal;
			for (int i = 1; i <= 50; i++)
			{
				Off_Test.Update();
				F.Iteration();
			}
		}

		public Magic()
		{
			F = new Main();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Magic M = new Magic();
			M.Run();
		}
	}
}