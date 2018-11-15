using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace ContinentPieChart
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Continents> listcountinent = new List<Continents>();
            string CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Continent, Roadways, CountriesNO from Continents", con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr != null)
                    {
                        while (rdr.Read())
                        {
                            Continents continents = new Continents();
                            continents.Continent = rdr["Continent"].ToString();
                            continents.Roadways = Convert.ToInt32(rdr["Roadways"]);
                            continents.CountriesNO = Convert.ToInt32(rdr["CountriesNO"]);
                            listcountinent.Add(continents);
                        }
                    }
                }


                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string jsonString = javaScriptSerializer.Serialize(listcountinent);
                Response.Write(jsonString);
                System.IO.File.WriteAllText(@"D:\documents\C# Programs\ContinentPieChart\Continentes.json", jsonString);
            }

            
        }
    }
}