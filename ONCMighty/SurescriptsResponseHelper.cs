using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionHeartsAPI
{
    public class SurescriptsResponseHelper
    {
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string crossStreet { get; set; }
        public string description { get; set; }
        public float distance { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public Boolean precise { get; set; }
        public string state { get; set; }
        public string url { get; set; }
        public string urlCaption { get; set; }
        public string zip { get; set; }
        public string addressFull { get; set; }
        public SurescriptsResponseHelper(string address, string city, 
            string description,
            float distance, float lat, float lon, string name, string phone, Boolean precise, string state, string url,
            string urlCaption, string zip, string crossStreet = "", string address2 = "")
        {
            this.address = address;
            this.address2 = address2;
            this.city = city;
            this.crossStreet = crossStreet;
            this.description = description;
            this.distance = distance;
            this.lat = lat;
            this.lon = lon;
            this.name = name;
            this.phone = phone;
            this.precise = precise;
            this.state = state;
            this.url = url;
            this.urlCaption = urlCaption;
            string zipformatted = zip.Remove(5, 4);
            this.zip = zipformatted;
            if (address2 == "")
            {
                this.addressFull = address + " " + address2 + ", " + city + ", " + state + " " + zipformatted;
            }
            else
            {
                this.addressFull = address + ", " + city + ", " + state + " " + zipformatted;
            }
           
        }

    }
}
