using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService2
{
    public class House
    {
        private string url;
        private string name;
        private string region;
        private string coatOfArms;
        private string words;
        private List<string> titles;
        private List<string> seats;
        private string currentLord;
        private string heir;
        private string overlord;
        private string founded;
        private string founder;
        private string diedOut;
        private List<string> ancestralWeapons;
        private List<object> cadetBranches;
        private List<object> swornMembers;

        public string Url { get => url; set => url = value; }
        public string Name { get => name; set => name = value; }
        public string Region { get => region; set => region = value; }
        public string CoatOfArms { get => coatOfArms; set => coatOfArms = value; }
        public string Words { get => words; set => words = value; }
        public List<string> Titles { get => titles; set => titles = value; }
        public List<string> Seats { get => seats; set => seats = value; }
        public string CurrentLord { get => currentLord; set => currentLord = value; }
        public string Heir { get => heir; set => heir = value; }
        public string Overlord { get => overlord; set => overlord = value; }
        public string Founded { get => founded; set => founded = value; }
        public string Founder { get => founder; set => founder = value; }
        public string DiedOut { get => diedOut; set => diedOut = value; }
        public List<string> AncestralWeapons { get => ancestralWeapons; set => ancestralWeapons = value; }
        public List<object> CadetBranches { get => cadetBranches; set => cadetBranches = value; }
        public List<object> SwornMembers { get => swornMembers; set => swornMembers = value; }
    }
}