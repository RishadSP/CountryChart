using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContinentPieChart
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string query = "Select CountryName, Capital, Continent from Country inner join Continents on Country.ContinentID= Continents.ID";
            List<Country> listcountinent = new List<Country>();
            
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        sda.SelectCommand = cmd;

                        using (DataSet ds = new DataSet())
                        {                                                        
                            sda.Fill(ds);
                            int count = ds.Tables.Count;

                            for (int i = 0; i < count; i++)
                            {
                                foreach (DataRow dr in ds.Tables[i].Rows)
                                {
                                    var dict = new Dictionary<string, object>();
                                    Country country = new Country();
                                    Continents continents = new Continents();
                                    string jsonname = Convert.ToString(ds);
                                    
                                    foreach (DataColumn col in ds.Tables[i].Columns)
                                    {
                                        country.CountryName = dr["CountryName"].ToString();
                                        country.Capital = dr["Capital"].ToString();
                                        country.Continent = dr["Continent"].ToString();
                                    }
                                    //Response.Write(jsonname);
                                    listcountinent.Add(country);                                                                        
                                }
                            }
                        }
                    }
                }
            }

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string jsonString = javaScriptSerializer.Serialize(listcountinent);
                Response.Write(jsonString);
                System.IO.File.WriteAllText(@"D:\documents\C# Programs\ContinentPieChart\Count.json", jsonString);
        }
    }
    }
