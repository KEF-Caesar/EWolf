using System.Collections.Generic;
using System.Windows;
using EWolf_Trading_Algorithms;
using EWolf_Test;
using EWolf_Input;

namespace EWolf_GUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class Result
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public partial class MainWindow : Window
	{
        public Main main;
        List<Deal> list = new List<Deal> { };
        List<string> tickers = new List<string> { };
        public void Deals(string ticker, Deal current_deal)
        {
            listBoxDeals.Items.Add(new Result { Title = ticker, Description = current_deal.Profit_or_Loss.ToString() });
            list.Add(current_deal);
            tickers.Add(ticker);
        }

		public MainWindow()
		{            
            InitializeComponent();
			IReadOnlyList<string> Tickers = new List<string> { "GAZP", "SBER", "LKOH", "MGNT", "NVTK",
			"GMKN", "SNGS", "SNGSP", "ROSN", "VTBR", "TRNFP", "TATN", "ALRS", "MTSS", "MOEX", "CHMF" };
			Repository_For_Candles RFC = new Repository_For_Candles(Tickers, "M1", 5);
			Magic M = new Magic();
			M.F.Deal_Event += Deals;
			main = M.F;
			M.Run();
			//main = new Main();
            //main.Deal_Event += Deals;
        }
               
        private void GetInfo_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxDeals.SelectedItem != null)
            {
                int item = listBoxDeals.SelectedIndex;                                         
                var information = new Information(main, tickers[item], list[item]);
                    information.Show();
            }
        }                
    }
}