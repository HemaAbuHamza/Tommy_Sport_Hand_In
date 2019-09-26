using System;
using System.Collections.Generic;
using System.IO;
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
        }
    }
}
