using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Databases
{
    public class Point
    {
        public int Id_Poin { get; set; }
        public int FK_TypePoint { get; set; }
        public string NamePoint { get; set; }
        public string DescriptionPoint { get; set; }
    }
}
