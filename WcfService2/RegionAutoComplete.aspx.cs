using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;

namespace WcfService2
{

    public partial class RegionAutocomplete : System.Web.UI.Page
    {
        public List<House> HouseList { get; set; }

        public List<string> Regions = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Clear();

            Response.ContentType = "application/json; charset=utf-8";
            using (var webClient = new WebClient())
            {
                string rawData = webClient.DownloadString("https://www.anapioficeandfire.com/api/houses");
                HouseList = JsonConvert.DeserializeObject<List<House>>(rawData);
                foreach (var x in HouseList)
                {
                    Regions.Add(x.Region);
                }
            }

            string responseJSON = JsonConvert.SerializeObject(Regions);

            Response.Write(responseJSON);

            Response.End();

        }
    }
}
