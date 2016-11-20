using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiIdSrv4withX509
{
    [Route("test")]
    [Authorize]
    public class TestController : ControllerBase
    {
        public string Get()
        {
            return "OK";
        }
    }
}