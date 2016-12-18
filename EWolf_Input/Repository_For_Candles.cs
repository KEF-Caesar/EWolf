using System.Collections.Generic;
using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace EWolf_Input
{
    public class Repository_For_Candles
    {
        const string source = "http://export.finam.ru/.txt?market=1&em={0}&code={1}&apply=0&df={2}&mf={3}&yf={4}&from={5}&dt={6}mt={7}&yt={8}&to={9}&p={10}&e=.txt&cn={11}&dtf=1&tmf=1&MSOR=1&mstime=on&mstimever=1&sep=1&sep2=1&datf=1";
        private List<string> periods = new List<string> { "M1", "M5", "M10", "M15", "M30", "H1", "D1" };
		private Dictionary<string, int> codes = new Dictionary<string, int>();
		private void CodesForDictionary ()
		{
			codes.Add("GAZP", 16842);
			codes.Add("SBER", 3);
			codes.Add("LKOH", 8);
			codes.Add("MGNT", 17086);
			codes.Add("NVTK", 17370);
			codes.Add("GMKN", 795);
			codes.Add("SNGS", 4);
			codes.Add("SNGSP", 13);
			codes.Add("ROSN", 17273);
			codes.Add("VTBR", 19043);
			codes.Add("TRNFP", 1012);
			codes.Add("TATN", 825);
			codes.Add("ALRS", 81820);
			codes.Add("MTSS", 15523);
			codes.Add("MOEX", 152798);
			codes.Add("CHMF", 16136);
		}
        private IReadOnlyList<string> _Formats;
        public IReadOnlyList<string> Formats { get { return _Formats; } private set { _Formats = Formats; } }
        private string _Period;
        public string Period { get { return _Period; } private set { _Period = Period; } }
        private int _Days;
        public int Days { get { return _Days; } private set { _Days = Days; } }
        public Repository_For_Candles(IReadOnlyList<string> formats, string period, int days)
        {    
            _Formats = formats;
            _Period = period;
            _Days = days;
			CodesForDictionary();
            GetCandles(_Formats, _Period, _Days);
        }
        public async Task Timer1 ()
        {
            await Task.Delay(3000);
        }
		public async Task Timer2 ()
		{
			await Task.Delay(60000);
		}
         async void GetCandles(IReadOnlyList<string> tickers, string period, int days)
        {
          
                for (int i = 0; i <tickers.Count; i++)
                {
                    await Timer1();
                    using (WebClient client = new WebClient())
                    {
                        DateTime todate = DateTime.Now;
                        DateTime fromdate = todate.AddDays(-days);
                        string[] dateformatfrom = { fromdate.Year.ToString(), (fromdate.Month - 1).ToString(), fromdate.Day.ToString() };
                        string dateformatfr = fromdate.Date.ToString();
                        string[] dateformatto = { todate.Year.ToString(), (todate.Month - 1).ToString(), todate.Day.ToString() };
                        string dateformatt = todate.Date.ToString();
				    	int periodformat = periods.FindIndex(item => item == period) + 2;
						string code = codes[tickers[i]].ToString();
                        string currentsource = string.Format(source, code, tickers[i], dateformatfrom[2], dateformatfrom[1], dateformatfrom[0], dateformatfr, dateformatto[2], dateformatto[1], dateformatto[0], dateformatt, periodformat, tickers[i]);
                        Uri uri = new Uri(currentsource);
                        client.DownloadStringAsync(uri);        
                       client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadStringCallback);                    
                    }                  
                } 
        }

        void DownloadStringCallback(object s, DownloadStringCompletedEventArgs e)
        {
            string str = e.Result;
            string name;
            name = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ',')
                {
                    name = name + str[i];
                }
                else 
                {
                    break;
                }
            }
            if (str.Length > 4 && !str.StartsWith("Сист"))
            {
                FileStream file = new FileStream("..\\..\\..\\EWolf_Test\\Original_Data\\" + name + " " + Period + ".txt", FileMode.Create, FileAccess.ReadWrite);
                using (StreamWriter sw = new StreamWriter(file, System.Text.Encoding.Default))
                {
                    sw.Write(str);
                }
                file.Close();
            }
            else
            {

            }
        }
	}
}