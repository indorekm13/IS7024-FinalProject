using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService2
{
    public class Book
    {
        private string url;
        private string name;
        private string isbn;
        private List<string> authors;
        private int numberOfPages;
        private string publisher;
        private string country;
        private string mediaType;
        private DateTime released;
        private List<string> characters;
        private List<string> povCharacters;

        public string Url { get => url; set => url = value; }
        public string Name { get => name; set => name = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public List<string> Authors { get => authors; set => authors = value; }
        public int NumberOfPages { get => numberOfPages; set => numberOfPages = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public string Country { get => country; set => country = value; }
        public string MediaType { get => mediaType; set => mediaType = value; }
        public DateTime Released { get => released; set => released = value; }
        public List<string> Characters { get => characters; set => characters = value; }
        public List<string> PovCharacters { get => povCharacters; set => povCharacters = value; }
    }
}