using System;
using Hateoas.Attributes;

namespace SampleApi.Models
{
    [Relation("self", Href = "/dogs/{Id}")]
    public class Dog
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        public DateTime Birthdate { get; set; }
    }
}