using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EWolf_Data;

namespace EWolf_Test
{
	class Offline_Test
	{
		public IReadOnlyList<string> Tickers = new List<string> { "GAZP", "SBER", "LKOH", "MGNT", "NVTK",
			"GMKN", "SNGS", "SNGSP", "ROSN", "VTBR", "TRNFP", "TATN", "ALRS", "MTSS", "MOEX", "CHMF" };
		int N;

		public void Update()
		{
			N++;
			for (int i = 0; i < Tickers.Count; i++)
			{
				string T = Tickers[i];
				string Name = T + " M1.txt";
				List<string> Arr = new List<string> { };
				StreamReader sr = new StreamReader("..\\..\\..\\EWolf_Test\\Original_Data\\" + Name);
				for (int j = 1; j <= N; j++)
					Arr.Add(sr.ReadLine());
				sr.Close();
				StreamWriter sw = new StreamWriter("..\\..\\..\\EWolf_Data\\Data\\" + Name);
				for (int j = 0; j < Arr.Count; j++)
					sw.WriteLine(Arr[j]);
				sw.Close();
			}
		}

		public Offline_Test()
		{
			N = 499;
			Update();
		}
	}
}