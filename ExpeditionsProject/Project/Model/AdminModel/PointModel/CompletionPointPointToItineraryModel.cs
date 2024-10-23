using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model.AdminModel.PointModel
{
    public class CompletionPointPointToItineraryModel
    {
        public string FK_Itinerary
        {
            get;
            set;
        }

        public string FK_Point
        {
            get;
            set;
        }

        public string FK_TypePoint
        {
            get;
            set;
        }
        public string DateToPoint
        {
            get;
            set;
        }

        public string TimeToPoint
        {
            get;
            set;
        }

        public string DayToPoint
        {
            get;
            set;
        }
        


    }
}
