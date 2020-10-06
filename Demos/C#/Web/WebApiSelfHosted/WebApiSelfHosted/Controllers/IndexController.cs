using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebApiSelfHosted.Controllers
{
    [RoutePrefix("")]
    public class IndexController : ApiController
    {
        [Route]
        public HttpResponseMessage Get()
        {
            var path = "../../index.html";
            var response = new HttpResponseMessage();
            response.Content = new StringContent(File.ReadAllText(path));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}
