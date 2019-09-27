using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Tommy_Sport_Hand_In.Model
{
    public class Validator
    {
        public List<Cyclist> cyclistList = new List<Cyclist>();
        public static void Validators()
        {
            string fileName = "Cycling-Tour-De-France.xml";
            XmlReaderSettings settings = new XmlReaderSettings();

            settings.XmlResolver = new XmlUrlResolver();

            settings.ValidationType = ValidationType.DTD;
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(ValidationCallBack);
            settings.IgnoreWhitespace = true;

            XmlReader reader = XmlReader.Create(fileName, settings);

            // Parse the file.
            while (reader.Read())
            {
                System.Console.WriteLine("{0}, {1}: {2} ", reader.NodeType, reader.Name, reader.Value);
            }
        }

        private static void ValidationCallBack(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            if (e.Severity == System.Xml.Schema.XmlSeverityType.Warning)
                Console.WriteLine("Warning: Matching schema not found.  No validation occurred." + e.Message);
            else // Error
                Console.WriteLine("Validation error: " + e.Message);
        }


        public static void Parser()
        {
            List<Cyclist> cyclistList = new List<Cyclist>();
            string fileName = "Cycling-Tour-De-France.xml";
            XElement root = XElement.Load(fileName);
            System.Console.WriteLine("root=" + root.Name);

            XDocument xDoc = XDocument.Load("Cycling-Tour-De-France.xml");
            var feeds = from feed in xDoc.Descendants("participant")
                            //where (string)feed.Attribute("gender") == "male"
                        select new
                        {
                            CyclistName = feed.Attribute("name").Value,
                            CyclistGender = feed.Attribute("gender").Value,
                            CyclistType = feed.Attribute("type").Value,
                            CyclistCountryFK = feed.Attribute("countryFK").Value,
                            CyclistEnetID = feed.Attribute("enetID").Value,
                            CyclistenEtSportID = feed.Attribute("enetSportID").Value,
                            CyclistDel = feed.Attribute("del").Value,
                            CyclistN = feed.Attribute("n").Value,
                            CyclistUt = feed.Attribute("ut").Value,
                            CyclistID = feed.Attribute("id").Value
                        };

            foreach (var item in feeds)
            {
                cyclistList.Add(new Cyclist()
                {
                    Name = item.CyclistName,
                    Gender = item.CyclistGender,
                    Country = item.CyclistCountryFK,
                });

                //Console.WriteLine(item);
            }

            foreach (var item in cyclistList)
            {
                Console.WriteLine(item.Name);
            }
        }
        public List<Cyclist> CyclistList
        {
            get { return cyclistList; }
            set { cyclistList = value; }
        }
    }
}