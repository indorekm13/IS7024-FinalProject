using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;

namespace WcfService2
{

    public partial class PublisherAutoComplete : System.Web.UI.Page
    {
        public List<Book> BookList { get; set; }

        public List<string> PublisherNames = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string term = Request.QueryString["term"];

            Response.Clear();

            Response.ContentType = "application/json; charset=utf-8";
            using (var webClient = new WebClient())
            {
                string rawData = webClient.DownloadString("https://www.anapioficeandfire.com/api/books");
                BookList = JsonConvert.DeserializeObject<List<Book>>(rawData);
                foreach (var x in BookList)
                {
                    PublisherNames.Add(x.Publisher);
                }
            }
            //filtered Publisher List

            List<string> filteredPublishers = new List<string>();

            //filtering the publishers by input

            foreach (string publisher in PublisherNames)
            {
                if (publisher.Contains(term))
                {
                    filteredPublishers.Add(publisher);

                }
            }
            string responseJSON = JsonConvert.SerializeObject(filteredPublishers);

            Response.Write(responseJSON);

            Response.End();
        }


    }
}
