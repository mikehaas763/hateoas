using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Newtonsoft.Json.Linq;
using SampleApi.Models;
using Hateoas;

namespace SampleApi.Controllers
{
    [RoutePrefix("dogs")]
    public class DogsController : ApiController
    {
        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetDogById(int id)
        {
            // Fake some sample dog data.
            var dogs = new List<Dog>();
            var jax = new Dog()
            {
                Id = 4167,
                Name = "Jax",
                Birthdate = new DateTime(2012, 8, 1),
                Weight = 65
            };
            dogs.Add(jax);

            // fetch the dog with the id specified from the url.
            var requestedDog = dogs.FirstOrDefault(dog => dog.Id == id);

            // There is no dog with that ID.
            if (requestedDog == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // The specialized hateoas serializer.
            var hateoas = new HateoasSerializerBuilder().Build();
            var dogJson = hateoas.Serialize(requestedDog);

            // Until there is a proper content-type negotion interceptor in the 
            // request pipeline, we need to build the response manually with 
            // the serialized json.
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(dogJson, Encoding.UTF8, "application/json");
            return response;
        }
    }
}