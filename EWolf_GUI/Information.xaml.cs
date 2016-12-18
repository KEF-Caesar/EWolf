using System.Windows;
using EWolf_Trading_Algorithms;

namespace EWolf_GUI
{
    /// <summary>
    /// Логика взаимодействия для Information.xaml
    /// </summary>
    public partial class Information : Window
    {
        public Deal current_deal;
        public Main current_main;
        public string current_ticker;
        public Information(Main main, string ticker, Deal current)
        {               
            InitializeComponent();
            current_deal = current;
            current_main = main;
            current_ticker = ticker;
            foreach (var el in current.Headers)
            {
                listBox1.Items.Add(new Result { Title = el });
            }
            foreach (var el in current.Values)
            {
                listBox2.Items.Add(new Result { Title = el });
            }
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonChart_Click(object sender, RoutedEventArgs e)
        {
            var chart = new Chart(current_main, current_ticker, current_deal);
            chart.Show();
        }
    }
}