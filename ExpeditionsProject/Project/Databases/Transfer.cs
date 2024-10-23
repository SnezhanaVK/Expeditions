using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Databases
{
    public class Transfer
    {
        public int Id_Transfer { get; set; }
        public string Date { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public double Price { get; set; }

    }
}
