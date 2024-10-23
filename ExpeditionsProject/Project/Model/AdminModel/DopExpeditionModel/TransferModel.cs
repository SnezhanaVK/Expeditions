using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model.AdminModel.DopExpeditionModel
{
    public class TransferModel
    {
        public string Date
        {
            get;
            set;
        } = string.Empty;

        public string TimeStart
        {
            get;
            set;
        } = string.Empty;

        public string TimeFinish
        {
            get;
            set;
        } = string.Empty;

        public string Prise
        {
            get;
            set;
        } = string.Empty;
    }
}
