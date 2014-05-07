using System.Web.Http;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    [RoutePrefix("dogs")]
    public class DogsController : ApiController
    {
        [HttpGet]
        [Route("{id:int}")]
        public Dog GetDogById(int id)
        {
            return new Dog() {Name = "Jax"};
        }
    }
}