using System.Collections.Generic;
using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace EWolf_Input
{
    public class Repository_For_Candles
    {
        const string source = "http://export.finam.ru/1.txt?market=1&em=3&code={0}&apply=0&df={1}&mf={2}&yf={3}&from={4}&dt={5}&mt={6}&yt={7}&to={8}&p={9}&f=1&e=.txt&cn={0}&dtf=1&tmf=1&MSOR=1&mstime=on&mstimever=1&sep=1&sep2=1&datf=1";
        private List<string> periods = new List<string> { "M1", "M5", "M10", "M15", "M30", "H1", "D1" };
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
            GetCandles(_Formats, _Period, _Days);
            
        }
        public async Task Timer ()
        {
            await Task.Delay(3000);
        }
         async void GetCandles(IReadOnlyList<string> tickers, string period, int days)
        {
          
                for (int i = 0; i <tickers.Count; i++)
                {
                    await Timer();
                    using (WebClient client = new WebClient())
                    {
                        DateTime todate = DateTime.Now;
                        DateTime fromdate = todate.AddDays(-days);
                        string[] dateformatfrom = { fromdate.Year.ToString(), (fromdate.Month - 1).ToString(), fromdate.Day.ToString() };
                        string dateformatfr = fromdate.Date.ToString();
                        string[] dateformatto = { todate.Year.ToString(), (todate.Month - 1).ToString(), todate.Day.ToString() };
                        string dateformatt = todate.Date.ToString();
                        int periodformat = periods.FindIndex(item => item == period) + 2;
                        string currentsource = string.Format(source, tickers[i], dateformatfrom[2], dateformatfrom[1], dateformatfrom[0], dateformatfr, dateformatto[2], dateformatto[1], dateformatto[0], dateformatt, periodformat);
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
                FileStream file = new FileStream("..\\..\\..\\EWolf_Data\\Data\\" + name + " " + Period + ".txt", FileMode.Create, FileAccess.ReadWrite);
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
    

