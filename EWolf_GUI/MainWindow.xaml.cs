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

    public class List_deals
    {
        public string Ticker;
        public Deal Deal;
    }

    public class InformationW
    {
        public List<string> Heading;
        public List<string> Value;
    }

    public partial class MainWindow : Window
	{
        public Main main;
       
        public void Deals(string ticker, Deal current_deal)
        {
            listBoxDeals.Items.Add(new Result { Title = ticker, Description = current_deal.Low.ToString() });
        }

		public MainWindow()
		{            
            InitializeComponent();
            main = new Main();
            main.Deal_Event += Deals;
        }
               
        private void GetInfo_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxDeals.SelectedItem != null)
            {
                string item = listBoxDeals.SelectedItem.ToString();                         
                var information = new Information(item);
                    information.Show();
            }
        }                
    }
}
