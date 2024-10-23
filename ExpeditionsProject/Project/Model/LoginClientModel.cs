using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model
{
    public class LoginClientModel
    {
        public int ID_Clienta
        {
            get;
            set;
        } 

        public string Email
            {
                get;
                set;
            } = string.Empty;

            public string Password
            {
                get;
                set;
            } = string.Empty;
        
    }
}
