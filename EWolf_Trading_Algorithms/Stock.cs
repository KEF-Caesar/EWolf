using System.Collections.Generic;

namespace EWolf_Trading_Algorithms
{
	public class Stock
	{
		private string _Ticker_;
		public string Ticker
		{
			get
			{
				return _Ticker_;
			}
		}
		public long Current_Volume { get; set; }
		public List<Deal> Deals;

		public Stock(string _Ticker)
		{
			_Ticker_ = _Ticker;
			Current_Volume = 0;
			Deals = new List<Deal> { };
		}
	}
}