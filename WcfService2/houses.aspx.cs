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
    public partial class Houses : System.Web.UI.Page
    {
        // List of Object House to store Details of House JSON
        public List<House> HouseList { get; set; }

        // Gets JSON data of House(Royal Families) on Page load
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var webClient = new WebClient())
            {
                string rawData = webClient.DownloadString("https://www.anapioficeandfire.com/api/houses");
                HouseList = JsonConvert.DeserializeObject<List<House>>(rawData);
            }
        }

        // Displays the details on House Data in form of table
        public string GetTableData()
        {
            string htmlStr = "";
            if (HouseList.Any())
            {
                foreach (var house in HouseList)
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
            }
            else
            {
                htmlStr = "<tr> <td colspan=8> No Data Found </td></tr>";
            }

            return htmlStr;
        }

        // Displays list of Seats within the table cell
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

        // Filters the House Data based upon the search criteria on click of Submit button
        protected void ButtonSubmitClick(object sender, EventArgs e)
        {
            var houseName = TxtHouseName.Text.ToLower();
            var region = TxtRegion.Text.ToLower();
            var coatOfArms = TxtCoatOfArms.Text.ToLower();
            var words = TxtWords.Text.ToLower();

            HouseList = HouseList.Where(h => (h.Name.ToLower().Contains(houseName) && h.Region.ToLower().Contains(region)
            && h.CoatOfArms.ToLower().Contains(coatOfArms) && h.Words.ToLower().Contains(words))).ToList();
        }
    }
}