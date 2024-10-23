using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Databases
{
    public class ListMenu
    {
        public int Id_ListMenu { get; set; }
        public int FK_Product { get; set; }
        public int FK_Menu { get; set; }
    }
}
