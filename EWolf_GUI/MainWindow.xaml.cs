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

namespace EWolf_GUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class Example
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public partial class MainWindow : Window
	{
		public MainWindow()
		{            
            InitializeComponent();
            List<Example> test = new List<Example> {};
            test.Add(new Example {Title = "Test1", Description = "something1" });
            test.Add(new Example {Title = "Test2", Description = "something2" });
            listBoxDeals.ItemsSource = test;           
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
