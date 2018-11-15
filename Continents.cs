using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContinentPieChart
{
    public class Continents
    {
        public string Continent { get; set; }
        public int Roadways { get; set; }
        public int CountriesNO { get; set; }    
       
    }
    public class Country
    {

        public string CountryName { get; set; }
        public string Capital { get; set; }        
        public string Continent { get; set; }

    }
   
}