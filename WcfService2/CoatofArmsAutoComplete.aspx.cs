using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;

namespace WcfService2
{

    public partial class CoatofArmsAutoComplete : System.Web.UI.Page
    {
        public List<House> HouseList { get; set; }

        public List<string> CoatofArms = new List<string>();

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
                    CoatofArms.Add(x.CoatOfArms);
                }
            }
            //filtered Coat of Arms List

            List<string> filteredCOA= new List<string>();

            //filtering the coat of arms by input

            foreach (string coa in CoatofArms)
            {
                if (coa.ToLower().Contains(term.ToLower()))
                {
                    filteredCOA.Add(coa);

                }
            }


            string responseJSON = JsonConvert.SerializeObject(filteredCOA);

            Response.Write(responseJSON);

            Response.End();

        }


    }
}
