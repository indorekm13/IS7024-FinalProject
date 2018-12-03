using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;

namespace WcfService2
{

    public partial class ISBNAutoComplete : System.Web.UI.Page
    {
        public List<Book> BookList { get; set; }

        public List<string> ISBNs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Clear();

            Response.ContentType = "application/json; charset=utf-8";
            using (var webClient = new WebClient())
            {
                string rawData = webClient.DownloadString("https://www.anapioficeandfire.com/api/books");
                BookList = JsonConvert.DeserializeObject<List<Book>>(rawData);
                foreach (var x in BookList)
                {
                    ISBNs.Add(x.Isbn);
                }
            }
            string responseJSON = JsonConvert.SerializeObject(ISBNs);

            Response.Write(responseJSON);

            Response.End();
        }
    }
}
