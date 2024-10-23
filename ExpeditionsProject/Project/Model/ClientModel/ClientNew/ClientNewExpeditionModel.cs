using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model.ClientModel.ClientNew
{
    public class ClientNewExpeditionModel
    {
       
            public int ID_Expedition { get; set; }
        public int CounMenu { get; set; }
        public int CountEquipment { get; set; }
        public string NameItinerary { get; set; }
        public string NameEquipment { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public ClientNewExpeditionModel SelectedRoute { get; set; }

    }
}
