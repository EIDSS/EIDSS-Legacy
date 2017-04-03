<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.FFPresenterModel>" %>
<%@ Import Namespace="eidss.webclient.Utils" %> 

<%
    if ((Model != null) && (Model.TemplateFlexNode != null))
    {
        if (!Model.Settings.WindowMode)
        {
            %>
            <input type="hidden" id="FFKey" value="<%=ViewBag.FFKey %>"/>
            <input type="hidden" id="FFpresenterId" value="<%=ViewBag.FFpresenterId %>"/>
            <div><%
                foreach (var node in Model.TemplateFlexNode.ChildList)
                {
                    Html.RenderPartial("~/Areas/FlexForms/Views/FFPresenter/FlexNodeRender.ascx", node);
                    %><br/><%
                }
                //Model.ActivityParameters.AcceptChanges();
            %></div><%
        }
        else
        {
            using (Html.BeginForm())
            {
                %>
                <script src="../../../../Scripts/jquery.form.js" type="text/javascript"></script>
                <script type="text/javascript">
                    $(document).ready(function () {
                        $('form').ajaxForm(function (data) {
                            //alert(data);
                            if (data == 'ok') {
                                $('#Message').data('tWindow').close();
                                var name = '<%=ViewBag.GridName %>';
                                if (name.length > 0)
                                    parent.gridItemAdded(name);
                            }
                            else
                                ShowEidssErrorNotification(data, function () { });            
                        });
                    });

                    $(".popupContent").ready(function () {
                        ChangeMessageWindowHeigth();
                    }); 
                </script>
                <div class="popupContent">
                    <div class="yScrollable ffPopupContent">
                        <%
                        foreach (var node in Model.TemplateFlexNode.ChildList)
                        {
                            Html.RenderPartial("~/Areas/FlexForms/Views/FFPresenter/FlexNodeRender.ascx", node);
                        }
                        Model.ActivityParameters.AcceptChanges();
                        %>
                    </div>
                    <div class="popupBottomButtonPanel">
                        <input type="button" class="popupButton" onclick="parent.cancelItemAdding();" value="<%=Translator.GetMessageString("Cancel")%>" />
                        <input type="submit" class="popupButton" value="<%=Translator.GetMessageString("Ok")%>"/>
                    </div>
                </div>    
                <%
            }
        }
    }
%>
