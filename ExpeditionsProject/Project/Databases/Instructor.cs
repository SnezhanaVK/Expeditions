using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Databases
{
    public class Instructor
    {
        public int Id_Instructor { get; set; }
        public string ForeName { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public string NumberTelefon { get; set; }
        public string LevelProfisionsl { get; set; }
        public string Sport { get; set; }
        public string LevelHealth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
