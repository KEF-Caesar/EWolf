using EWolf_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWolf_Input;
namespace EWolf_Test
{
	class Program
	{
		static void Main(string[] args)
		{
            // Пример использования метода для получения свечей и их записи в файл
            Repository_For_Candles repo;
            repo = new Repository_For_Candles("SBER", "M1");
            repo.GetCandles("SBER", "M1", 5);
            Console.WriteLine("Success!");
			Console.ReadLine();
		}
	}
}