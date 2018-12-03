using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;

namespace WcfService2
{

    public partial class BookNameAutoComplete : System.Web.UI.Page
    {
        public List<Book> BookList { get; set; }

        public List<string> BookNames = new List<string>();

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
                    BookNames.Add(x.Name);
                }
            }
            //filtered Book List

            List<string> filteredBooks = new List<string>();

            //filtering the Books by input

            foreach (string book in BookNames)
            {
                if (book.ToLower().Contains(term.ToLower()))
                {
                    filteredBooks.Add(book);

                }
            }

            string responseJSON = JsonConvert.SerializeObject(filteredBooks);

            Response.Write(responseJSON);

            Response.End();
        }



    }
}
