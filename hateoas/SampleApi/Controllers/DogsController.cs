using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using SampleApi.Models;
using Hateoas;

namespace SampleApi.Controllers
{
    [RoutePrefix("dogs")]
    public class DogsController : ApiController
    {
        [HttpGet]
        [Route("{id:int}")]
        public HalBuilder<Dog> GetDogById(int id)
        {
            var dogs = new List<Dog>();
            var jax = new Dog()
            {
                Id = 4167,
                Name = "Jax",
                Birthdate = new DateTime(2012, 8, 1),
                Weight = 65
            };
            dogs.Add(jax);

            var requestedDog = dogs.FirstOrDefault(dog => dog.Id == id);
            if (requestedDog == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return new HalBuilder<Dog>().Build(requestedDog);
        }
    }
}