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
    public partial class Books : System.Web.UI.Page
    {
        // List of Object Book
        public List<Book> BookList { get; set; }

        // Gets the JSON of Books on Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var webClient = new WebClient())
            {
                string rawData = webClient.DownloadString("https://www.anapioficeandfire.com/api/books");
                BookList = JsonConvert.DeserializeObject<List<Book>>(rawData);
            }
        }

        // Displays JSON of Books in table format
        public string GetTableData()
        {
            string htmlStr = "";
            if (BookList.Any())
            {
                foreach (var book in BookList)
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
            }
            else
            {
                htmlStr = "<tr> <td colspan=8> No Data Found </td></tr>";
            }
            return htmlStr;
        }

        // Gets the list of Authors in form of List within the table cell
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

        // Filters books data according to the filters on click of Submit button
        protected void ButtonSubmitClick(object sender, EventArgs e)
        {
            var bookName = TxtBookName.Text.ToLower();
            var publisher = TxtPublisher.Text.ToLower();
            var isbn = TxtIsbn.Text.ToLower();

            BookList = BookList.Where(b => (b.Name.ToLower().Contains(bookName) && 
            b.Publisher.ToLower().Contains(publisher) &&
            b.Isbn.ToLower().Contains(isbn))).ToList();
        }
    }
}