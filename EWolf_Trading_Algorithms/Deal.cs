using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWolf_Trading_Algorithms
{
	class Deal
	{
		public List<Order> Orders;
		public double High { get; set; }
		public double Low { get; set; }

		public Deal()
		{
			Orders = new List<Order> { };
			Low = double.MaxValue;
			High = double.MinValue;
		}
	}
}