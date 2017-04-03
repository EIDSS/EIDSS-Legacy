<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.VetFarmTree.VetFarmTreeGridModelList>" %>
<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>
<div id="VetFarmTreeContainer" name="VetFarmTreeContainer">
    <script type="text/javascript">
        function addNewHerd(link, name) {
            $.ajax({
                url: link,
                cache: false,
                dataType: "json",
                type: "GET",
                success: function (data) {
                    gridItemAdded(name);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(jqXHR.status);
                }
            });
        }
        
        function checkHerds() {
            //check if at least one herd exists            
            return ($("input[name='PartyType'][value='10072003']").attr("value") != undefined);
        }
    </script>
    <%Html.BvGrid<VetFarmTree.VetFarmTreeGridModel, VetFarmTree.VetFarmTreeGridModelList>((string)ViewData["name"], Model, "detailsGrid", null, null, (bool)ViewData["IsReadOnly"], true, false, true, false, "intSickAnimalQty,intDeadAnimalQty,strNote,datStartOfSignsDate,strFlockName,strAverageAge", "onHerdFlockGridDataBound")
                    .ToolBar(toolBar =>
                        toolBar.Template(() =>
                        {%>
                            <a href='#' id="btDelete" class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("Delete")%></span></a>
                            
                            <a id="btEdit" href="javascript:<%=String.Format("if (itemIsSpecies('{1}')) editGridItem('{0}','{1}', '{2}');", 
                                    Url.Action("RootSpeciesDetail", "Herd", new RouteValueDictionary { { "area", "HerdEpi" }, { "key", ViewData["root"] }, { "name", ViewData["name"] }, { "idfSpecies", "*editkey*" } }),
                                    ViewData["name"] ,
                                    Translator.GetMessageString("titleRootFarmSpeciesAdd"))%>" class='t-grid-action t-button t-button-icon'><span><%=Translator.GetMessageString("Edit")%></span></a> 
                                      
                            <a id="btNewSpecies" href="javascript:<%=String.Format("if (checkHerds()) addNewItem('{0}', '{1}', '{2}');", 
                                    Url.Action("RootSpeciesDetail", "Herd", new RouteValueDictionary { { "area", "HerdEpi" }, { "key", ViewData["root"] }, { "name", ViewData["name"] } }),
                                    ViewData["name"],
                                    Translator.GetMessageString("titleRootFarmSpeciesAdd"))%>" class='t-grid-action t-button t-button-icon'><span><%=Translator.GetMessageString("btNewSpecies")%></span></a> 
       
                            <a href="javascript:<%=String.Format("addNewHerd('{0}', '{1}');", 
                                    Url.Action("CreateRoot", "Herd", new RouteValueDictionary { { "area", "HerdEpi" }, { "key", ViewData["root"] }, { "name", ViewData["name"] } }),
                                    ViewData["name"])%>" class='t-grid-action t-button t-button-icon'><span><%=Translator.GetMessageString("strNewHerd")%></span></a> 
                            <%                                                        
                        })
                    )
                    .ClientEvents(events => events.OnRowSelect("onHerdFlockGridRowSelect"))
                    .Columns(c => c.Bound("idfsPartyType").Hidden(true).ClientTemplate("<input type='hidden' name='PartyType' value='<#= idfsPartyType#>'"))
                    .Sortable(sorting => sorting.Enabled(false))
                    .Selectable().Render();                                                        
    %>
</div>
