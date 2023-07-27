using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Web_App.Models.Controls;

namespace Web_App.Helpers
{
    public static class ControlExtensions
    {
        public static HtmlString CtrlTable(this HtmlHelper html, string viewName, string id, string title,
            string columnsTitle, string ColumnsDataName, string onSelectFunction, string colorHeader)
        {
            var ctrl = new CtrlTableModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Columns = columnsTitle,
                ColumnsDataName = ColumnsDataName,
                FunctionName = onSelectFunction
            };

            //return new HtmlString("<h1>"+ctrl.Title +"</h1>");
            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlChart(this HtmlHelper html, string viewName, string id, string title,
            string labels, string chartType, string onLoadFunction)
        {
            var ctrl = new CtrlChartModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Labels = labels,
                ChartType = chartType,
                OnLoadFunction = onLoadFunction
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInput(this HtmlHelper html, string id, string type, string label, string placeHolder = "", string columnDataName = "")
        {
            var ctrl = new CtrlInputModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName,
            };

            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlButton(this HtmlHelper html, string viewName, string id, string label, string onClickFunction = "", string buttonType = "primary")
        {
            var ctrl = new CtrlButtonModel
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                FunctionName = onClickFunction,
                ButtonType = buttonType
            };

            return new HtmlString(ctrl.GetHtml());
        }

        /*public static HtmlString CtrlDropDown(this HtmlHelper html, string viewName, string id, string label, string service, string listId, string onSelectFunction = "")
        {
            var ctrl = new CtrlDropDownModel
            {
                Id = id,
                Label = label,
                ListId = listId,
                Service = service,
                FunctionName = onSelectFunction,
                ViewName = viewName
            };

            return new HtmlString(ctrl.GetHtml());
        }*/

        public static HtmlString CtrlDropDown(this HtmlHelper html, string id, string label, string listId, string ColumnDataName)
        {
            var ctrl = new CtrlDropDownModel
            {
                Id = id,
                Label = label,
                ListId = listId,
                ColumnDataName = ColumnDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlProgressBar(this HtmlHelper html, string viewName, string id, string color, int porcentage)
        {
            var ctrl = new CtrlProgressBar
            {
                ViewName = viewName,
                Id = id,
                Color = color,
                Porcentage = porcentage
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlNavbarLogo(this HtmlHelper html, string viewName, string id)
        {
            var ctrl = new CtrlNavbarLogo
            {
                ViewName = viewName,
                Id = id
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlPieChart(this HtmlHelper html, string viewName, string id)
        {
            var ctrl = new CtrlPieChart
            {
                ViewName = viewName,
                Id = id
            };
            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlCard(this HtmlHelper html, string viewName, string id, string label, int valor)
        {
            var ctrl = new CtrlCard
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                Valor = valor
            };
            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlLineChart(this HtmlHelper html, string viewName, string id)
        {
            var ctrl = new CtrlLineChart
            {
                ViewName = viewName,
                Id = id,
            };
            return new HtmlString(ctrl.GetHtml());
        }

    }
}