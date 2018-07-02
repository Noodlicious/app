using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoodleApp.Models
{
    public class Noodle
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
