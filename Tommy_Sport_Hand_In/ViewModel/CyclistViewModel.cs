using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tommy_Sport_Hand_In.Model;

namespace Tommy_Sport_Hand_In.ViewModel
{
    class CyclistViewModel
    {

        private IList<Model.Cyclist> CyclistList;
        public CyclistViewModel()
        {
            string fileName = "Cycling-Tour-De-France.xml";
            XElement root = XElement.Load(fileName);
            System.Console.WriteLine("root=" + root.Name);


            List<Cyclist> cyclistList = new List<Cyclist>();

            XDocument xDoc = XDocument.Load("Cycling-Tour-De-France.xml");

            var CyclistObjects = from feed in xDoc.Descendants("participant")
                            //where (string)feed.Attribute("gender") == "male"
                        select new
                        {
                            CyclistName = feed.Attribute("name").Value,
                            CyclistGender = feed.Attribute("gender").Value,
                            CyclistCountryFK = feed.Attribute("countryFK").Value,
                            
                        };


            var ResultTimeFeeds = from feed in xDoc.Descendants("result")
                                  where (string)feed.Attribute("result_typeFK") == "101"
                                  select new{
                                  ResultTime = feed.Attribute("value").Value};

            var EndPositionFeeds = from feed in xDoc.Descendants("result")
                                   where (string)feed.Attribute("result_typeFK") == "100"
                                   select new{
                                   EndPosition = feed.Attribute("value").Value};

            //Create the Cyclist list 
            CyclistList = new List<Model.Cyclist>();

            foreach (var item in CyclistObjects)
            {
                CyclistList.Add(new Model.Cyclist { Name = item.CyclistName, Gender = item.CyclistGender, Country = item.CyclistCountryFK });  
            }



        }
        public IList<Model.Cyclist> Cyclists
        {
            get { return CyclistList; }
            set { CyclistList = value; }
        }

    }
}
