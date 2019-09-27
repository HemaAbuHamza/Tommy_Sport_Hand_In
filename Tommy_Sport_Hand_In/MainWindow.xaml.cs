using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tommy_Sport_Hand_In.Model;
using Tommy_Sport_Hand_In.ViewModel;
using System.Xml.Linq;
using System.Collections;

namespace Tommy_Sport_Hand_In
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Just checking where to place the XML document!!
            string path = Directory.GetCurrentDirectory();
            System.Console.WriteLine("path=" + path);
            Validator.Validators();
            Validator.Parser();
            Console.ReadLine();





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



            List<Cyclist> cyclisTitems = new List<Cyclist>();
            List<ResultTime> resItems = new List<ResultTime>();
            List<EndPosition> endItems = new List<EndPosition>();



            foreach (var item in CyclistObjects)
            {
                cyclisTitems.Add(new Cyclist() { name = item.CyclistName, gender = item.CyclistGender, country = item.CyclistCountryFK });
            }

            
            foreach (var item in ResultTimeFeeds)
            {
                resItems.Add(new ResultTime() {resultTime = item.ResultTime }) ;
            }

            foreach (var item in EndPositionFeeds)
            {
                endItems.Add(new EndPosition() {endPosition = Int32.Parse(item.EndPosition)  });
            }

            lvDataBinding.ItemsSource = cyclisTitems;
            lvDataBinding2.ItemsSource = resItems;
            lvDataBinding3.ItemsSource = endItems;



        }
    }
}
