using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;

namespace WcfService2
{

    public partial class WordAutoComplete : System.Web.UI.Page
    {
        public List<House> HouseList { get; set; }

        public List<string> Words = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {

            string term = Request.QueryString["term"];

            Response.Clear();

            Response.ContentType = "application/json; charset=utf-8";
            using (var webClient = new WebClient())
            {
                string rawData = webClient.DownloadString("https://www.anapioficeandfire.com/api/houses");
                HouseList = JsonConvert.DeserializeObject<List<House>>(rawData);
                foreach (var x in HouseList)
                {
                    Words.Add(x.Words);
                }
            }

            //filtered HouseNames HashSet

            HashSet<string> filteredWords = new HashSet<string>();

            //filtering the words by input

            foreach(string word in Words)
            {
                if(word.ToLower().Contains(term.ToLower())){
                    filteredWords.Add(word);

                }
            }

            string responseJSON = JsonConvert.SerializeObject(filteredWords);

            Response.Write(responseJSON);

            Response.End();
        }


    }
}
