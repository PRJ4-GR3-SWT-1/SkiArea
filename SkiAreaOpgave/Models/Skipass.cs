using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiAreaOpgave.Models
{
    class Skipass
    {
        public int SkipassId { get; set; }
        public double Price { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public List<Area> AreaList { get; set; }
    }
}
