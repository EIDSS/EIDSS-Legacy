<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.VetFarmTree.VetFarmTreeGridModelList>" %>
<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>
<div id="VetFarmTreeContainer" name="VetFarmTreeContainer">
    <script type="text/javascript">
        function addNewHerd(link,name) {
            $.ajax({
                url: link,
                cache: false,
                dataType: "json",
                type: "GET",
                success: function (data) {
                    if (data == 'ok') {
                        gridItemAdded(name);
                    }
                    else {
                        if (data == 'ObjectExpired') {
                            var url = '/' + GetSiteLanguage() + '/Error/ObjectExpired';
                            window.location = url;
                        }
                        else {
                            ShowEidssErrorNotification(data, function () { });
                        }
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(jqXHR.status);
                }
            });
        }

        function addNewFarmTreeItem(link, name) {
            var  title = 'Add Species';
            var height = 400;
            
            ShowMessageWindow(getFullUrlByGridName(link, name), 600, height, title, false);
        }

        function itemIsSpecies() {
            var gridname = '<%=(string)ViewData["name"] %>';
            var key = $("#" + gridname + " tr.t-state-selected").find("[name='PartyType']").attr("value");
            return (key == 10072004);
        }
        function checkHerds() {
            //check if at least one herd exists            
            return ($("input[name='PartyType'][value='10072003']").attr("value") != undefined);
        }
    </script>
    <%Html.BvGrid<VetFarmTree.VetFarmTreeGridModel, VetFarmTree.VetFarmTreeGridModelList>(
          (string)ViewData["name"], Model, "detailsGrid", null, null, (bool)ViewData["ReadOnly"], true, false, !(bool)ViewData["ReadOnly"], (bool)ViewData["ReadOnly"], "strAverageAge,strFlockName", "onHerdFlockGridDataBound")
                    .ToolBar(toolBar =>
                        toolBar.Template(() =>
                        {
                            %>
                            
                            <a id="btClinicalSigns" href="javascript:<%=String.Format("if (itemIsSpecies('{1}')) showClinicalSigns('{0}','{1}', '{2}');", 
                                    Url.Action("SpeciesClinicalSigns", "FFPresenter", new RouteValueDictionary {{"area", "FlexForms"}, { "idfCase", ViewData["root"] }, {"idfParty", "*editkey*"} }),                                    
                                    ViewData["name"],
                                    Translator.GetMessageString("lblClinicalSigns") )%>" class='t-grid-action t-button t-button-icon'><span><%=Translator.GetMessageString("btClinicalInvestigation")%></span></a>                                                               

                            <a href='#' id="btDelete" class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("Delete")%></span></a>
                              
                            <a id="btEdit" href="javascript:<%=String.Format("if (itemIsSpecies('{1}')) editGridItem('{0}','{1}', 'Edit Species', 400);", 
                                     Url.Action("SpeciesDetail", "Herd", new RouteValueDictionary { { "area", "HerdEpi" }, { "key", ViewData["root"] }, { "name", ViewData["name"] }, { "idfParty", null } , { "idfSpecies", "*editkey*" } }),
                                    ViewData["name"] )%>" class='t-grid-action t-button t-button-icon'><span><%=Translator.GetMessageString("Edit")%></span></a> 
                            
                            <a id="btNewSpecies" href="javascript:<%=String.Format("if (checkHerds()) addNewFarmTreeItem('{0}', '{1}');", 
                                    Url.Action("SpeciesDetail", "Herd", new RouteValueDictionary { { "area", "HerdEpi" }, { "key", ViewData["root"] }, { "name", ViewData["name"] } , { "idfParty", "*editkey*" } }),
                                    ViewData["name"])%>" class='t-grid-action t-button t-button-icon'><span><%=Translator.GetMessageString("btNewSpecies")%></span></a> 
                                 
                            <a href="javascript:<%=String.Format("addNewHerd('{0}', '{1}');", 
                                    Url.Action("Create", "Herd", new RouteValueDictionary { { "area", "HerdEpi" }, { "key", ViewData["root"] }, { "name", ViewData["name"] } }),
                                    ViewData["name"])%>" class='t-grid-action t-button t-button-icon'><span><%=Translator.GetMessageString("strNewHerd")%></span></a>
                            
                            <%                                                       
                        })
                    )
                    .Columns(c => c.Bound("idfsPartyType").Hidden(true).ClientTemplate("<input type='hidden' name='PartyType' value='<#= idfsPartyType#>' />"))
                    .ClientEvents(events => events.OnRowSelect("onHerdFlockGridRowSelect"))
                    .Sortable(sorting => sorting.Enabled(false))
                    .Selectable().Render();                                                        
    %>
</div>
