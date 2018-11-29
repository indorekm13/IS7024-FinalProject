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
                if (string.IsNullOrEmpty(book.Name))
                {
                    book.Name = "Not Available";
                }
                if (string.IsNullOrEmpty(book.Isbn))
                {
                    book.Isbn = "Not Available";
                }
                if (string.IsNullOrEmpty(book.Country))
                {
                    book.Country = "Not Available";
                }
                if (string.IsNullOrEmpty(book.MediaType))
                {
                    book.MediaType = "Not Available";
                }
                htmlStr += "<tr>" +
                    "<td>" + book.Name + "</td>" +
                    "<td>" + book.Isbn + "</td>" +
                    "<td>" + GetAuthorsList(book.Authors) + "</td>" +
                    "<td>" + book.NumberOfPages + "</td>" +
                    "<td>" + book.Publisher + "</td>" +
                    "<td>" + book.Country + "</td>" +
                    "<td>" + book.MediaType + "</td>" +
                    "<td>" + book.Released.ToShortDateString() + "</td>" +
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

            if (!string.IsNullOrEmpty(bookName))
            {
                Books = Books.Where(b => b.Name.ToLower().Contains(bookName)).ToList();
            }
            if (!string.IsNullOrEmpty(publisher))
            {
                Books.AddRange(Books.Where(b => b.Publisher.ToLower().Contains(publisher)).ToList());
            }
            if (!string.IsNullOrEmpty(isbn))
            {
                Books.AddRange(Books.Where(b => b.Isbn.ToLower().Contains(isbn)).ToList());
            }
        }
    }
}