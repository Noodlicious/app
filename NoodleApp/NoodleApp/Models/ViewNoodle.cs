using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoodleApp.Models
{	/// <summary>
/// model with nullable integer types to send to database
/// </summary>
    public class ViewNoodle
    {
        public int? Id { get; set; }

        public string Name { get; set; }
        public int? BrandId { get; set; }
        public string Flavor { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
    }
}