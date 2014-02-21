using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WeixinWebApi.Controllers
{
    public class TestController : ApiController
    {
        // GET api/default1
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/default1/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/default1
        public void Post([FromBody]string value)
        {
            var context = (HttpContextBase)Request.Properties["MS_HttpContext"];
        }

        //// PUT api/default1/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/default1/5
        //public void Delete(int id)
        //{
        //}
    }
}
