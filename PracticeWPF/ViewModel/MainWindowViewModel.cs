using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;
using PracticeWPF.Core;
using PracticeWPF.Core.Service;
using PracticeWPF.Model;
using System.Threading;
using System.Collections.ObjectModel;

namespace PracticeWPF.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        STOCK_DAY_AVG data;
        public MainWindowViewModel()
        {
            data = restful.Get_STOCK_DAY_AVG<STOCK_DAY_AVG>();
            title = data.title;

            Values = new ChartValues<double>();
            Labels = new ObservableCollection<string>();


            Task t = new Task(appendData);
            t.Start();
        }
        public ChartValues<double> Values { get; set; }
        public ObservableCollection<string> Labels { get; set; }
        public void appendData()
        {
            for (int i = 0; i < data.data.Length - 1; i++)
            {
                //append data
                Labels.Add(data.data[i][0]);
                Values.Add(Convert.ToDouble(data.data[i][1]));
                Thread.Sleep(1000);
            }
        }
    }
}
