using WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Useraip")]
    public class UseraipController : ApiController
    {
        UserRepository ur = new UserRepository();
        // GET: api/Useraip
        [Route("GetUser")]
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult Get()
        {
            var list = ur.getallUserAndRole();
            return Ok(list);
        }

        // GET: api/Useraip/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Useraip
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Useraip/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Useraip/5
        public void Delete(int id)
        {
        }
    }
}
