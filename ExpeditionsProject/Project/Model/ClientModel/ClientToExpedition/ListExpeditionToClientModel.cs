using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model.ClientModel.ClientToExpedition
{
    public class ListExpeditionToClientModel
    {
        public int ID_Expedition
        {
            get;
            set;
        }
        public DateTime DateStart
        {
            get;
            set;
        }

        public DateTime DateFinish
        {
            get;
            set;
        }
        public int ID_Itinerary
        {
            get;
            set;
        }
        public string NameItinerary
        {
            get;
            set;
        } = string.Empty;
        public ListExpeditionToClientModel SelectedRoute
        {
            get;
            set;

        }

    }
}
