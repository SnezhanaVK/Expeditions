using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Databases
{
    public class Point_In_Itinerary
    {
        public int ID_PII { get; set; }
        public int FK_Itinerary { get; set; }
        public int FK_Point { get; set; }
        public int FK_TypePoint { get; set; }
        public string DateArrivalsPoint { get; set; }
        public string TimeArrivalsPoint { get; set; }
        public string DaysArrivalsPoint { get; set; }

    }
}
