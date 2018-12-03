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
            string term = Request.QueryString["term"];

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
            //filtered Regions List

            List<string> filteredRegions= new List<string>();

            //filtering the regions by input

            foreach (string regions in Regions)
            {
                if (regions.ToLower().Contains(term.ToLower()))
                {
                    filteredRegions.Add(regions);

                }
            }

            string responseJSON = JsonConvert.SerializeObject(filteredRegions);

            Response.Write(responseJSON);

            Response.End();

        }
    }
}
