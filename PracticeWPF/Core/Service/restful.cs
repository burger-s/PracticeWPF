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

        public static TResult Get_STOCK_DAY_AVG<TResult>()
        {
            string format = "json";
            int stockNo = 3023;
            DateTime date = new DateTime(2020, 5, 1);
            string para = "STOCK_DAY_AVG?response=" + format + "&date=" + date.ToString("yyyyMMdd") + "&stockNo=" + stockNo.ToString();

            RestClient client = new RestClient(http + para);

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<TResult>(response.Content);
        }
    }

}
