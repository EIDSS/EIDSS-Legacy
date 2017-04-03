<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.VaccinationListItem.VaccinationListItemGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<div id="VaccinationListContainer">
                <%Html.BvGrid<VaccinationListItem.VaccinationListItemGridModel, VaccinationListItem.VaccinationListItemGridModelList>(
                      ViewData["name"].ToString(), //name
                      Model, //list
                      "detailsGrid",//styleClass
                      null, //clientOnEdit
                      null, //clientOnSelect
                      (bool)ViewData["ReadOnly"], //readOnly
                      true, //bCustomToolbar
                      false,//bFilterable
                      !(bool)ViewData["ReadOnly"], //bEditable
                      false, //bToolBarBtnsDisable
                      null, //strExcludeColumns
                      "onVaccinationGridDataBound"//onDataBound
                      )     
                .ToolBar(toolBar =>
                        toolBar.Template(() =>
                        {
                            %>                            
                            <a href='#' class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("Delete")%></span></a>
                            
                            <a href="javascript:<%=String.Format("editGridItem('{0}','{1}', '{2}', 460);", 
                                    Url.Action("Details", "Vaccination",  new RouteValueDictionary { { "area", "Vaccination" }, { "key", ViewData["root"] }, { "name", ViewData["name"] }, { "idfVaccination", "*editkey*" } }),
                                    ViewData["name"], Translator.GetMessageString("titleEditVaccination") )%>" class='t-grid-action t-button t-button-icon t-grid-bv-edit'><span><%=Translator.GetMessageString("Edit")%></span></a> 

                            <a href="javascript:<%=String.Format("addNewItem('{0}', '{1}', '{2}', 460);", 
                                    Url.Action("Details", "Vaccination", new RouteValueDictionary { { "area", "Vaccination" }, { "key", ViewData["root"] }, { "name", ViewData["name"] }, {"idfVaccination", "0"} }),
                                    ViewData["name"], Translator.GetMessageString("titleAddVaccination"))%>" class='t-grid-action t-button t-button-icon t-state-enabled'><span><%=Translator.GetMessageString("Add")%></span></a>  
                            <%
                        })
                    )
                    .Selectable()
                    .ClientEvents(events => events.OnRowSelect("onVaccinationGridRowSelect"))
                    .Render();
                %>

</div>
