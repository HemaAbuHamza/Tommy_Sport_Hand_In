using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml;
using System.Xml.Linq;
using System.Windows;
using Tommy_Sport_Hand_In.ViewModel;


namespace Tommy_Sport_Hand_In.Model
{
    public class Validator : MainWindow
    {

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
            string fileName = "Cycling-Tour-De-France.xml";
            XElement root = XElement.Load(fileName);
            System.Console.WriteLine("root=" + root.Name);
        }

    }
}
