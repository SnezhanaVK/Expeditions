using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Databases
{
    public class Client
    {
        
            public int Id_Client { get; set; }
            public string ForeName { get; set; }
            public string Patronymic { get; set; }
            public string Surname { get; set; }
            public string NumberTelefon { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string NumberHome { get; set; }
            public string LevelHealth { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

    }
}
