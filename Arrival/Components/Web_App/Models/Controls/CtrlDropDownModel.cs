using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web_App.Models.Controls
{

    public class CtrlDropDownModel : CtrlBaseModel
    {

        public string Label { get; set; }
        public string ListId { get; set; }
        public string ColumnDataName { get; set; }

        private string URL_API_LISTs = "https://localhost:44345/api/ListOption/";
        public string ListOptions
        {
            get
            {
                var htmlOptions = "";
                var lst = GetOptionsFromAPI();

                foreach (var option in lst)
                {
                    htmlOptions += "<option value='" + option.ListValue + "'>" + option.ListDesc + "</option>";
                }
                return htmlOptions;
            }
            set
            {

            }
        }

        private List<OptionList> GetOptionsFromAPI()
        {
            var client = new WebClient();
            var response = client.DownloadString(URL_API_LISTs + ListId);
            var options = JsonConvert.DeserializeObject<List<OptionList>>(response);

            return options;
        }

        public CtrlDropDownModel()
        {
            ViewName = "";
        }
    }
}
/*public class CtrlDropDownModel : CtrlBaseModel
{
    public string Label { get; set; }
    public string ListId { get; set; }
    public string Service { get; set; }
    public string FunctionName { get; set; }

    private string URL_API_LISTs = "http://localhost:57056/api/";

    public string ListOptions
    {
        get
        {
            var htmlOptions = "";
            var lst = GetOptionsFromAPI();

            foreach (var option in lst)
            {
                htmlOptions += "<option value='" + option.ListValue + "'>" + option.ListDesc + "</option>";
            }
            return htmlOptions;
        }
        set
        {

        }
    }

    private List<OptionList> GetOptionsFromAPI()
    {
        List<OptionList> options = new List<OptionList>();
        var client = new WebClient();
        var response = client.DownloadString(URL_API_LISTs + Service + "/" + ListId);
        JObject jObject = JObject.Parse(response);
        JToken jData = jObject["Data"];
        foreach (var item in jData)
        {
            var listOption = new OptionList
            {
                ListId = Id,
                ListValue = item["value"].ToString(),
                ListDesc = item["name"].ToString()
            };
            options.Add(listOption);
        }
        return options;
    }





    public CtrlDropDownModel()
    {
        ViewName = "";
    }
}
}*/