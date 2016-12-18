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
    /// Логика взаимодействия для Chart.xaml
    /// </summary>
    public partial class Chart : Window
    {
        public Chart(Main main, string ticker, Deal deal)
        {
            InitializeComponent();
        }

        private void closechart_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
