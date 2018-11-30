using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService2
{
    public class Book
    {
        // JSON Object Data
        private string url;
        private string name;
        private string isbn;
        private List<string> authors;
        private int numberOfPages;
        private string publisher;
        private string country;
        private string mediaType;
        private DateTime released;

        // Getters and Setters
        public string Url { get => url; set => url = value; }
        public string Name { get => name; set => name = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public List<string> Authors { get => authors; set => authors = value; }
        public int NumberOfPages { get => numberOfPages; set => numberOfPages = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public string Country { get => country; set => country = value; }
        public string MediaType { get => mediaType; set => mediaType = value; }
        public DateTime Released { get => released; set => released = value; }
    }
}