using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using SL_TechProject.Models;

namespace SL_TechProject.Controllers.api
{ 
    public class DriverController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        public DriverController()
        {
        }

        public IHttpActionResult createNewDriver(driver driver)
        {
            if (!ModelState.IsValid) {
                return BadRequest("Not a valid model");
            }
            
            DAL.storeDriver(driver);

            return Ok();
        }
    }
}
