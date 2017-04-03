<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.RootFarmTree.RootFarmTreeGridModelList>" %>
<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>
<div id="RootFarmTreeContainer" name="RootFarmTreeContainer">
    <script type="text/javascript">
        function addNewFlock(link, name) {
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
    <%Html.BvGrid<RootFarmTree.RootFarmTreeGridModel, RootFarmTree.RootFarmTreeGridModelList>((string)ViewData["name"], Model, "detailsGrid", null, null, (bool)ViewData["IsReadOnly"], true, false, true, false, null, "onHerdFlockGridDataBound")
                    .ToolBar(toolBar =>
                        toolBar.Template(() =>
                        {
                            %>                            
                            <a href='#' id="btDelete" class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("Delete")%></span></a>
                            
                            <a id="btEdit" href="javascript:<%=String.Format("if (itemIsSpecies('{1}')) editGridItem('{0}','{1}');", 
                                    Url.Action("RootSpeciesDetail", "Flock", new RouteValueDictionary { { "area", "HerdEpi" }, { "key", ViewData["root"] }, { "name", ViewData["name"] }, { "idfSpecies", "*editkey*" } }),
                                    ViewData["name"] )%>" class='t-grid-action t-button t-button-icon'><span><%=Translator.GetMessageString("Edit")%></span></a> 

                            <a id="btNewSpecies" href="javascript:<%=String.Format("if (checkHerds()) addNewItem('{0}', '{1}');", 
                                    Url.Action("RootSpeciesDetail", "Flock", new RouteValueDictionary { { "area", "HerdEpi" }, { "key", ViewData["root"] }, { "name", ViewData["name"] } }),
                                    ViewData["name"])%>" class='t-grid-action t-button t-button-icon'><span><%=Translator.GetMessageString("btNewSpecies")%></span></a> 
                                    
                            <a href="javascript:<%=String.Format("addNewFlock('{0}', '{1}');", 
                                    Url.Action("CreateRoot", "Flock", new RouteValueDictionary { { "area", "HerdEpi" }, { "key", ViewData["root"] }, { "name", ViewData["name"] } }),
                                    ViewData["name"])%>" class='t-grid-action t-button t-button-icon'><span><%=Translator.GetMessageString("strNewFlock")%></span></a>                     
                            <%
                        })
                    )
                    .Selectable()
                    .ClientEvents(events => events.OnRowSelect("onHerdFlockGridRowSelect"))
                    .Columns(c => c.Bound("idfsPartyType").Hidden(true).ClientTemplate("<input type='hidden' name='PartyType' value='<#= idfsPartyType#>'/>"))
                    .Sortable(sorting => sorting.Enabled(false))
                    .Render();                                                        
    %>
</div>

