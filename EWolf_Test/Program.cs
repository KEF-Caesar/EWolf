using EWolf_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using EWolf_Input;
using EWolf_Trading_Algorithms;
namespace EWolf_Test
{
	class Program
	{
		static void Main(string[] args)
		{
            // Пример использования метода для получения свечей и их записи в файл
			/*
                Repository_For_Candles repo; 
                IReadOnlyList<string> list = new List<string> { "GAZP","SBER", "LKOH", "MGNT", "NVTK",
               "GMKN", "SNGS", "SNGSP", "ROSN", "VTBR", "TRNFP","TATN", "ALRS", "MTSS", "MOEX", "CHMF" };
                repo = new Repository_For_Candles(list, "M1", 5);
			*/
			Main Fuck = new Main();
			Fuck.Iteration();
			Console.ReadLine();
		}
	}
}