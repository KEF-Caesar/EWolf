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
using System.Windows.Shapes;
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
            listBox1.Items.Add(current.Headers);
            listBox2.Items.Add(current.Values);
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
