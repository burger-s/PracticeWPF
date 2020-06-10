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
using System.Windows.Input;
using PracticeWPF.Core;

namespace PracticeWPF.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        STOCK_DAY_AVG data;
        public MainWindowViewModel()
        {
            cmdGetData = new RelayCommand(getStockData);
        }
        public ChartValues<double> Values { get; set; }
        public ObservableCollection<string> Labels { get; set; }
        public ICommand cmdGetData { set; get; }
        public bool Idle { set; get; } = true;
        public string stockNumber { set; get; }
        public DateTime selectMonth { set; get; }
        public void getStockData()
        {
            data = restful.Get_STOCK_DAY_AVG<STOCK_DAY_AVG>(stockNumber, selectMonth);
            title = data.title;

            Values = new ChartValues<double>();
            Labels = new ObservableCollection<string>();

            Task t = new Task(appendData);
            t.Start();
        }
        public void appendData()
        {
            Idle = false;
            for (int i = 0; i < data.data.Length - 1; i++)
            {
                //append data
                Labels.Add(data.data[i][0]);
                Values.Add(Convert.ToDouble(data.data[i][1]));
                Thread.Sleep(200);
            }
            Idle = true;
        }
    }
}
