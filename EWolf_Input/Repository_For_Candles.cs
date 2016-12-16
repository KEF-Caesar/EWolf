using System.Collections.Generic;
using System;
using System.Net;
using System.IO;

namespace EWolf_Input
{
   public class Repository_For_Candles
    {
        const string source = "http://export.finam.ru/1.txt?market=1&em=3&code={0}&apply=0&df={1}&mf={2}&yf={3}&from={4}&dt={5}&mt={6}&yt={7}&to={8}&p={9}&f=1&e=.txt&cn={0}&dtf=1&tmf=1&MSOR=1&mstime=on&mstimever=1&sep=1&sep2=1&datf=1";
        private List<string> periods = new List<string> { "M1", "M5", "M10", "M15", "M30", "H1", "D1" };
        private string _Format;
        public string Format { get { return _Format; } private set { _Format = Format; } }
        private string _Period;
        public string Period { get { return _Period; } private set { _Period = Period; } }
        public Repository_For_Candles(string format, string period)
        {
            _Format = format;
            _Period = period;
        }
        public async void GetCandles(string ticker, string period, int days)
        {
            using (WebClient client = new WebClient())
            {
                DateTime todate = DateTime.Now;
                DateTime fromdate = todate.AddDays(-days);
                string[] dateformatfrom = { fromdate.Year.ToString(), (fromdate.Month - 1).ToString(), fromdate.Day.ToString() };
                string dateformatfr = fromdate.Date.ToString();
                string[] dateformatto = { todate.Year.ToString(), (todate.Month - 1).ToString(), todate.Day.ToString() };
                string dateformatt = todate.Date.ToString();
                int periodformat = periods.FindIndex(item => item == period) + 2;
                string currentsource = string.Format(source, ticker, dateformatfrom[2], dateformatfrom[1], dateformatfrom[0], dateformatfr, dateformatto[2], dateformatto[1], dateformatto[0], dateformatt, periodformat);
                Uri uri = new Uri(currentsource);
                client.DownloadStringAsync(uri);
                client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadStringCallback);

            }
        }
        public void DownloadStringCallback(object s, DownloadStringCompletedEventArgs e)
        {
            string str = e.Result;
            FileStream file = new FileStream("..\\..\\..\\EWolf_Data\\Data\\" + Format + " " + Period + ".txt", FileMode.Create);
            using (StreamWriter sw = new StreamWriter(file, System.Text.Encoding.Default))
            {
                sw.Write(str);
            }
            file.Close();

        }
    }
}
