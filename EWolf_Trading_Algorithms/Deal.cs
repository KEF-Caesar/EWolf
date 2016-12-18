using System.Collections.Generic;

namespace EWolf_Trading_Algorithms
{
	public class Deal
	{
		public List<Order> Orders;
		public List<string> Headers;
		public List<string> Values;
		public double High { get; set; }
		public double Low { get; set; }
		public double Open { get; set; }
		public double Close { get; set; }
		public double Profit_or_Loss { get; set; }

		public Deal()
		{
			Orders = new List<Order> { };
			Headers = new List<string> { };
			Values = new List<string> { };
			Low = double.MaxValue;
			High = double.MinValue;
			Open = 0;
			Close = 0;
			Profit_or_Loss = 0;
		}
	}
}