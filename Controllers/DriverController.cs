using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SL_TechProject.Models;
using System.Net.Http;

namespace SL_TechProject.Controllers
{
    public class DriverController : Controller
    {

        ServiceRepo serviceRepo = new ServiceRepo();

        // GET: Driver
        public ActionResult DriverForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertDriver(driver driver) {

            ViewBag.Submitted = false;
            var created = false;
            // Create the Client
            if (HttpContext.Request.RequestType == "POST")
            {
                ViewBag.Submitted = true;
                HttpResponseMessage response = serviceRepo.PostAction(driver, "api/driver/createNewDriver");
                // Denote that the client was created
                created = true;
                response.EnsureSuccessStatusCode();
            }
            
            if (created)
            {
                ViewBag.Message = "Client was created successfully.";
            }
            else
            {
                ViewBag.Message = "There was an error while creating the client.";
            }
            return View("../Driver/DriverForm");

        }
    }
}
