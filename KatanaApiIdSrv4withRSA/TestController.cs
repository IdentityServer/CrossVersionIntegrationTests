using System.Web.Http;

namespace KatanaApi
{
    [Route("test")]
    [Authorize]
    public class TestController : ApiController
    {
        public string Get()
        {
            return "OK";
        }
    }
}