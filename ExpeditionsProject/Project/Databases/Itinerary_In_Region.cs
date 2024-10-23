using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Databases
{
    public class Itinerary_In_Region
    {
        public int ID_IIR { get; set; }
        public int FK_Itinerary { get; set; }
        public int FK_Region { get; set; }

    }
}
