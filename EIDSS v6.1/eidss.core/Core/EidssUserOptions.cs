using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace eidss.model.Core
{
    public class EidssUserOptions
    {
        #region Grids
        public class GridsAppearance
        {
            public class GridAppearance
            {
                public class ColumnAppearance
                {
                    public bool? IsShow { get; set; }
                    public int? Order { get; internal set; }
                    public int? Width { get; set; }
                    public bool IsDefault
                    {
                        get { return !IsShow.HasValue && !Order.HasValue && !Width.HasValue; }
                    }
                    public bool IsHidden { get { return IsShow.HasValue && !IsShow.Value; } }
                    public int GetWidth(int def)
                    {
                        return Width.HasValue ? Width.Value : def;
                    }

                    internal XElement Serialize(string name)
                    {
                        XElement ret = new XElement("column", new XAttribute("name", name));
                        if (IsShow.HasValue)
                            ret.Add(new XAttribute("show", IsShow.Value ? "true" : "false"));
                        if (Order.HasValue)
                            ret.Add(new XAttribute("order", Order.Value));
                        if (Width.HasValue)
                            ret.Add(new XAttribute("width", Width.Value));
                        return ret;
                    }
                    internal static Tuple<string, ColumnAppearance> Deserialize(XElement e)
                    {
                        string name = e.Attribute("name").Value;
                        ColumnAppearance val = new ColumnAppearance();
                        var show = e.Attribute("show");
                        if (show != null && !String.IsNullOrEmpty(show.Value))
                            val.IsShow = show.Value == "true";
                        var order = e.Attribute("order");
                        if (order != null && !String.IsNullOrEmpty(order.Value))
                            val.Order = Int32.Parse(order.Value);
                        var width = e.Attribute("width");
                        if (width != null && !String.IsNullOrEmpty(width.Value))
                            val.Width = Int32.Parse(width.Value);
                        return new Tuple<string, ColumnAppearance>(name, val);
                    }

                }

                private Dictionary<string, ColumnAppearance> _columns = new Dictionary<string, ColumnAppearance>();

                public ColumnAppearance this[string key]
                {
                    get
                    {
                        lock (_columns)
                        {
                            if (!_columns.ContainsKey(key))
                                _columns.Add(key, new ColumnAppearance());
                            return _columns[key];
                        }
                    }
                }

                public bool IsDefault
                {
                    get { lock (_columns) { return _columns.Aggregate(true, (a, i) => a && i.Value.IsDefault); } }
                }

                public void SetOrder(string name, int oldOrder, int newOrder)
                {
                    lock (_columns)
                    {
                        if (oldOrder < newOrder)
                        {
                            _columns.Where(i => i.Key != name && i.Value.Order.HasValue && i.Value.Order.Value > oldOrder && i.Value.Order.Value <= newOrder)
                                .ToList().ForEach(i => i.Value.Order = i.Value.Order.Value - 1);
                            this[name].Order = newOrder;
                        }
                        else if (oldOrder > newOrder)
                        {
                            _columns.Where(i => i.Key != name && i.Value.Order.HasValue && i.Value.Order.Value < oldOrder && i.Value.Order.Value >= newOrder)
                                .ToList().ForEach(i => i.Value.Order = i.Value.Order.Value + 1);
                            this[name].Order = newOrder;
                        }
                    }
                }

                public void RestoreToDefault()
                {
                    _columns = new Dictionary<string, ColumnAppearance>();
                }

                internal XElement Serialize(string name)
                {
                    XElement ret = new XElement("grid", new XAttribute("name", name));
                    _columns.ToList().ForEach(i =>
                    {
                        if (!i.Value.IsDefault)
                        {
                            ret.Add(i.Value.Serialize(i.Key));
                        }
                    });
                    return ret;
                }
                internal static Tuple<string, GridAppearance> Deserialize(XElement e)
                {
                    string name = e.Attribute("name").Value;
                    GridAppearance val = new GridAppearance();
                    e.Elements("column").ToList().ForEach(i =>
                    {
                        var item = ColumnAppearance.Deserialize(i);
                        val._columns.Add(item.Item1, item.Item2);
                    });
                    return new Tuple<string, GridAppearance>(name, val);
                }
            }

            private Dictionary<string, GridAppearance> _grids = new Dictionary<string, GridAppearance>();

            public GridAppearance this[string key]
            {
                get
                {
                    lock (_grids)
                    {
                        if (!_grids.ContainsKey(key))
                            _grids.Add(key, new GridAppearance());
                        return _grids[key];
                    }
                }
            }

            internal XElement Serialize()
            {
                XElement ret = new XElement("grids");
                _grids.ToList().ForEach(i => 
                { 
                    if (!i.Value.IsDefault)
                    {
                        ret.Add(i.Value.Serialize(i.Key));
                    }
                });
                return ret;
            }
            internal static GridsAppearance Deserialize(XElement e)
            {
                var ret = new GridsAppearance();
                e.Element("grids").Elements("grid").ToList().ForEach(i =>
                { 
                    var item = GridAppearance.Deserialize(i);
                    ret._grids.Add(item.Item1, item.Item2);
                });
                return ret;
            }
        }

        private GridsAppearance _grids = new GridsAppearance();
        public GridsAppearance Grids
        {
            get
            {
                return _grids;
            }
        }
        #endregion

        #region Preferences
        public class Preferences
        {
            private int? m_ListGridPageSize;
            public int ListGridPageSize
            {
                get
                {
                    return m_ListGridPageSize.HasValue ? m_ListGridPageSize.Value : BaseSettings.ListGridPageSize;
                }
                set
                {
                    m_ListGridPageSize = value;
                }
            }

            private int? m_PopupGridPageSize;
            public int PopupGridPageSize
            {
                get
                {
                    return m_PopupGridPageSize.HasValue ? m_PopupGridPageSize.Value : BaseSettings.PopupGridPageSize;
                }
                set
                {
                    m_PopupGridPageSize = value;
                }
            }

            private int? m_DetailGridPageSize;
            public int DetailGridPageSize
            {
                get
                {
                    return m_DetailGridPageSize.HasValue ? m_DetailGridPageSize.Value : BaseSettings.DetailGridPageSize;
                }
                set
                {
                    m_DetailGridPageSize = value;
                }
            }

            private int? m_LabSectionPageSize;
            public int LabSectionPageSize
            {
                get
                {
                    return m_LabSectionPageSize.HasValue ? m_LabSectionPageSize.Value : BaseSettings.LabSectionPageSize;
                }
                set
                {
                    m_LabSectionPageSize = value;
                }
            }

            private int? m_DefaultDays;
            public int DefaultDays
            {
                get
                {
                    return m_DefaultDays.HasValue ? m_DefaultDays.Value : BaseSettings.DefaultDateFilter;
                }
                set
                {
                    m_DefaultDays = value;
                }
            }

            private bool? m_DefaultRegion;
            public bool DefaultRegion
            {
                get
                {
                    return m_DefaultRegion.HasValue ? m_DefaultRegion.Value : BaseSettings.DefaultRegionInSearch;
                }
                set
                {
                    m_DefaultRegion = value;
                }
            }

            private bool? m_FilterByDiagnosis;
            public bool FilterByDiagnosis
            {
                get
                {
                    return m_FilterByDiagnosis.HasValue ? m_FilterByDiagnosis.Value : false;
                }
                set
                {
                    m_FilterByDiagnosis = value;
                }
            }

            private bool? m_PrintMapInVetInvestigationForm;
            public bool PrintMapInVetInvestigationForm
            {
                get
                {
                    return m_PrintMapInVetInvestigationForm.HasValue ? m_PrintMapInVetInvestigationForm.Value : false;
                }
                set
                {
                    m_PrintMapInVetInvestigationForm = value;
                }
            }

            private bool? m_ShowWharningForFinalCaseDefinition;
            public bool ShowWharningForFinalCaseDefinition
            {
                get
                {
                    return m_ShowWharningForFinalCaseDefinition.HasValue ? m_ShowWharningForFinalCaseDefinition.Value : false;
                }
                set
                {
                    m_ShowWharningForFinalCaseDefinition = value;
                }
            }

            public void RestoreToDefault()
            {
                m_ListGridPageSize = null;
                m_PopupGridPageSize = null;
                m_DetailGridPageSize = null;
                m_LabSectionPageSize = null;
                m_DefaultDays = null;
                m_DefaultRegion = null;
                m_FilterByDiagnosis = null;
                m_PrintMapInVetInvestigationForm = null;
                m_ShowWharningForFinalCaseDefinition = null;
            }

            internal XElement Serialize()
            {
                XElement ret = new XElement("prefs");
                if (m_ListGridPageSize.HasValue)
                    ret.Add(new XAttribute("listGridPageSize", m_ListGridPageSize.Value));
                if (m_PopupGridPageSize.HasValue)
                    ret.Add(new XAttribute("popupGridPageSize", m_PopupGridPageSize.Value));
                if (m_DetailGridPageSize.HasValue)
                    ret.Add(new XAttribute("detailGridPageSize", m_DetailGridPageSize.Value));
                if (m_LabSectionPageSize.HasValue)
                    ret.Add(new XAttribute("labSectionPageSize", m_LabSectionPageSize.Value));
                if (m_DefaultDays.HasValue)
                    ret.Add(new XAttribute("defaultDays", m_DefaultDays.Value));
                if (m_DefaultRegion.HasValue)
                    ret.Add(new XAttribute("defaultRegion", m_DefaultRegion.Value));
                if (m_FilterByDiagnosis.HasValue)
                    ret.Add(new XAttribute("filterByDiagnosis", m_FilterByDiagnosis.Value));
                if (m_PrintMapInVetInvestigationForm.HasValue)
                    ret.Add(new XAttribute("printMapInVetInvestigationForm", m_PrintMapInVetInvestigationForm.Value));
                if (m_ShowWharningForFinalCaseDefinition.HasValue)
                    ret.Add(new XAttribute("showWharningForFinalCaseDefinition", m_ShowWharningForFinalCaseDefinition.Value));
                return ret;
            }
            internal static Preferences Deserialize(XElement e)
            {
                Preferences val = new Preferences();
                var prefs = e.Element("prefs");
                var listGridPageSize = prefs.Attribute("listGridPageSize");
                if (listGridPageSize != null && !String.IsNullOrEmpty(listGridPageSize.Value))
                    val.m_ListGridPageSize = Int32.Parse(listGridPageSize.Value);
                var popupGridPageSize = prefs.Attribute("popupGridPageSize");
                if (popupGridPageSize != null && !String.IsNullOrEmpty(popupGridPageSize.Value))
                    val.m_PopupGridPageSize = Int32.Parse(popupGridPageSize.Value);
                var detailGridPageSize = prefs.Attribute("detailGridPageSize");
                if (detailGridPageSize != null && !String.IsNullOrEmpty(detailGridPageSize.Value))
                    val.m_DetailGridPageSize = Int32.Parse(detailGridPageSize.Value);
                var labSectionPageSize = prefs.Attribute("labSectionPageSize");
                if (labSectionPageSize != null && !String.IsNullOrEmpty(labSectionPageSize.Value))
                    val.m_LabSectionPageSize = Int32.Parse(labSectionPageSize.Value);
                var defaultDays = prefs.Attribute("defaultDays");
                if (defaultDays != null && !String.IsNullOrEmpty(defaultDays.Value))
                    val.m_DefaultDays = Int32.Parse(defaultDays.Value);
                var defaultRegion = prefs.Attribute("defaultRegion");
                if (defaultRegion != null && !String.IsNullOrEmpty(defaultRegion.Value))
                    val.m_DefaultRegion = Boolean.Parse(defaultRegion.Value);
                var filterByDiagnosis = prefs.Attribute("filterByDiagnosis");
                if (filterByDiagnosis != null && !String.IsNullOrEmpty(filterByDiagnosis.Value))
                    val.m_FilterByDiagnosis = Boolean.Parse(filterByDiagnosis.Value);
                var printMapInVetInvestigationForm = prefs.Attribute("printMapInVetInvestigationForm");
                if (printMapInVetInvestigationForm != null && !String.IsNullOrEmpty(printMapInVetInvestigationForm.Value))
                    val.m_PrintMapInVetInvestigationForm = Boolean.Parse(printMapInVetInvestigationForm.Value);
                var showWharningForFinalCaseDefinition = prefs.Attribute("showWharningForFinalCaseDefinition");
                if (showWharningForFinalCaseDefinition != null && !String.IsNullOrEmpty(showWharningForFinalCaseDefinition.Value))
                    val.m_ShowWharningForFinalCaseDefinition = Boolean.Parse(showWharningForFinalCaseDefinition.Value);
                return val;
            }
        }

        private Preferences _prefs = new Preferences();
        public Preferences Prefs
        {
            get
            {
                return _prefs;
            }
        }

        #endregion

        private const string elementOptionsName = "options";
        public string Serialize()
        {
            try
            {
                XDocument doc = new XDocument(
                    new XElement(elementOptionsName,
                        _prefs.Serialize(),
                        _grids.Serialize()
                        ));
                return doc.ToString(SaveOptions.DisableFormatting);
            }
            catch(Exception)
            {
                return "";
            }
        }
        public void Deserialize(string data)
        {
            try
            {
                XDocument doc = XDocument.Parse(data);
                var root = doc.Element(elementOptionsName);
                _prefs = Preferences.Deserialize(root);
                _grids = GridsAppearance.Deserialize(root);
            }
            catch (Exception)
            {
            }
        }
        public void Save()
        {
            string data = Serialize();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                try
                {
                    manager.SetSpCommand("dbo.spUserOptionsSave",
                        manager.Parameter("@UserID", EidssUserContext.User.ID),
                        manager.Parameter("@strOptions", data)
                        ).ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
