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
    public partial class books : System.Web.UI.Page
    {
        public List<Book> Books { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var webClient = new WebClient())
            {
                string rawData = webClient.DownloadString("https://www.anapioficeandfire.com/api/books");
                Books = JsonConvert.DeserializeObject<List<Book>>(rawData);
            }
        }

        public string GetTableData()
        {
            string htmlStr = "";
            foreach (var book in Books)
            {
                if (string.IsNullOrEmpty(book.name))
                {
                    book.name = "Not Available";
                }
                if (string.IsNullOrEmpty(book.isbn))
                {
                    book.isbn = "Not Available";
                }
                if (string.IsNullOrEmpty(book.country))
                {
                    book.country = "Not Available";
                }
                if (string.IsNullOrEmpty(book.mediaType))
                {
                    book.mediaType = "Not Available";
                }
                htmlStr += "<tr>" +
                    "<td>" + book.name + "</td>" +
                    "<td>" + book.isbn + "</td>" +
                    "<td>" + GetAuthorsList(book.authors) + "</td>" +
                    "<td>" + book.numberOfPages + "</td>" +
                    "<td>" + book.publisher + "</td>" +
                    "<td>" + book.country + "</td>" +
                    "<td>" + book.mediaType + "</td>" +
                    "<td>" + book.released.ToShortDateString() + "</td>" +
                    "</tr>";
            }

            return htmlStr;
        }

        private string GetAuthorsList(List<string> list)
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
            var bookName = TxtBookName.Text.ToLower();
            var publisher = TxtPublisher.Text.ToLower();
            var isbn = TxtIsbn.Text.ToLower();

            Books = Books.Where(b => (b.name.ToLower().Contains(bookName) && b.publisher.ToLower().Contains(publisher)
             && b.isbn.ToLower().Contains(isbn))).ToList();
        }
    }
}