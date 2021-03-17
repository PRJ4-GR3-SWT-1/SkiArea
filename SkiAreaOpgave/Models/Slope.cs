using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiAreaOpgave.Models
{
    public class Slope
    {
        public string Name { get; set; }
        public string SlopeCat { get; set; } 
        public bool Primed { get; set; }

        public List<Area> Areas { get; set; }



    }
}
