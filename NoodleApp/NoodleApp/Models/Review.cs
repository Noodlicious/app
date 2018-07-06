using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoodleApp.Models
{	/// <summary>
/// review model
/// </summary>
    public class Review
    {
		
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
		
		/// <summary>
		/// integer id to link reviews to noodle API primary key
		/// </summary>
		public int NoodleId { get; set; }

    }
}
