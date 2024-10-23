using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Databases
{
    public class Expedition
    {
        public int ID_Expedition { get; set; }
        public int FK_Itinerary { get; set; }//маршрут
        public int FK_Menu { get; set; }
        public int FK_Equipment { get; set; }//снаряжение
        public int FK_Transfer { get; set; }
        public int CountPortion { get; set; }
        public int CountEquipment { get; set; }
        public string NameItinerary { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
    }
}
