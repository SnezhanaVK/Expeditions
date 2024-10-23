using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model.AdminModel.Itinerary
{
    public class CompletionItineraryItineraryModel
    {
        public string FK_LevelItinerary
        {
            get;
            set;
        }

        public string NameItinerary
        {
            get;
            set;
        } = string.Empty;
        public string CountDay
        {
            get;
            set;
        }
        public string CountKM
        {
            get;
            set;
        }

        public string FK_Itinerary
        {
            get;
            set;
        }

        public string FK_Regiona
        {
            get;
            set;
        }


    }
}
