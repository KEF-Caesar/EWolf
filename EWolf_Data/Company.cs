using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EWolf_Data
{
	public class Company
	{
		public IReadOnlyList<string> Time_Frames = new List<string> { "M1", "M5" };
		private string _Ticker_;
		public string Ticker
		{
			get
			{
				return _Ticker_;
			}
		}
		private Dictionary<string, IReadOnlyList<Candle>> _Candles_;
		public IReadOnlyDictionary<string, IReadOnlyList<Candle>> Candles
		{
			get
			{
				return _Candles_;
			}
		}

		public void Update(string _Ticker, string Time_Frame)
		{
			StreamReader sr = new StreamReader("..\\..\\..\\EWolf_Data\\Data\\" + _Ticker + " " + Time_Frame + ".txt");
			List<Candle> Historical_Candles = new List<Candle> { };
			string str;
			sr.ReadLine();
			while ((str = sr.ReadLine()) != null)
			{
				string[] Arr = str.Split(',');
				string[] arr = new string[Arr.Length];
				for (int i = 0; i < Arr.Length; i++)
				{
					arr[i] = "";
					for (int j = 0; j < Arr[i].Length; j++)
					{
						if (Arr[i][j] == '.')
							arr[i] += ',';
						else
							arr[i] += Arr[i][j];
					}
				}
				string Date = arr[2];
				string Time = arr[3];
				string Open = arr[4];
				string Close = arr[7];
				string High = arr[5];
				string Low = arr[6];
				string Volume = arr[8];
				Historical_Candles.Add(new Candle(Date, Time, Open, Close, High, Low, Volume));
			}
			_Candles_[Time_Frame] = Historical_Candles;
			sr.Close();
			return;
		}

		public Company(string _Ticker)
		{
			_Ticker_ = _Ticker;
			_Candles_ = new Dictionary<string, IReadOnlyList<Candle>> { };
			for (int i = 0; i < Time_Frames.Count; i++)
			{
				Update(_Ticker, Time_Frames[i]);
			}
		}
	}
}