using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Databases
{
     class StructureGroupClient
    {
        public int Id_SGC { get; set; }
        public int FK_Client { get; set; }
        public int FK_Expedition { get; set; }
    }
}
