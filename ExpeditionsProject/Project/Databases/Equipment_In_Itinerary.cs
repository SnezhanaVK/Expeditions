using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Databases
{
    public class Equipment_In_Itinerary
    {
        public int Id_EII { get; set; }
        public int FK_Itinerary { get; set; }
        public int FK_Equipment { get; set; }
    }
}
