using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingPalServ.Models;

namespace ParkingPalServ.Controllers
{
    public class DataController : Controller
    {
        public void Index()
        {
            Response.Write("<h1>Waiting for ParkingPal Data...</h1>");
        }
        public void Details()
        {
            DataRepository dr = new DataRepository();
            data d = dr.GetData(1);
            Response.Write("<h1>ParkingPal Data</h1>");
            Response.Write("<h2>Total: " + d.Total + "</h2>");
            Response.Write("<h2>Open: " + d.Open + "</h2>");
            Response.Write("<h2>Open Handicapped: " + d.OpenH + "</h2>");
            Response.Write("<h2>Occupied: " + d.Occupied + "</h2>");
            Response.Write("<h2>Occupied Handicapped: " + d.OccupiedH + "</h2>");
            Response.Write("</br><h3>Date/Time Updated: " + d.RecordedDate + " ET</h3>");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateData()
        {
            string t = Request.Form["total"].ToString();
            string o = Request.Form["open"].ToString();
            string oh = Request.Form["handicapped"].ToString();
            string occ = Request.Form["occupied"].ToString();
            string occh = Request.Form["handicappedo"].ToString();

            DataRepository dr = new DataRepository();

            data du = new data();
            du.Total = t;
            du.Open = o;
            du.OpenH = oh;
            du.Occupied = occ;
            du.OccupiedH = occh;
            du.RecordedDate = DateTime.Now.AddHours(-5);

            dr.Update(du);

            try
            {
                dr.Save();
            }
            catch
            {
                var errors = du.GetRuleViolations();
            }

            return RedirectToAction("Details");
        }
        public data getData()
        {
            DataRepository dr = new DataRepository();
            data d = dr.GetData(1);

            return d;
        }
    }
}