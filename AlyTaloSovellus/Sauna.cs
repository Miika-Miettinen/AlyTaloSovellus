using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlyTaloSovellus
{
    public class Sauna
    {
        

        public bool Switched { get; set; }
        
        public void saunaOn()
        {
            Switched = true;
        }
        
        public void saunaOff()
        {
            Switched = false;
        }

     

      
    }

}
