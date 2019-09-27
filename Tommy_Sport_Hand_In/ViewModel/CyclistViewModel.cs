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

        public IList<Model.Cyclist> CyclistList;

        public CyclistViewModel()
        {
           
            List<Cyclist> ListOfCyclists = new List<Cyclist>();

            XDocument xDoc = XDocument.Load("Cycling-Tour-De-France.xml");

            //search for cyclist object
            var CyclistObjects = from feed in xDoc.Descendants("participant")
                            //where (string)feed.Attribute("gender") == "male"
                        select new
                        {
                            CyclistName = feed.Attribute("name").Value,
                            CyclistGender = feed.Attribute("gender").Value,
                            CyclistCountryFK = feed.Attribute("countryFK").Value,
                            
                        };

            //search for ResultTime
            var ResultTimeFeeds = from feed in xDoc.Descendants("result")
                                  where (string)feed.Attribute("result_typeFK") == "101"
                                  select new{
                                  ResultTime = feed.Attribute("value").Value};

            //search for EndPosition
            var EndPositionFeeds = from feed in xDoc.Descendants("result")
                                   where (string)feed.Attribute("result_typeFK") == "100"
                                   select new{
                                   EndPosition = feed.Attribute("value").Value};
        }


        public IList<Model.Cyclist> Cyclists
        {
            get { return CyclistList; }
            set { CyclistList = value; }
        }

    }
}
