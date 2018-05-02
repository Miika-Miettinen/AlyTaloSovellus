using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;


namespace AlyTaloSovellus
{
    public class Lights
    {


        public bool Switched { get; set; }
        public String Dimmer { get; set; }
        
        public int SaunaTemperature { get; set; }


        public void täysivalo()
        {
            Switched = true;
            Dimmer = "100";
        }

        public void kaksiKolmasOsa()
        {
            Switched = true;
            Dimmer = "66";
        }

        public void kolmasOsaValot()
        {
            Switched = true;
            Dimmer = "33";
        }



    } }

    
