using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using bv.common.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;

namespace eidss.winclient.Location
{
    public partial class Location : Schema.BaseDetailPanel_GeoLocation
    {
        public Location()
        {
            InitializeComponent();
            if (LabelWidth == 0)
                LabelWidth = lbRelLongitude.Width;
            this.Resize += Location_Resize;
            Location_Resize(this, EventArgs.Empty);
        }
        private Address geoLocation { get { return (Address)BusinessObject; } }

        public override void DefineBinding()
        {

            //Exact Location Binding
            LookupBinder.BindSpinEdit(seLongitude, geoLocation, "dblLongitude", -180, +180, true);
            LookupBinder.BindSpinEdit(seLatitude, geoLocation, "dblLatitude", -89, +89, true);


            if (StartUpParameters != null && BusinessObject.IsNew)
            {
                if (StartUpParameters.ContainsKey("Country"))
                    geoLocation.idfsCountry = (long)StartUpParameters["Country"];
                if (StartUpParameters.ContainsKey("Region"))
                    geoLocation.idfsRegion = (long)StartUpParameters["Region"];
                if (StartUpParameters.ContainsKey("Rayon"))
                    geoLocation.idfsRayon = (long)StartUpParameters["Rayon"];
                if (StartUpParameters.ContainsKey("Settlement"))
                    geoLocation.idfsSettlement = (long)StartUpParameters["Settlement"];
                StartUpParameters.Clear();
                StartUpParameters = null;
            }
        }

        public void SetRegion(long region)
        {
            if (geoLocation != null)
                geoLocation.idfsRegion = region;
        }

        public void SetRayon(long rayon)
        {
            if (geoLocation != null)
                geoLocation.idfsRayon = rayon;
        }
        /*
        public GeoLocationTypeEnum LocationType
        {
            get
            {
                if (BusinessObject == null)
                    return GeoLocationTypeEnum.ExactPoint;
                if (geoLocation.idfsGeoLocationType == null)
                {
                    geoLocation.idfsGeoLocationType = (long)(GeoLocationTypeEnum.ExactPoint);
                }
                return ((GeoLocationTypeEnum)(geoLocation.idfsGeoLocationType));
            }
        }
        */
        private void btnMAP_Click(object sender, EventArgs e)
        {
            if (Parent != null && this is IPopupControl)
            {
                ((IPopupControl)this).PopupEdit.IsPopupTemporaryHidden = true;
                ((IPopupControl)this).PopupEdit.HidePopup();

            }
            try
            {
                decimal longitude = 0, latitude = 0;
                if (geoLocation.dblLongitude.HasValue)
                    longitude = (decimal)geoLocation.dblLongitude;
                if (geoLocation.dblLatitude.HasValue)
                    latitude = (decimal)geoLocation.dblLatitude;
                long idfsCountry = 0, idfsRegion = 0, idfsRayon = 0, idfsSettlement = 0;
                if (geoLocation.idfsCountry.HasValue)
                    idfsCountry = geoLocation.idfsCountry.Value;
                if (geoLocation.idfsRegion.HasValue)
                    idfsRegion = geoLocation.idfsRegion.Value;
                if (geoLocation.idfsRayon.HasValue)
                    idfsRayon = geoLocation.idfsRayon.Value;
                if (geoLocation.idfsSettlement.HasValue)
                    idfsSettlement = geoLocation.idfsSettlement.Value;
                gis.GisInterface.SetCaseLocation(idfsCountry, idfsRegion, idfsRayon, idfsSettlement,
                                            longitude, latitude, GetCoordinates);

            }

            catch (Exception ex)
            {

                ErrorForm.ShowError(ex);
            }
            finally
            {
                if (Parent != null && this is IPopupControl)
                {
                    ((IPopupControl)this).PopupEdit.RestorePopup();
                    ((IPopupControl)this).PopupEdit.IsPopupTemporaryHidden = false;
                }
            }

        }
        private void GetCoordinates(double? x, double? y)
        {
            geoLocation.dblLatitude = y;
            geoLocation.dblLongitude = x;
        }

        private void Location_Resize(object sender, EventArgs e)
        {
            lbRelLongitude.Width = LabelWidth;
            if (Localizer.IsRtl && !IsRtlApplied)
            {
                btnMAP.Left = 0;
                lbRelLongitude.Left = Width - lbRelLongitude.Width;
                seLongitude.Width = (btnMAP.Left - seLongitude.Left - 8) / 2 - 4;
                seLongitude.Left = lbRelLongitude.Left - seLongitude.Width - 4;
                seLatitude.Left = btnMAP.Left + 4;
                seLatitude.Width = btnMAP.Left - seLatitude.Left - 4;
            }
            else
            {
                btnMAP.Left = Width - btnMAP.Width;
                seLongitude.Left = lbRelLongitude.Left + lbRelLongitude.Width + 4;
                seLongitude.Width = (btnMAP.Left - seLongitude.Left - 8) / 2 - 4;
                seLatitude.Left = seLongitude.Left + seLongitude.Width + 4;
                seLatitude.Width = btnMAP.Left - seLatitude.Left - 4;
            }
        }
        [Browsable(true), Localizable(true)]
        public int LabelWidth { get; set; }
        //private bool m_Udating;
        //private void cbLocSettlement_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (m_Udating)
        //        return;
        //    m_Udating = true;
        //    try
        //    {
        //        if (cbLocSettlement.EditValue == null || cbLocSettlement.EditValue.ToString() == "")
        //            geoLocation.idfsSettlement = null;
        //        else
        //            geoLocation.idfsSettlement = ((SettlementLookup)cbLocSettlement.EditValue).idfsSettlement;
        //        if (!geoLocation.idfsSettlement.HasValue)
        //        {
        //            ClearCalculatedCoordinates();
        //            return;
        //        }
        //        double longitude, latitude;
        //        if (gis.GisInterface.GetSettlementCoordinates((long)geoLocation.idfsSettlement, out longitude, out latitude))
        //        {
        //            geoLocation.dblLongitude = longitude;
        //            geoLocation.dblLatitude = latitude;
        //        }
        //        if (geoLocation.idfsGeoLocationType == (long)GeoLocationTypeEnum.RelativePoint)
        //        {
        //            CalcRelCoordinates();
        //        }
        //    }
        //    finally
        //    {
        //        m_Udating = false;
        //    }

        //}

        //private void seDistance_EditValueChanged(object sender, EventArgs e)
        //{
        //    m_Udating = true;
        //    try
        //    {
        //        geoLocation.dblDistance = (long?)seDistance.EditValue;
        //        CalcRelCoordinates();
        //    }
        //    finally
        //    {
        //        m_Udating = false;
        //    }
        //}

        //private void seDirection_EditValueChanged(object sender, EventArgs e)
        //{
        //    m_Udating = true;
        //    try
        //    {
        //        geoLocation.dblAlignment = (long?)seDirection.EditValue;
        //        CalcRelCoordinates();
        //    }
        //    finally
        //    {
        //        m_Udating = false;
        //    }

        //}
        //private void CalcRelCoordinates()
        //{
        //    if (!geoLocation.dblDistance.HasValue || !geoLocation.dblAlignment.HasValue || !geoLocation.idfsSettlement.HasValue)
        //    {
        //        ClearCalculatedCoordinates();
        //        return;
        //    }
        //    double longitude, latitude;
        //    if (gis.GisInterface.GetRelativeCoordinates((long)geoLocation.idfsSettlement, (double)geoLocation.dblAlignment, (double)geoLocation.dblDistance, out longitude, out latitude))
        //    {
        //        geoLocation.dblRelLongitude = longitude;
        //        geoLocation.dblRelLatitude = latitude;
        //    }
        //}
        //private void ClearCalculatedCoordinates()
        //{
        //    geoLocation.dblRelLongitude = null;
        //    geoLocation.dblRelLatitude = null;
        //}


    }

}
