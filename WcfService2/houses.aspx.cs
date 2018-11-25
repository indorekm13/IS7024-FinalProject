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
                htmlStr += "<tr>" +
                    "<td>" + house.name + "</td>" +
                    "<td>" + house.region + "</td>" +
                    "<td>" + house.coatOfArms + "</td>" +
                    "<td>" + house.words + "</td>" +
                    "<td>" + GetStringList(house.seats) + "</td>" +
                    "</tr>";
            }

            return htmlStr;
        }

        private string GetStringList(List<string> list)
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
            var houseName = TxtHouseName.Text;
            var region = TxtRegion.Text;
            var coatOfArms = TxtCoatOfArms.Text;
            var words = TxtWords.Text;
            var seats = TxtSeats.Text;
            Houses = Houses.Where(b => b.name.Contains(houseName) || b.region.Contains(region) || 
            b.coatOfArms.Contains(coatOfArms) || b.words.Contains(words) || b.seats.Contains(seats)).ToList();
        }
    }
}