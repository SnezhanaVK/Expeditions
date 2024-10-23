using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model.AdminModel.AdminTabe
{
    public class ExpeditionTibleModel
    {
        public int ID_Expedition
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
        public ExpeditionTibleModel SelectedRoute
        {
            get;
            set;
            
        }
    }
}
