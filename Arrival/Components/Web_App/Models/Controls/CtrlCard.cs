using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_App.Models.Controls
{
    public class CtrlCard : CtrlBaseModel
    {
        public string Label { get; set; }
        public int Valor { get; set; }

        public CtrlCard()
        {

        }

        public CtrlCard(string label, int valor)
        {
            Label = label;
            Valor = valor;
        }

    }
}