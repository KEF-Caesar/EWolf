using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Linq;
using EWolf_Data;
using EWolf_Trading_Algorithms;
using System;

namespace EWolf_GUI
{
    /// <summary>
    /// Логика взаимодействия для Chart.xaml
    /// </summary>
    public partial class Chart : Window
    {
        public Chart(Main main, string ticker, Deal deal)
        {
			List<Candle> candlestodraw = new List<Candle> { };
			DateTime datetime_close = deal.Orders[deal.Orders.Count - 1].Date_Time;
			DateTime datetime_open = deal.Orders[0].Date_Time;
			List<Candle> list = main.D.Companies[ticker].Candles["M1"].ToList();
			int First = 0;
			int Last = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Date_Time == datetime_close)
				{
					Last = i;					
				}
				if (list[i].Date_Time == datetime_open)
				{
					First = i;
				}
			}
			if (Last - First + 1 <=30)
			{
				First = Last - 29;
			}
			for (int i = First; i <= Last; i++)
			{
				Candle candle = list[i];
				candlestodraw.Add(candle);
			}
			double min = candlestodraw[0].Low;
			double max = candlestodraw[0].High;
			int N = candlestodraw.Count;
			InitializeComponent();
			System.Windows.Forms.DataVisualization.Charting.Chart chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			chartarea.Child = chart;

			chart.ChartAreas.Add("Main");
			chart.Series.Add("Candles");
			chart.Series.FindByName("Candles").ChartArea = "Main";
			chart.Series.FindByName("Candles").ChartType = SeriesChartType.Candlestick;
			chart.Series.FindByName("Candles").YAxisType = AxisType.Secondary;
			for (int i = 1; i < N; i++)
			{
				if (min > candlestodraw[i].Low)
				{
					min = candlestodraw[i].Low;
				}
				if (max < candlestodraw[i].High)
				{
					max = candlestodraw[i].High;
				}
			}
			min = min * 0.997;
			max = max * 1.003;
			chart.ChartAreas.FindByName("Main").AxisY2.Maximum = max;
			chart.ChartAreas.FindByName("Main").AxisY2.Minimum = min;
			for (int i = 0; i < N; i++)
			{
				chart.Series.FindByName("Candles").Points.AddXY(i, candlestodraw[i].Low, candlestodraw[i].High, candlestodraw[i].Open, candlestodraw[i].Close);
				chart.Series.FindByName("Candles").Points[chart.Series.FindByName("Candles").Points.Count - 1].AxisLabel = candlestodraw[i].Date_Time.ToString();
				if (candlestodraw[i].Close > candlestodraw[i].Open)
				{
					chart.Series.FindByName("Candles").Points[chart.Series.FindByName("Candles").Points.Count - 1].Color = System.Drawing.Color.Green;
				}
				else
				{
					chart.Series.FindByName("Candles").Points[chart.Series.FindByName("Candles").Points.Count - 1].Color = System.Drawing.Color.Tomato;
				}
				chart.Series.FindByName("Candles").Points[chart.Series.FindByName("Candles").Points.Count - 1].BorderWidth = 5;
			}
			chartarea.Child.Show();
		}

		private void closechart_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}