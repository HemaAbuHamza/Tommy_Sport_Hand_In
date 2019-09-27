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
    public class CyclistViewModel : MainWindow
    {

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

            List<Cyclist> items = new List<Cyclist>();
            //items.Add(new Cyclist() { name ="ayham", gender = "male",country = "syria" , resultTime = "100", endPosition=2 });
            //lvDataBinding.ItemsSource = items;
        }
        
    }
}
