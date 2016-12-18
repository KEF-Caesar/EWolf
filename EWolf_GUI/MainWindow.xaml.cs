using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EWolf_Trading_Algorithms;
using EWolf_Test;

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
            listBoxDeals.Items.Add(new Result { Title = ticker, Description = current_deal.Low.ToString() });
            list.Add(current_deal);
            tickers.Add(ticker);
        }

		public MainWindow()
		{            
            InitializeComponent();
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