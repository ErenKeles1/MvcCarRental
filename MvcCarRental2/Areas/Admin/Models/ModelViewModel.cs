using Microsoft.AspNetCore.Mvc.Rendering;
using MvcCarRental2.Web.Domain;
using System.ComponentModel.DataAnnotations;

namespace MvcCarRental2.Web.Areas.Admin.Models
{
    public class ModelViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid BrandId { get; set; }

        [Required]
        public Guid CarTypeId { get; set; }

        public EngineTypes EngineType { get; set; }
    }
}
