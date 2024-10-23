using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model.ClientModel.ClientToExpedition
{
    public class ClientInfoExpeditionModel
    {
        public int ID_Expedition { get; set; }
        public int CountPortion { get; set; }
        public int CountEquipment { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Id_Menu { get; set; }
        public string NameMenu { get; set; }
        public int Id_Transfer { get; set; }
        public DateTime Date { get; set; }
        public int ID_Equipment { get; set; }
        public string NameEquipment { get; set; }
        public string SkillRequirements { get; set; }
        public int CountInPerson { get; set; }
    }
}


