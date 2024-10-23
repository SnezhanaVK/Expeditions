using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Databases
{
    public class Equipment
    {
        public int ID_Equipment { get; set; }
        public string NameEquipment { get; set; }
        public string SkillRequirements { get; set; }
        public int CountInPerson { get; set; }
    }
}
