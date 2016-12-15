using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWolf_Data
{
	public class Data
	{
		public IReadOnlyList<string> Tickers = new List<string> { "GAZP", "SBER", "LKOH", "MGNT", "NVTK",
			"GMKN", "SNGS", "SNGSP", "ROSN", "VTBR", "TRNFP", "TATN", "ALRS", "MTSS", "MOEX", "CHMF" };
		private Dictionary<string, Company> _Companies_;
		public IReadOnlyDictionary<string, Company> Companies
		{
			get
			{
				return _Companies_;
			}
		}

		public void Update()
		{
			for (int i = 0; i < Tickers.Count; i++)
			{
				Company Current_Company = _Companies_[Tickers[i]];
				for (int j = 0; j < Current_Company.Time_Frames.Count; j++)
					Current_Company.Update(Current_Company.Ticker, Current_Company.Time_Frames[j]);
			}
		}

		public Data()
		{
			_Companies_ = new Dictionary<string, Company> { };
			for (int i = 0; i < Tickers.Count; i++)
			{
				_Companies_[Tickers[i]] = new Company(Tickers[i]);
			}
		}
	}
}