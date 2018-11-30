using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService2
{
    public class House
    {
        // Variables for JSON Object of House  
        private string url;
        private string name;
        private string region;
        private string coatOfArms;
        private string words;
        private List<string> seats;

        // Getters and Setters
        public string Url { get => url; set => url = value; }
        public string Name { get => name; set => name = value; }
        public string Region { get => region; set => region = value; }
        public string CoatOfArms { get => coatOfArms; set => coatOfArms = value; }
        public string Words { get => words; set => words = value; }
        public List<string> Seats { get => seats; set => seats = value; }
    }
}