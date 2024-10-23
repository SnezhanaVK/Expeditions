using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model.AdminModel.DopExpeditionModel
{
    public class ProductToMenuModel
    {
        public string FK_Product
        {
            get;
            set;
        } = string.Empty;

        public string FK_Menu
        {
            get;
            set;
        } = string.Empty;
    }
}
