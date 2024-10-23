using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model.AdminModel.AdminTabe
{
    public class InstructorTableModel
    {
        public int ID_Instructor { get; set; }
        public string ForeName { get; set; }

        public string Patronymic { get; set; }

        public string Surname { get; set; }
        public string NumberTelefon { get; set; }
        public string Sport { get; set; }
        public string LevelHealth { get; set; }
        public string LevelProfisionsl { get; set; }
        public int ID_Expedition { get; set; }

    }
}
