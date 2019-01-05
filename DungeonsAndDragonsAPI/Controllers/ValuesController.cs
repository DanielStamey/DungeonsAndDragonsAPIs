using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonsAndDragonsAPIs.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace DungeonsAndDragonsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            MongoDbService mongoService = new MongoDbService();
            List<BsonDocument> mongoData = mongoService.GetAllCollection();
            //var student1 = new BsonDocument
            //{
            //  {"firstname", "Ugo"},
            //  {"lastname", "Damian"},
            //  {"subjects", new BsonArray {"English", "Mathematics", "Physics", "Biology"}},
            //  {"class", "JSS 3"},
            //  {"age", 23}
            //};

            //var student2 = new BsonDocument
            //{
            //  {"firstname", "Julie"},
            //  {"lastname", "Lerman"},
            //  {"subjects", new BsonArray {"English", "Mathematics", "Spanish"}},
            //  {"class", "JSS 3"},
            //  {"age", 23}
            //};

            //var student3 = new BsonDocument
            //{
            //  {"firstname", "Julie"},
            //  {"lastname", "Lerman"},
            //  {"subjects", new BsonArray {"English", "Mathematics", "Physics", "Chemistry"}},
            //  {"class", "JSS 1"},
            //  {"age", 25}
            //};
            //List<BsonDocument> temps = new List<BsonDocument>();
            //temps.Add(student1);
            //temps.Add(student2);
            //temps.Add(student3);
            //mongoService.AddDocuments(temps, "Test");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
