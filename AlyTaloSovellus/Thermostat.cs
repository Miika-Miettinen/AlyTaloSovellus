using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace AlyTaloSovellus
{
    public class Thermostat
    {
        
        
        public int Temperature { get; set; }

        


        public void LampoSaato(int uusiLampoTila)
        {
            Temperature = uusiLampoTila;
        }




    }
}
