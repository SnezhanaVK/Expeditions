using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model.AdminModel.Expedition
{
    public class ExspeditionToItineraryModel
    {
        public string FK_Expedition
        {
            get;
            set;
        }

        public string FK_PointToItinerary
        {
            get;
            set;
        }
        public string Time
        {
            get;
            set;
        }

        public string Date
        {
            get;
            set;
        }

    }
}
