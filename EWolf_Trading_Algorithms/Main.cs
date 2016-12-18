using EWolf_Data;
using System.Collections.Generic;

namespace EWolf_Trading_Algorithms
{
	public class Main
	{
		private Dictionary<string, Stock> Stocks;
		public Data D;
		public delegate void Deal_Delegate(string _Ticker, Deal _Deal);
		public event Deal_Delegate Deal_Event;

		void Algo_Open_1()
		{
			const double Magic_Const = 0.002;
			const int Magic_Count = 60;
			for (int i = 0; i < D.Tickers.Count; i++)
			{
				string T = D.Tickers[i];
				if (Stocks[T].Current_Volume == 0)
				{
					int Number_of_Candles = D.Companies[T].Candles["M1"].Count;
					Candle Last_Candle = D.Companies[T].Candles["M1"][Number_of_Candles - 1];
					double High_Price = double.MinValue;
					double Low_Price = double.MaxValue;
					double Price = D.Companies[T].Candles["M1"][Number_of_Candles - 1].Close;
					for (int j = Number_of_Candles - 1; j >= Number_of_Candles - Magic_Count; j--)
					{
						Candle Current_Candle = D.Companies[T].Candles["M1"][j];
						if (Current_Candle.High > High_Price)
							High_Price = Current_Candle.High;
						if (Current_Candle.Low < Low_Price)
							Low_Price = Current_Candle.Low;
					}
					Deal New_Deal = new Deal();
					New_Deal.High = Price;
					New_Deal.Low = Price;
					New_Deal.Open = Price;
					if (Price <= Low_Price * (1.0 + Magic_Const))
					{
						New_Deal.Orders.Clear();
						New_Deal.Orders.Add(new Order(Last_Candle.Date_Time, -10));
					}
					if (Price >= High_Price * (1.0 - Magic_Const))
					{
						New_Deal.Orders.Clear();
						New_Deal.Orders.Add(new Order(Last_Candle.Date_Time, 10));
					}
					if (New_Deal.Orders.Count == 1)
					{
						Stocks[T].Deals.Add(New_Deal);
						Stocks[T].Current_Volume = New_Deal.Orders[0].Volume;
					}
				}
			}
		}

		void Push_Info_to_Deal(Deal CD) // CD - Current Deal 
		{
			CD.Profit_or_Loss = CD.Close / CD.Open - 1.0;
			CD.Headers.Add("Date & Time (Open)");
			CD.Values.Add(CD.Orders[0].Date_Time.ToString());
			CD.Headers.Add("Date & Time (Close)");
			CD.Values.Add(CD.Orders[1].Date_Time.ToString());
			CD.Headers.Add("Time (Minutes)");
			CD.Values.Add((CD.Orders[1].Date_Time - CD.Orders[0].Date_Time).TotalMinutes.ToString());
			CD.Headers.Add("Price (Open)");
			CD.Values.Add(CD.Open.ToString());
			CD.Headers.Add("Price (Close)");
			CD.Values.Add(CD.Close.ToString());
			CD.Headers.Add("Profit or Loss");
			CD.Values.Add(CD.Profit_or_Loss.ToString());
			return;
		}

		void Algo_Close_1()
		{
			const double Magic_Const = 0.001;
			for (int i = 0; i < D.Tickers.Count; i++)
			{
				string T = D.Tickers[i];
				if (Stocks[T].Current_Volume != 0)
				{
					int Number_of_Candles = D.Companies[T].Candles["M1"].Count;
					Candle Last_Candle = D.Companies[T].Candles["M1"][Number_of_Candles - 1];
					int Number_of_Current_Deal = Stocks[T].Deals.Count;
					Deal Current_Deal = Stocks[T].Deals[Number_of_Current_Deal - 1];
					double Price = Last_Candle.Close;
					double High_Price = Last_Candle.High;
					double Low_Price = Last_Candle.Low;
					if (Current_Deal.High < High_Price)
						Current_Deal.High = High_Price;
					if (Current_Deal.Low > Low_Price)
						Current_Deal.Low = Low_Price;
					if (Stocks[T].Current_Volume > 0)
					{
						if (Price <= Current_Deal.High * (1.0 - Magic_Const))
						{
							Current_Deal.Orders.Add(new Order(Last_Candle.Date_Time, -Stocks[T].Current_Volume));
							Current_Deal.Close = Price;
							Push_Info_to_Deal(Current_Deal);
							Stocks[T].Current_Volume = 0;
							Deal_Event.Invoke(T, Current_Deal);
						}
					}
					if (Stocks[T].Current_Volume < 0)
					{
						if (Price >= Current_Deal.Low * (1.0 + Magic_Const))
						{
							Current_Deal.Orders.Add(new Order(Last_Candle.Date_Time, -Stocks[T].Current_Volume));
							Current_Deal.Close = Price;
							Push_Info_to_Deal(Current_Deal);
							Stocks[T].Current_Volume = 0;
							Deal_Event.Invoke(T, Current_Deal);
						}
					}
				}
			}
		}

		public void Iteration()
		{
			D.Update();
			Algo_Open_1();
			Algo_Close_1();
		}

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