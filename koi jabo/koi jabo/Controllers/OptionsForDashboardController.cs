using koi_jabo.Lib.MongoContext;
using koi_jabo_models.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace koi_jabo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OptionsForDashboardController : ApiController
    {

        KoiJaboMongoDataContext context = new KoiJaboMongoDataContext();
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                OptionsForDashBoardEntity options = await context.OptionsForDashBoard.Find(new BsonDocument()).FirstAsync();
                return Json(options);
            }
            catch (Exception e)
            {
                return Json(BadRequest());
            }
            
        }



        [HttpPost]
        public async Task<IHttpActionResult> Post(OptionsForDashboardController value)
        {
            return Json(BadRequest());
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(OptionsForDashboardController value)
        {
            return Json(BadRequest());
        }
    }
}
