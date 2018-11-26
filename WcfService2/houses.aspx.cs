using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace WcfService2
{
    public partial class houses : System.Web.UI.Page
    {
        public List<House> Houses { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var webClient = new WebClient())
            {
                string rawData = webClient.DownloadString("https://www.anapioficeandfire.com/api/houses");
                Houses = JsonConvert.DeserializeObject<List<House>>(rawData);
            }
        }

        public string GetTableData()
        {
            string htmlStr = "";
            foreach (var house in Houses)
            {
                if (string.IsNullOrEmpty(house.name))
                {
                    house.name = "Not Available";
                }
                if (string.IsNullOrEmpty(house.region))
                {
                    house.region = "Not Available";
                }
                if (string.IsNullOrEmpty(house.coatOfArms))
                {
                    house.coatOfArms = "Not Available";
                }
                if (string.IsNullOrEmpty(house.words))
                {
                    house.words = "Not Available";
                }
                htmlStr += "<tr>" +
                    "<td>" + house.name + "</td>" +
                    "<td>" + house.region + "</td>" +
                    "<td>" + house.coatOfArms + "</td>" +
                    "<td>" + house.words + "</td>" +
                    "<td>" + GetSeatsList(house.seats) + "</td>" +
                    "</tr>";
            }

            return htmlStr;
        }

        private string GetSeatsList(List<string> list)
        {
            StringBuilder listString = new StringBuilder();
            listString.Append("<ul>");
            foreach (var item in list)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    listString.Append("<li>");
                    listString.Append(item);
                    listString.Append("</li>");
                }
                else
                {
                    listString.Append("Not Available");
                }
            }
            listString.Append("</ul>");

            return listString.ToString();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var houseName = TxtHouseName.Text.ToLower();
            var region = TxtRegion.Text.ToLower();
            var coatOfArms = TxtCoatOfArms.Text.ToLower();
            var words = TxtWords.Text.ToLower();
            if (!string.IsNullOrEmpty(houseName))
            {
                Houses = Houses.Where(b => b.name.ToLower().Contains(houseName)).ToList();
            }
            if (!string.IsNullOrEmpty(region))
            {
                Houses = Houses.Where(b => b.region.ToLower().Contains(region)).ToList();
            }
            if (!string.IsNullOrEmpty(coatOfArms))
            {
                Houses = Houses.Where(b => b.coatOfArms.ToLower().Contains(coatOfArms)).ToList();
            }
            if (!string.IsNullOrEmpty(words))
            {
                Houses = Houses.Where(b => b.words.ToLower().Contains(words)).ToList();
            }
        }
    }
}