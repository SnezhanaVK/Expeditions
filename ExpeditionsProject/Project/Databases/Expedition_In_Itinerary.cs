using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Databases
{
    public class Expedition_In_Itinerary
    {
        public int Id_EiI { get; set; }
        public int FK_Expedition { get; set; }
        public int FK_PointInItinerary { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
    }
}
