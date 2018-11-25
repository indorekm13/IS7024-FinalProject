using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            //List<string> bookNames = new List<string>();
            foreach (var book in Books)
            {
                htmlStr += "<tr>" +
                    "<td>" + book.name + "</td>" +
                    "<td>" + book.isbn + "</td>" +
                    "<td>" + book.authors.FirstOrDefault() + "</td>" +
                    "<td>" + book.numberOfPages + "</td>" +
                    "<td>" + book.publisher + "</td>" +
                    "<td>" + book.country + "</td>" +
                    "<td>" + book.mediaType + "</td>" +
                    "<td>" + book.released.ToShortDateString() + "</td>" +
                    "</tr>";
            }

            return htmlStr;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var bookName = TxtBookName.Text;
            var publisher = TxtPublisher.Text;
            var isbn = TxtBoxIsbn.Text;
            Books = Books.Where(b => b.name.Contains(bookName)|| b.publisher.Contains(publisher) || b.isbn.Contains(isbn)).ToList();
        }
    }
}