using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cstr = System.Configuration.ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cstr))
            {
                SqlCommand cmd = new SqlCommand("select top 8 * from Customers;");
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Web = await AccessWebAsync();
            return View();
        }

        private async Task<string> AccessWebAsync()
        {
            HttpClient c = new HttpClient();
            Task<string> content = c.GetStringAsync("http://www.quora.com");
            string web = await content;
            return web;
        }
    }
}