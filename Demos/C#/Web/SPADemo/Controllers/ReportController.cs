using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcRazor.Controllers
{
    public class ReportController : ApiController
    {
        // GET api/report
        public string Get()
        {
            return "value";
        }

        // GET api/report/index
        public string[] Get(string id)
        {
            switch(id)
            {
                case "index":
                    return new string[] { "In this demo is illustrated how to add WebReport to Single Page Application", "","","","" };
                case "report":
                    return new string[] { Url.Link("Default", new { controller = "Home", action = "Report" }) };
                case "designer":
                    return new string[] { Url.Link("Default", new { controller = "Home", action = "Designer" }) };
                case "about":
                    return new string[] { "This is another page of Single Page Application", "About...", "", "", "" };
            }
            return null;
        }

        // POST api/report
        public void Post([FromBody]string value)
        {
        }

        // PUT api/report/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/report/5
        public void Delete(int id)
        {
        }
    }
}
