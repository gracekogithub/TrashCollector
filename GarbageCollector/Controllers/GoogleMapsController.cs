using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using static GarbageCollector.Models.GoogleMap;

namespace GarbageCollector.Controllers
{
    //HttpClient
    //Google Maps API (both JavaScript + Geolocating)
    //JsonDeserialization
    public class GoogleMapsController : Controller
    {
        public ActionResult Index()
        {
            string markers = "[";
            string conString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Locations");
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        markers += "{";
                        markers += string.Format("'title': '{0}',", sdr["Name"]);
                        markers += string.Format("'lat': '{0}',", sdr["Latitude"]);
                        markers += string.Format("'lng': '{0}',", sdr["Longitude"]);
                        markers += string.Format("'description': '{0}'", sdr["Description"]);
                        markers += "},";
                    }
                }
                con.Close();
            }

            markers += "];";
            ViewBag.Markers = markers;
            return View();
        }
    }
}

