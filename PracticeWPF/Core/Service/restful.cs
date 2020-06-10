using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace PracticeWPF.Core.Service
{
    class restful
    {
        private static string http = "https://www.twse.com.tw/exchangeReport/";

        public static TResult Get_STOCK_DAY_AVG<TResult>(string stockNo, DateTime selectMonth)
        {
            string format = "json";
            string para = "STOCK_DAY_AVG?response=" + format + "&date=" + selectMonth.ToString("yyyyMMdd") + "&stockNo=" + stockNo;

            RestClient client = new RestClient(http + para);

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<TResult>(response.Content);
        }
    }

}
