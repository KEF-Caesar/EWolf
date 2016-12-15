using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWolf_Trading_Algorithms
{
	class Order
	{
		private DateTime _Date_Time_;
		public DateTime Date_Time
		{
			get
			{
				return _Date_Time_;
			}
		}
		private long _Volume_;
		public long Volume
		{
			get
			{
				return _Volume_;
			}
		}

		public Order(DateTime _Date_Time, long _Volume)
		{
			_Date_Time_ = _Date_Time;
			_Volume_ = _Volume;
		}
	}
}