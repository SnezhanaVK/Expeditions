using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model.AdminModel.DopExpeditionModel
{
    public class EquipmentItineraryModel
    {
        public string FK_Itinerary
        {
            get;
            set;
        } = string.Empty;

        public string FK_Equipment
        {
            get;
            set;
        } = string.Empty;

    }
}
