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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                RootObjects rootobject = new RootObjects();
                string CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                string query = "Select CountryName, Capital from ASIA;";
                query += "Select CountryName, Capital from AFRICA;";
                query += "Select CountryName, Capital from NORTHAMERICA;";
                query += "Select CountryName, Capital from SOUTHAMERICA;";
                query += "Select CountryName, Capital from EUROPE;";
                query += "Select CountryName, Capital from AUSTRALIA";

                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            rootobject.ASIA = new List<ASIA>();
                            rootobject.AFRICA = new List<AFRICA>();
                            rootobject.NORTHAMERICA = new List<NORTHAMERICA>();
                            rootobject.SOUTHAMERICA = new List<SOUTHAMERICA>();
                            rootobject.EUROPE = new List<EUROPE>();
                            rootobject.AUSTRALIA = new List<AUSTRALIA>();

                            sda.SelectCommand = cmd;

                            using (DataSet ds = new DataSet())
                            {
                                sda.Fill(ds);                                
                                
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    ASIA asia = new ASIA();
                                    asia.CountryName = dr["CountryName"].ToString();
                                    asia.Capital = dr["Capital"].ToString();
                                    rootobject.ASIA.Add(asia);                                    
                                }
                                
                                foreach (DataRow dr in ds.Tables[1].Rows)
                                {
                                    AFRICA africa = new AFRICA();
                                    africa.CountryName = dr["CountryName"].ToString();
                                    africa.Capital = dr["Capital"].ToString();
                                    rootobject.AFRICA.Add(africa);
                                }

                                foreach (DataRow dr in ds.Tables[2].Rows)
                                {
                                    NORTHAMERICA northamerica = new NORTHAMERICA();
                                    northamerica.CountryName = dr["CountryName"].ToString();
                                    northamerica.Capital = dr["Capital"].ToString();
                                    rootobject.NORTHAMERICA.Add(northamerica);
                                }
                                foreach (DataRow dr in ds.Tables[3].Rows)
                                {
                                    SOUTHAMERICA southamerica = new SOUTHAMERICA();
                                    southamerica.CountryName = dr["CountryName"].ToString();
                                    southamerica.Capital = dr["Capital"].ToString();
                                    rootobject.SOUTHAMERICA.Add(southamerica);
                                }
                                foreach (DataRow dr in ds.Tables[4].Rows)
                                {
                                    EUROPE europe = new EUROPE();
                                    europe.CountryName = dr["CountryName"].ToString();
                                    europe.Capital = dr["Capital"].ToString();
                                    rootobject.EUROPE.Add(europe);
                                }
                                foreach (DataRow dr in ds.Tables[5].Rows)
                                {
                                    AUSTRALIA australia = new AUSTRALIA();
                                    australia.CountryName = dr["CountryName"].ToString();
                                    australia.Capital = dr["Capital"].ToString();
                                    rootobject.AUSTRALIA.Add(australia);
                                }
                            }                                                    
                    }
                    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    string jsonString = javaScriptSerializer.Serialize(rootobject);
                    Response.Write(jsonString);
                    //System.IO.File.WriteAllText(@"D:\documents\C# Programs\ContinentPieChart\Country.json", jsonString);
                }

        }
        }
    }
}