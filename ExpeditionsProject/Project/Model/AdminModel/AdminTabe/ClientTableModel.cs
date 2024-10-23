using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model.AdminModel.AdminTabe
{
    public class ClientTableModel
    {
        public int ID_Client { get; set; }
        public string ForeName
        {
            get;
            set;
        } = string.Empty;
        public string Patronymic
        {
            get;
            set;
        } = string.Empty;

        public string Surname
        {
            get;
            set;
        } = string.Empty;

        public string NumberTelefon
        {
            get;
            set;
        } = string.Empty;
        public string LevelHealth
        {
            get;
            set;
        } = string.Empty;
        public int ID_Expedition { get; set; }
    }
}
