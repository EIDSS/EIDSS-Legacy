using System;
using System.Linq;
using System.Windows.Forms;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.gis.common;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Core;

namespace eidss.winclient.Location
{
    public partial class LocationDetail : Schema.BaseDetailPanel_GeoLocation
    {
        public LocationDetail()
        {
            InitializeComponent();
        }
        private GeoLocation geoLocation { get { return (GeoLocation)BusinessObject; } }

        public override void DefineBinding()
        {
            geoLocation.IsWinClient = true;
            var locationTypes =
                 geoLocation.GeoLocationTypeLookup.Where(
                     c =>
                     c.idfsBaseReference != Convert.ToInt64(GeoLocationTypeEnum.Default)).ToList();
            LookupBinder.BindBaseLookup(cbLocationType, geoLocation, "GeoLocationType", locationTypes,
                                         false, false);
            LookupBinder.BindRegionLookup(cbLocRegion, geoLocation, "Region", geoLocation.RegionLookup);
            LookupBinder.BindRayonLookup(cbLocRayon, geoLocation, "Rayon", geoLocation.RayonLookup);
            LookupBinder.BindSettlementLookup(cbLocSettlement, geoLocation, "Settlement", geoLocation.SettlementLookup);


            //Exact Location Binding
            LookupBinder.BindSpinEdit(seLongitude, geoLocation, "dblLongitude", -180, +180, true);
            LookupBinder.BindSpinEdit(seLatitude, geoLocation, "dblLatitude", -89, +89, true);
            LookupBinder.BindSpinEdit(seRelLongitude, geoLocation, "dblRelLongitude", -180, +180, true);
            LookupBinder.BindSpinEdit(seRelLatitude, geoLocation, "dblRelLatitude", -89, +89, true);
            LookupBinder.BindSpinEdit(seDistance, geoLocation, "dblDistance", 0, 1000, true);
            LookupBinder.BindSpinEdit(seDirection, geoLocation, "dblAlignment", 0, 360, true);
            LookupBinder.BindBaseLookup(cbGroundType, geoLocation, "GroundType", geoLocation.GroundTypeLookup, false);
            LookupBinder.BindRegionLookup(cbRegion, geoLocation, "Region", geoLocation.RegionLookup);
            LookupBinder.BindRayonLookup(cbRayon, geoLocation, "Rayon", geoLocation.RayonLookup);
            LookupBinder.BindSettlementLookup(cbSettlement, geoLocation, "Settlement", geoLocation.SettlementLookup);
            LookupBinder.BindTextEdit(txtLocDescription, geoLocation, "strDescription");
            LookupBinder.BindTextEdit(txtRelativeDescription, geoLocation, "strDescription");
            //Foreign Address Binding
            LookupBinder.BindCountryLookup(cbCountry, geoLocation, "Country", geoLocation.CountryLookup);
            LookupBinder.BindTextEdit(txtAddress, geoLocation, "strForeignAddress");


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

            UpdateInterface();

        }
        private void SwitchBinding(Control ctlSource, Control ctlTarget, string fieldName)
        {
            ctlSource.DataBindings.Clear();
            ctlTarget.DataBindings.Clear();
            ctlTarget.DataBindings.Add("EditValue", BusinessObject, fieldName, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public GeoLocationTypeEnum LocationType
        {
            get
            {
                if (BusinessObject == null)
                    return GeoLocationTypeEnum.ExactPoint;
                if (geoLocation.idfsGeoLocationType == null)
                {
                    geoLocation.idfsGeoLocationType = (long)(GeoLocationTypeEnum.ExactPoint);
                    UpdateInterface();
                }
                return ((GeoLocationTypeEnum)(geoLocation.idfsGeoLocationType));
            }
        }


        private void UpdateInterface()
        {
            if (LocationType != GeoLocationTypeEnum.Address &&
                !geoLocation.idfsCountry.Equals(EidssSiteContext.Instance.CountryID))
            {
                geoLocation.Country =
                    geoLocation.CountryLookup.FirstOrDefault(c => c.idfsCountry == EidssSiteContext.Instance.CountryID);
                geoLocation.AcceptChanges();
            }

            if (LocationType == GeoLocationTypeEnum.ExactPoint)
            {

                pnExactLocation.Visible = true;
                pnRelativeLocation.Visible = false;
                pnForeignAddress.Visible = false;
                SwitchBinding(cbRegion, cbLocRegion, "Region");
                SwitchBinding(cbRayon, cbLocRayon, "Rayon");
                SwitchBinding(cbSettlement, cbLocSettlement, "Settlement");
                SwitchBinding(txtRelativeDescription, txtLocDescription, "strDescription");
            }
            else if (LocationType == GeoLocationTypeEnum.RelativePoint)
            {
                pnExactLocation.Visible = false;
                pnRelativeLocation.Visible = true;
                pnForeignAddress.Visible = false;
                SwitchBinding(cbLocRegion, cbRegion, "Region");
                SwitchBinding(cbLocRayon, cbRayon, "Rayon");
                SwitchBinding(cbLocSettlement, cbSettlement, "Settlement");
                SwitchBinding(txtLocDescription, txtRelativeDescription, "strDescription");
            }
            else if (LocationType == GeoLocationTypeEnum.Address)
            {
                pnExactLocation.Visible = false;
                pnRelativeLocation.Visible = false;
                pnForeignAddress.Visible = true;
            }
            else
            {
                pnExactLocation.Visible = false;
                pnRelativeLocation.Visible = false;
                pnForeignAddress.Visible = false;
            }
        }

        private void cbLocationType_EditValueChanged(object sender, EventArgs e)
        {
            geoLocation.GeoLocationType = (BaseReference)cbLocationType.EditValue;
            UpdateInterface();
        }

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
            if (!x.HasValue || !y.HasValue)
                return;
            long? idfsCountry = 0, idfsRegion = 0, idfsRayon = 0;
            string connectionString = DbManagerFactory.Factory.ConnectionString;
            if (CoordinatesUtils.CoordToAdm(out idfsCountry, out idfsRegion, out idfsRayon, connectionString, y.Value, x.Value))
            {
                if (geoLocation.idfsRegion != idfsRegion)
                {
                    geoLocation.Region =
                        geoLocation.RegionLookup.Single(c => c.idfsRegion == idfsRegion);

                }
                if (geoLocation.idfsRayon != idfsRayon)
                {
                    geoLocation.Rayon = geoLocation.RayonLookup.Single(c => c.idfsRayon == idfsRayon);

                }
            }


        }

        public override void ShowValidationError(object sender, bv.model.Model.Core.ValidationEventArgs args)
        {
            if (args.MessageId == "msgCoordinatesAutoCorrection")
            {
                if (WinUtils.ConfirmMessage(FindForm(), EidssMessages.Get("msgCoordinatesAutoCorrection"), BvMessages.Get("Warning")))
                {
                    geoLocation.Region =
                        geoLocation.RegionLookup.Single(c => c.idfsRegion == (long?)args.Pars[0]);
                    geoLocation.Rayon = geoLocation.RayonLookup.Single(c => c.idfsRayon == (long?)args.Pars[1]);
                    args.Continue = true;
                }
                return;

            }
            base.ShowValidationError(sender, args);
        }
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
