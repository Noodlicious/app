using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoodleApp.Models
{
	public class Noodle
	{
		
		/// <summary>
		/// nullable integer id, set to nullable in order to allow override from API database primary key
		/// </summary>
		public int? Id { get; set; }

		[Required]
		public string Name { get; set; }
		public int BrandId { get; set; }
		public string Flavor { get; set; }
		public string ImgUrl { get; set; }
		public string Description { get; set; }
		public int Likes { get; set; }
		public int Dislikes { get; set; }

    }
}
