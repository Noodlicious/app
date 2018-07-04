using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoodleApp.Models
{
    public class ReviewViewModel
    {
		/// <summary>
		/// review object to pass into model
		/// </summary>
		public Review Review { get; set; }

		/// <summary>
		/// id taken from api data to be used in server database
		/// </summary>
		public int NoodleId { get; set; }

    }
}
