using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiAreaOpgave.Models
{
    public class Area
    {
        public string Name { get; set; }

        public List<Slope> Slopes { get; set; }
        public List<Skilift> Skilifts { get; set; }
        public List<Skipass> Skipasses { get; set; }


    }
}
