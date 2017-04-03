<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.AnimalListItem.AnimalListItemGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>
<div id="AnimalListContainer">
    <%Html.BvGrid<AnimalListItem.AnimalListItemGridModel, AnimalListItem.AnimalListItemGridModelList>(ViewData["name"].ToString(), Model, "detailsGrid", null, null, (bool)ViewData["ReadOnly"], true, false)
        .ToolBar(toolBar =>                                                                
            toolBar.Template(() =>
            {    
                %>
                    <a href="javascript:<%=String.Format("showClinicalSigns('{0}','{1}', '{2}');", 
                        Url.Action("AnimalClinicalSigns", "FFPresenter", new RouteValueDictionary {{"area", "FlexForms"}, { "idfCase", ViewData["root"] }, {"idfAnimal", "*editkey*"}, { "name", ViewData["name"] } }),                                                                        
                        ViewData["name"], Translator.GetMessageString("titleClinicalSigns"))%>" 
                        class='t-grid-action t-button t-button-icon t-grid-bv-edit'><span><%=Translator.GetMessageString("titleClinicalSigns")%></span></a>                   
                            
                    <a href='#' class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("Delete")%></span></a>
                                
                    <a href="javascript:<%=String.Format("editGridItem('{0}','{1}', 'Edit Animal', 320);", 
                        Url.Action("Details", "Animals", new RouteValueDictionary { { "area", "Animals" }, { "key", ViewData["root"] }, { "name", ViewData["name"] }, { "idfAnimal", "*editkey*" } }),
                        ViewData["name"] )%>" class='t-grid-action t-button t-button-icon t-grid-bv-edit'><span><%=Translator.GetMessageString("Edit")%></span></a> 

                    <a href="javascript:<%=String.Format("addNewItem('{0}', '{1}', '{2}', 320);", 
                        Url.Action("Details", "Animals", new RouteValueDictionary { { "area", "Animals" }, { "key", ViewData["root"] }, { "name", ViewData["name"] }, {"idfAnimal", "0"} }),
                        ViewData["name"], Translator.GetMessageString("AddAnimalWindowTitle"))%>" class='t-grid-action t-button t-button-icon t-state-enabled'><span><%=Translator.GetMessageString("strNew")%></span></a>       
                <%
            })
        ).Render();%> 
</div>
