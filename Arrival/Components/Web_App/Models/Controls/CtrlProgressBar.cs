using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_App.Models.Controls
{
    public class CtrlProgressBar : CtrlBaseModel
    {
        public string id { get; set; }
        public string Color { get; set; }
        public int Porcentage { get; set; }

        public CtrlProgressBar()
        {
            ViewName = "";
        }
    }
}