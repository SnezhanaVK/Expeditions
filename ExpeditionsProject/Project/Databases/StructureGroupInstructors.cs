using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Databases
{
    public class StructureGroupInstructors
    {
        public int Id_SGI { get; set; }
        public int FK_Instructor { get; set; }
        public int FK_Expedition { get; set; }
    }
}
