using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using PracticeWPF.Model;

namespace PracticeWPF.View
{
    /// <summary>
    /// UserControl1.xaml 的互動邏輯
    /// </summary>
    public partial class LineChart : UserControl
    {

        public Func<double, string> YFormatter { get; set; }
        public LineChart()
        {
            InitializeComponent();
            YFormatter = value => value.ToString("C");
            //DataContext = this;
        }
        //public string lineTitle { get; set; }
        public static readonly DependencyProperty lineTitleProperty = DependencyProperty.Register(nameof(lineTitle), typeof(double), typeof(LineChart), new PropertyMetadata());
        public string lineTitle
        {
            get => (string)GetValue(lineTitleProperty);
            set => SetValue(lineTitleProperty, value);
        }
        //public ChartValues<double> Values1 { get; set; }
        public static readonly DependencyProperty ChartValuesProperty = DependencyProperty.Register(nameof(Values), typeof(object), typeof(LineChart), new PropertyMetadata());
        public ChartValues<double> Values
        {
            get => (ChartValues<double>)GetValue(ChartValuesProperty);
            set => SetValue(ChartValuesProperty, value);
        }
        //public ObservableCollection<string> Labels { get; set; }
        public static readonly DependencyProperty ChartLabelsProperty = DependencyProperty.Register(nameof(mLabels), typeof(object), typeof(UserControl));
        public ObservableCollection<string> mLabels
        {
            get => (ObservableCollection<string>)GetValue(ChartLabelsProperty);
            set => SetValue(ChartLabelsProperty, value);
        }

    }
}
