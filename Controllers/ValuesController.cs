﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebAPIDemo.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        static List<string> strings = new List<string>()
        {
            "value0", "value1", "value2"
        };

        /// <summary>
        /// Get All the Values
        /// </summary>
        /// <remarks>
        /// Get All the String Values
        /// </remarks>
        /// <returns></returns>

        // GET api/values
        public IEnumerable<string> Get()
        {
            //return new string[] { "value1", "value2" };
            return strings;
        }

        // GET api/values/5
        /*public string Get(int id)
        {
            return "value";
        }*/
        public string Get(int id)
        {
            return strings[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            strings.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            strings[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            strings.RemoveAt(id);
        }
    }
}
