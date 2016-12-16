using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWolf_Input
{
    class Repository_For_Candles
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
    }
}
