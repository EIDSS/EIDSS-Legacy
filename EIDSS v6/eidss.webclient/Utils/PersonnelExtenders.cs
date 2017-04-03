using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BLToolkit.EditableObjects;
using eidss.model.Schema;
using System;

namespace eidss.webclient.Utils
{
    public static class PersonnelExtenders
    {
        //public static MvcHtmlString InvestigatedByPerson(this HtmlHelper htmlHelper, VetCase case)
        //{
        //    @(Html.Partial("../Personnel/InvestigatedBy",
        //        new ViewDataDictionary { 
        //            new KeyValuePair<string, object>("idfPerson", Model.idfPersonInvestigatedBy),
        //            new KeyValuePair<string, object>("datAssignedDate", Model.datAssignedDate),
        //            new KeyValuePair<string, object>("datInvestigationDate", Model.datInvestigationDate)
        //    }))
            
        //}  

        /*public static MvcHtmlString SelectPerson(this HtmlHelper htmlHelper, VetCase vcase, string idfsOfficePropertyName, string strOfficePropertyName, 
            string idfsPersonPropertyName, string strPersonPropertyName)
        {
            var args = new RouteValueDictionary
                           {
                               { "vetCase", vcase },
                               { "idfsOfficePropertyName", idfsOfficePropertyName },
                               { "strOfficePropertyName", strOfficePropertyName },
                               { "idfsPersonPropertyName", idfsPersonPropertyName },
                               { "strPersonPropertyName", strPersonPropertyName },
                           };
            return htmlHelper.Action("Select", "Personnel", args);
        }*/
    }
}