using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContinentPieChart
{
    

    public class ASIA
    {
        public string CountryName { get; set; }
        public string Capital { get; set; }

        public static implicit operator List<object>(ASIA v)
        {
            throw new NotImplementedException();
        }
    }

    public class AFRICA
    {
        public string CountryName { get; set; }
        public string Capital { get; set; }
    }

    public class NORTHAMERICA
    {
        public string CountryName { get; set; }
        public string Capital { get; set; }
    }

    public class SOUTHAMERICA
    {
        public string CountryName { get; set; }
        public string Capital { get; set; }
    }

    public class EUROPE
    {
        public string CountryName { get; set; }
        public string Capital { get; set; }
    }

    public class AUSTRALIA
    {
        public string CountryName { get; set; }
        public string Capital { get; set; }
    }

    public class RootObjects
    {
        public List<ASIA> ASIA { get; set; }
        public List<AFRICA> AFRICA { get; set; }
        public List<NORTHAMERICA> NORTHAMERICA { get; set; }
        public List<SOUTHAMERICA> SOUTHAMERICA { get; set; }
        public List<object> ANTARCTICA { get; set; }
        public List<EUROPE> EUROPE { get; set; }
        public List<AUSTRALIA> AUSTRALIA { get; set; }
    }

}