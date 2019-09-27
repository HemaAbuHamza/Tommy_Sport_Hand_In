using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tommy_Sport_Hand_In.Model;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace Tommy_Sport_Hand_In.ViewModel
{
    class CyclistViewModel
    {

        private IList<Cyclist> CyclistList { get; set; }

        public CyclistViewModel()
        {
            string fileName = "Cycling-Tour-De-France.xml";
            XElement root = XElement.Load(fileName);
            System.Console.WriteLine("root=" + root.Name);

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
                                  select new
                                  {
                                      ResultTime = feed.Attribute("value").Value
                                  };

            var EndPositionFeeds = from feed in xDoc.Descendants("result")
                                   where (string)feed.Attribute("result_typeFK") == "100"
                                   select new
                                   {
                                       EndPosition = feed.Attribute("value").Value
                                   };

            List<Cyclist> ListOfCyclists = new List<Cyclist>();
            List<Cyclist> CyclistList = new List<Cyclist>();

            foreach (var item in CyclistObjects)
            {
                ListOfCyclists.Add(new Cyclist()
                {
                    Name = item.CyclistName,
                    Gender = item.CyclistGender,
                    Country = item.CyclistCountryFK,

                });
            }

            List<string> ResultList = new List<string>();
            foreach (var item in ResultTimeFeeds)
            {
                ResultList.Add(item.ResultTime);
            }

            List<int> EndPosList = new List<int>();
            foreach (var item in EndPositionFeeds)
            {
                EndPosList.Add(Int32.Parse(item.EndPosition));
            }



            for (int i = 0; i < ListOfCyclists.Count; i++)
            {
                Model.Cyclist NewCyclist = (new Model.Cyclist { Name = ListOfCyclists[i].Name, Gender = ListOfCyclists[i].Gender, Country = ListOfCyclists[i].Country, ResultTime = ResultList[i], EndPosition = EndPosList[i] });
                CyclistList.Add(new Cyclist() { Name = ListOfCyclists[i].Name, Gender = ListOfCyclists[i].Gender, Country = ListOfCyclists[i].Country, ResultTime = ResultList[i], EndPosition = EndPosList[i] });
            }

            //Create the Cyclist list 
            //foreach (var item in ListOfCyclists)
            //{
            //    CyclistList.Add(new Model.Cyclist { Name = item.Name, Gender = item.Gender, Country = item.Country , ResultTime = item.ResultTime , EndPosition = item.EndPosition });  
            //}



        }
        public IList<Cyclist> Cyclists
        {
            get { return CyclistList; }
            set { CyclistList = value; }
        }
    }
}
