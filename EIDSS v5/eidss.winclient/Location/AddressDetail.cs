using System;
using System.ComponentModel;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using eidss.model.Schema;
using eidss.winclient.Core;

namespace eidss.winclient.Location
{

    public partial class AddressDetail : eidss.winclient.Schema.BaseDetailPanel_Address
    {
        readonly LabelControlList m_ControlPairs;
        public AddressDetail()
        {
            InitializeComponent();
            m_ControlPairs = new LabelControlList();
            m_ControlPairs.Add(new LabelControlPair(lblResidenceType, cbResidenceType));
            m_ControlPairs.Add(new LabelControlPair(lblCountry, cbCountry));
            m_ControlPairs.Add(new LabelControlPair(lblRegion, cbRegion));
            m_ControlPairs.Add(new LabelControlPair(lblRayon, cbRayon));
            m_ControlPairs.Add(new LabelControlPair(lblSettlment, cbSettlement));
            m_ControlPairs.Add(new LabelControlPair(lblStreet, cbStreet));
            m_ControlPairs.Add(new LabelControlPair(lblPostalCode, cbPostalCode));
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
            {
                m_ControlPairs.Add(new LabelControlPair(lblHouse, new Control[] { txtBuilding, txtHouse, txtApartment }));
            }
            else
            {
                m_ControlPairs.Add(new LabelControlPair(lblHouse, new Control[] { txtHouse, txtBuilding, txtApartment }));
            }
            m_ControlPairs.CaptionWidth = CaptionWidth;
            //UpdateHouseView(lblHouse.Left, lblHouse.Width, txtHouse.Left, txtApartment.Left + txtApartment.Width - txtHouse.Left);
        }
        public override void DefineBinding()
        {
            var address = (Address)BusinessObject;
            if (ShowResidenceType)
            {
                LookupBinder.BindBaseLookup(cbResidenceType, address, "ResidentType", address.ResidentTypeLookup);
            }

            LookupBinder.BindTextEdit(txtBuilding, address, "strBuilding");
            LookupBinder.BindTextEdit(txtHouse, address, "strHouse");
            LookupBinder.BindTextEdit(txtApartment, address, "strApartment");
            if (ShowCountry)
            {
                LookupBinder.BindCountryLookup(cbCountry, address, "Country", address.CountryLookup);
            }
            LookupBinder.BindRegionLookup(cbRegion, address, "Region", address.RegionLookup);
            LookupBinder.BindRayonLookup(cbRayon, address, "Rayon", address.RayonLookup);
            LookupBinder.BindSettlementLookup(cbSettlement, address, "Settlement", address.SettlementLookup);
            LookupBinder.BindTextEdit(cbStreet, address, "strStreetName");
            LookupBinder.BindTextEdit(cbPostalCode, address, "strPostCode");

        }

        public delegate void AddressChangeHandler(Address address);
        /// <summary>
        /// Occures when region or rayon text changed
        /// </summary>
        public event AddressChangeHandler AddressChange;       
        #region Properties
        private bool m_ShowResidenceType = true;
        [Browsable(true), DefaultValue(true), Localizable(false)]
        public bool ShowResidenceType
        {
            get
            {
                return m_ShowResidenceType;
            }
            set
            {
                m_ShowResidenceType = value;
                m_ControlPairs.Item(0).Visible = value;
                m_ControlPairs.ForceUpdate();
            }
        }
        private bool m_ShowContry = true;
        [Browsable(true), DefaultValue(true), Localizable(false)]
        public bool ShowCountry
        {
            get
            {
                return m_ShowContry;
            }
            set
            {
                m_ShowContry = value;
                m_ControlPairs.Item(1).Visible = value;
                m_ControlPairs.ForceUpdate();
            }
        }

        private const int m_DefCaptionWidth = 160;
        private int m_CaptionWidth = 160;
        [Browsable(true), DefaultValue(m_DefCaptionWidth), Localizable(false)]
        public int CaptionWidth
        {
            get
            {
                if (m_CaptionWidth == 0)
                {
                    m_CaptionWidth = m_DefCaptionWidth;
                }
                return m_CaptionWidth;
            }
            set
            {
                if (m_CaptionWidth == 0)
                {
                    m_CaptionWidth = m_DefCaptionWidth;
                }
                if (value <= 0)
                {
                    value = System.Convert.ToInt32(m_DefCaptionWidth);
                }
                m_CaptionWidth = value;
                m_ControlPairs.CaptionWidth = m_CaptionWidth;
                RecalcControlWidth();
                if (WinUtils.IsComponentInDesignMode(this)) //AndAlso Created
                {
                    UpdateLayout();
                }
            }
        }
        private int m_ColumnCount = 1;
        [Browsable(true), DefaultValue(1), Localizable(false)]
        public int ColumnCount
        {
            get
            {
                if (m_ColumnCount <= 0)
                {
                    m_ColumnCount = 1;
                }
                return m_ColumnCount;
            }
            set
            {
                if (m_ColumnCount <= 0)
                {
                    m_ColumnCount = 1;
                }
                if (value <= 0)
                {
                    value = 1;
                }
                m_ColumnCount = value;
                m_ControlPairs.ColumnsCount = m_ColumnCount;
                RecalcControlWidth();
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    UpdateLayout();
                }
            }
        }
        #endregion

        #region Controls rearranging
        public void UpdateLayout()
        {
            if (m_Resizable)
            {
                m_ControlPairs.UpdateLayout();
            }
        }


        private void RecalcControlWidth()
        {
            if ((Width < (CaptionWidth + 100) * ColumnCount) && (m_Resizable == true))
            {
                return;
            }
            m_ControlPairs.ControlWidth = (int)(((double)(Width - m_ControlPairs.Left - ColumnCount * CaptionWidth - m_ControlPairs.ColumnsDistance * (ColumnCount - 1))) / ColumnCount);

        }
        private void AddressLookup_Resize(object sender, EventArgs e)
        {
            RecalcControlWidth();
            if (WinUtils.IsComponentInDesignMode(this) && Created)
            {
                UpdateLayout();
            }

        }

        //private void ArrangeControlPair(Control label, Control editor, int labelLeft, int labelWidth, int controlLeft, int controlWidth)
        //{
        //    label.Left = labelLeft;
        //    label.Width = labelWidth;
        //    editor.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        //    editor.Left = controlLeft;
        //    editor.Width = controlWidth;
        //}

        //private void UpdateResidenceTypeView(int labelLeft, int labelWidth, int controlLeft, int controlWidth)
        //{
        //    ArrangeControlPair(lblResidenceType, cbResidenceType, labelLeft, labelWidth, controlLeft, controlWidth);
        //}

        //private void UpdateCountryView(int labelLeft, int labelWidth, int controlLeft, int controlWidth)
        //{
        //    ArrangeControlPair(lblCountry,cbCountry , labelLeft, labelWidth, controlLeft, controlWidth);
        //}

        //private void UpdateRegionView(int labelLeft, int labelWidth, int controlLeft, int controlWidth)
        //{
        //    ArrangeControlPair(lblRegion,cbRegion , labelLeft, labelWidth, controlLeft, controlWidth);
        //}

        //private void UpdateRayonView(int labelLeft, int labelWidth, int controlLeft, int controlWidth)
        //{
        //    ArrangeControlPair(lblRayon,cbRayon , labelLeft, labelWidth, controlLeft, controlWidth);
        //}

        //private void UpdateSettlementView(int labelLeft, int labelWidth, int controlLeft, int controlWidth)
        //{
        //    ArrangeControlPair(lblSettlment, cbSettlement, labelLeft, labelWidth, controlLeft, controlWidth);
        //}

        //private void UpdateStreetView(int labelLeft, int labelWidth, int controlLeft, int controlWidth)
        //{
        //     ArrangeControlPair(lblStreet,cbStreet , labelLeft, labelWidth, controlLeft, controlWidth);
        //}

        //private void UpdatePostalCodeView(int labelLeft, int labelWidth, int controlLeft, int controlWidth)
        //{
        //    ArrangeControlPair(lblPostalCode,cbPostalCode , labelLeft, labelWidth, controlLeft, controlWidth);
        //}

        //private void UpdateHouseView(int labelLeft, int labelWidth, int controlLeft, int controlWidth)
        //{
        //    lblHouse.Left = labelLeft;
        //    lblHouse.Width = labelWidth;
        //    int TabIndex1 = txtBuilding.TabIndex;
        //    int TabIndex2 = txtHouse.TabIndex;

        //    if (ModelUserContext.CurrentLanguage == Localizer.lngEn)
        //    {
        //        txtBuilding.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        //        txtBuilding.Left = controlLeft;
        //        txtBuilding.Width = System.Convert.ToInt32(Math.Ceiling(System.Convert.ToDecimal((controlWidth - 16) / 3)));
        //        txtBuilding.TabIndex = Math.Min((short)TabIndex1, (short)TabIndex2);
        //        txtHouse.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        //        txtHouse.Left = controlLeft + (System.Convert.ToInt32(Math.Ceiling(System.Convert.ToDecimal((controlWidth - 16) / 3)))) + 8;
        //        txtHouse.Width = System.Convert.ToInt32(Math.Ceiling(System.Convert.ToDecimal((controlWidth - 16) / 3)));
        //        txtHouse.TabIndex = Math.Max((short)TabIndex1, (short)TabIndex2);
        //    }
        //    else
        //    {
        //        txtHouse.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        //        txtHouse.Left = controlLeft;
        //        txtHouse.Width = System.Convert.ToInt32(Math.Ceiling(System.Convert.ToDecimal((controlWidth - 16) / 3)));
        //        txtHouse.TabIndex = Math.Min((short)TabIndex1, (short)TabIndex2);
        //        txtBuilding.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        //        txtBuilding.Left = controlLeft + (System.Convert.ToInt32(Math.Ceiling(System.Convert.ToDecimal((controlWidth - 16) / 3)))) + 8;
        //        txtBuilding.Width = System.Convert.ToInt32(Math.Ceiling(System.Convert.ToDecimal((controlWidth - 16) / 3)));
        //        txtBuilding.TabIndex = Math.Max((short)TabIndex1, (short)TabIndex2);
        //    }
        //    txtApartment.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        //    txtApartment.Left = controlLeft + 2 * (System.Convert.ToInt32(Math.Ceiling(System.Convert.ToDecimal((controlWidth - 16) / 3)))) + 16;
        //    txtApartment.Width = controlWidth - (2 * (System.Convert.ToInt32(Math.Ceiling(System.Convert.ToDecimal((controlWidth - 16) / 3)))) + 16);
        //}

        //private void UpdateLabelView(System.Drawing.ContentAlignment labelAlignment)
        //{
        //    if (ShowResidenceType == true)
        //    {
        //        lblResidenceType.TextAlign = labelAlignment;
        //    }
        //    if (ShowCountry == true)
        //    {
        //        lblCountry.TextAlign = labelAlignment;
        //    }
        //    lblRegion.TextAlign = labelAlignment;
        //    lblRayon.TextAlign = labelAlignment;
        //    lblSettlment.TextAlign = labelAlignment;
        //    lblStreet.TextAlign = labelAlignment;
        //    lblPostalCode.TextAlign = labelAlignment;
        //    lblHouse.TextAlign = labelAlignment;
        //}

        private bool m_Resizable = true;

        //public void UpdateView(int lpWidth, int lpHeight, List<int> LabelColLeft, List<int> LabelColWidth, List<int> CtrlColLeft, List<int> CtrlColWidth, System.Drawing.ContentAlignment LabelAlignment)
        //{
        //    m_Resizable = true;
        //    if ((LabelColLeft != null) && (LabelColLeft.Count >= m_ColumnCount) && (LabelColWidth != null) && (LabelColWidth.Count >= m_ColumnCount) && (CtrlColLeft != null) && (CtrlColLeft.Count >= m_ColumnCount) && (CtrlColWidth != null) && (CtrlColWidth.Count >= m_ColumnCount))
        //    {
        //        UpdateLayout();

        //        int i = Math.Min(m_ColumnCount,LabelColLeft.Count);
        //        i = Math.Min(i,LabelColWidth.Count);
        //        i = Math.Min(i,CtrlColLeft.Count);
        //        i = Math.Min(i,CtrlColWidth.Count);
 
        //        if (i == m_ColumnCount)
        //        {
        //            m_Resizable = false;
        //            Width = lpWidth;
        //            Height = lpHeight;
        //            UpdateLabelView(LabelAlignment);
        //            UpdateNColumnView(LabelColLeft, LabelColWidth, CtrlColLeft, CtrlColWidth, m_ColumnCount);
        //        }
        //    }
        //}

        //private void IncrementColumn(ref int col, int colCount)
        //{
        //    if (col < colCount - 1)
        //        col++;
        //    else 
        //        col = 0;
        //}
        //private void UpdateNColumnView(List<int> LabelColLeft, List<int> LabelColWidth, List<int> CtrlColLeft, List<int> CtrlColWidth, int colCount)
        //{
        //    int col = 0;
        //    if (ShowResidenceType)
        //    {
        //        UpdateResidenceTypeView(LabelColLeft[col], LabelColWidth[col], CtrlColLeft[col], CtrlColWidth[col]);
        //        IncrementColumn(ref col, colCount);
        //    }
        //    if (ShowCountry)
        //    {
        //        UpdateCountryView(LabelColLeft[col], LabelColWidth[col], CtrlColLeft[col], CtrlColWidth[col]);
        //        IncrementColumn(ref col, colCount);
        //    }
        //    UpdateRegionView(LabelColLeft[col], LabelColWidth[col], CtrlColLeft[col], CtrlColWidth[col]);
        //    IncrementColumn(ref col, colCount);
        //    UpdateRayonView(LabelColLeft[col], LabelColWidth[col], CtrlColLeft[col], CtrlColWidth[col]);
        //    IncrementColumn(ref col, colCount);
        //    UpdateSettlementView(LabelColLeft[col], LabelColWidth[col], CtrlColLeft[col], CtrlColWidth[col]);
        //    IncrementColumn(ref col, colCount);
        //    UpdateStreetView(LabelColLeft[col], LabelColWidth[col], CtrlColLeft[col], CtrlColWidth[col]);
        //    IncrementColumn(ref col, colCount);
        //    UpdatePostalCodeView(LabelColLeft[col], LabelColWidth[col], CtrlColLeft[col], CtrlColWidth[col]);
        //    IncrementColumn(ref col, colCount);
        //    UpdateHouseView(LabelColLeft[col], LabelColWidth[col], CtrlColLeft[col], CtrlColWidth[col]);

        //}


        #endregion

        private void AddressDetail_Load(object sender, EventArgs e)
        {
            RecalcControlWidth();
            UpdateLayout();
        }

        private void Region_Changed(object sender, EventArgs e)
        {
            if ((AddressChange != null))
                AddressChange((Address)BusinessObject);
        }

        private void Rayon_Changed(object sender, EventArgs e)
        {
            if ((AddressChange != null))
                AddressChange((Address)BusinessObject);
        }
    }
}
