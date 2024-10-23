using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Databases
{
    public class Itinerary
    {
        public int Id_Itinerary { get; set; }
        public int FK_LevelItinerary { get; set; }
        public string NameItinerary { get; set; }
        public int CountDays { get; set; }
        public double CountKM { get; set; }
    }
}
