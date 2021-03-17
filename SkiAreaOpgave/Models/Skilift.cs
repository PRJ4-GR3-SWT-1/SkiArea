using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiAreaOpgave.Models
{
    public class Skilift
    {
        public int SkiliftId { get; set; }
        public string to { get; set; }
        public string from { get; set; }
        public float speed { get; set; }
        public int capacity { get; set; }
        public Area area { get; set; }
    }
}
