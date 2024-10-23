using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model.ClientModel.ClientNew
{
    public class ClientNewInfoItineraryModel
    {
        public int ID_Itinerary { get; set; }
        public string NameItinerary { get; set; }
        public int CountDay { get; set; }
        public float CountKM { get; set; }
        public string LevelItinerary { get; set; }
        public string NameRegion { get; set; }
        public ClientNewInfoItineraryModel SelectedRoute
        {
            get;
            set;

        }

    }
}
