using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model.AdminModel.Expedition
{
    public class ExpeditionModel
    {
        public string ID_Expedition
        {
            get;
            set;
        }

        public string FK_Itinerary
        {
            get;
            set;
        }
    

        public string FK_Menu
        {
            get;
            set;
        }

        public string FK_Equipment
        {
            get;
            set;
        }

        public string FK_Transfera
        {
            get;
            set;
        }

        public string CounMenu
        {
            get;
            set;
        }

        public string CountEquipment
        {
            get;
            set;
        }

        public string DateStart
        {
            get;
            set;
        }

        public string DateFinish
        {
            get;
            set;
        }


    }
}
