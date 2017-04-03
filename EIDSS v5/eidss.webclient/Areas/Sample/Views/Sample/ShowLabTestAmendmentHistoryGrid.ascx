<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.LabTestAmendmentHistory.LabTestAmendmentHistoryGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>


<%=Html.BvGrid<LabTestAmendmentHistory.LabTestAmendmentHistoryGridModel, LabTestAmendmentHistory.LabTestAmendmentHistoryGridModelList>((string)ViewData["LabTestAmendmentHistoryName"], Model, "detailsGrid", 
null, null, (bool)ViewData["IsReadOnly"], false, false, false)%>
