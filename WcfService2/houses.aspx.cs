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
                if (string.IsNullOrEmpty(house.Name))
                {
                    house.Name = "Not Available";
                }
                if (string.IsNullOrEmpty(house.Region))
                {
                    house.Region = "Not Available";
                }
                if (string.IsNullOrEmpty(house.CoatOfArms))
                {
                    house.CoatOfArms = "Not Available";
                }
                if (string.IsNullOrEmpty(house.Words))
                {
                    house.Words = "Not Available";
                }
                htmlStr += "<tr>" +
                    "<td>" + house.Name + "</td>" +
                    "<td>" + house.Region + "</td>" +
                    "<td>" + house.CoatOfArms + "</td>" +
                    "<td>" + house.Words + "</td>" +
                    "<td>" + GetSeatsList(house.Seats) + "</td>" +
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
                Houses = Houses.Where(b => b.Name.ToLower().Contains(houseName)).ToList();
            }
            if (!string.IsNullOrEmpty(region))
            {
                Houses = Houses.Where(b => b.Region.ToLower().Contains(region)).ToList();
            }
            if (!string.IsNullOrEmpty(coatOfArms))
            {
                Houses = Houses.Where(b => b.CoatOfArms.ToLower().Contains(coatOfArms)).ToList();
            }
            if (!string.IsNullOrEmpty(words))
            {
                Houses = Houses.Where(b => b.Words.ToLower().Contains(words)).ToList();
            }
        }
    }
}