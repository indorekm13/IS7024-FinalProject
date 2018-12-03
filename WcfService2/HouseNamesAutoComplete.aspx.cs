using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;

namespace WcfService2
{

    public partial class HouseNamesAutoComplete : System.Web.UI.Page
    {
        public List<House> HouseList { get; set; }

        public List<string> HouseNames = new List<string>();

        protected void Page_Load(object sender, EventArgs e){

           string term = Request.QueryString["term"];

            Response.Clear();

            Response.ContentType = "application/json; charset=utf-8";
            using (var webClient = new WebClient())
            {
                string rawData = webClient.DownloadString("https://www.anapioficeandfire.com/api/houses");
                HouseList = JsonConvert.DeserializeObject<List<House>>(rawData);
                foreach (var x in HouseList)
                {
                    HouseNames.Add(x.Name);
                }
            }

            //filtered HouseNames List

            List<string> filteredHouseNames = new List<string>();

            //filtering the HouseNames by input

            foreach(string name in HouseNames){
                if(name.ToLower().Contains(term.ToLower())){
                    filteredHouseNames.Add(name);

                }
            }

            string responseJSON= JsonConvert.SerializeObject(filteredHouseNames);

            Response.Write(responseJSON);

            Response.End();
        }



    }
}
