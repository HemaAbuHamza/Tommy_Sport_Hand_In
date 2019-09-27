using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace Tommy_Sport_Hand_In.ViewModel
{
    class CyclistViewModel
    {
        private IList<Model.Cyclist> CyclistList; 
        public CyclistViewModel()
        {
          CyclistList = new List<Model.Cyclist>
          {
              new Model.Cyclist{Name = "Jane Dane", Gender = "Female", Country = "Germany", ResultTime = "1:02:56", EndPosition = 1},
              new Model.Cyclist{Name = "Frank West", Gender = "Male", Country = "Denmark", ResultTime = "+0.04", EndPosition = 2}
          };
       }
        public IList<Model.Cyclist> Cyclists
        {
            get { return CyclistList; }
            set { CyclistList = value; }
        }
    }
}
