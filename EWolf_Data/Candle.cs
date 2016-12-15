using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWolf_Data
{
	public class Candle
	{
		private double _Open_;
		public double Open
		{
			get
			{
				return _Open_;
			}
		}
		private double _Close_;
		public double Close
		{
			get
			{
				return _Close_;
			}
		}
		private double _High_;
		public double High
		{
			get
			{
				return _High_;
			}
		}
		private double _Low_;
		public double Low
		{
			get
			{
				return _Low_;
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
		private DateTime _Date_Time_;
		public DateTime Date_Time
		{
			get
			{
				return _Date_Time_;
			}
		}

		public override string ToString()
		{
			string Result = _Date_Time_.ToString() + " ";
			Result += _Open_.ToString() + " ";
			Result += _High_.ToString() + " ";
			Result += _Low_.ToString() + " ";
			Result += _Close_.ToString() + " ";
			Result += _Volume_.ToString() + " ";
			return Result;
		}

		public Candle(string _Date, string _Time, string _Open, string _Close, string _High, string _Low, string _Volume)
		{
			_Open_ = double.Parse(_Open);
			_Close_ = double.Parse(_Close);
			_High_ = double.Parse(_High);
			_Low_ = double.Parse(_Low);
			_Volume_ = long.Parse(_Volume);
			string _Year = _Date[0].ToString() + _Date[1].ToString() + _Date[2].ToString() + _Date[3].ToString();
			int Year = int.Parse(_Year);
			string _Month = _Date[4].ToString() + _Date[5].ToString();
			int Month = int.Parse(_Month);
			string _Day = _Date[6].ToString() + _Date[7].ToString();
			int Day = int.Parse(_Day);
			string _Hour = _Time[0].ToString() + _Time[1].ToString();
			int Hour = int.Parse(_Hour);
			string _Minute = _Time[2].ToString() + _Time[3].ToString();
			int Minute = int.Parse(_Minute);
			string _Second = _Time[4].ToString() + _Time[5].ToString();
			int Second = int.Parse(_Second);
			_Date_Time_ = new DateTime(Year, Month, Day, Hour, Minute, Second);
		}
	}
}