using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using eidss.model.Resources;
using GIS_V4.Forms;
using GIS_V4.Tools;
using bv.common.db.Core;
using eidss.gis.Properties;
using eidss.gis.Tools.ToolForms;
using eidss.gis.common;

namespace eidss.gis.Tools
{
    public class MtAdminMask : CommandMapTool
    {
        public MtAdminMask()
        {
            Bitmap temp = Resources.filter_icon;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = EidssMessages.GetForCurrentLang("gis_Tools_AdministrationUnitMask_Caption", "Administration Unit Mask");
            m_ToolTipText = EidssMessages.GetForCurrentLang("gis_Tools_AdministrationUnitMask_Text", "Administration Unit Mask");

            //m_Caption = "Administration Unit Mask"; //Resources.gis_MtSaveMap_Caption;
            //m_ToolTipText = "Administration Unit Mask"; //Resources.gis_MtSaveMap_ToolTipText;
        }

        protected override void OnClick()
        {
            var form = new AdminUnitMaskForm();
            form.UseMask = m_UseMask;
            form.IdfsCountry = m_IdfsCountry;
            form.IdfsRegion = m_IdfsRegion;
            form.IdfsRayon = m_IdfsRayon;

            var dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                m_UseMask = form.UseMask;
                m_IdfsCountry = form.IdfsCountry;
                m_IdfsRegion = form.IdfsRegion;
                m_IdfsRayon = form.IdfsRayon;

                if (!m_UseMask)
                {
                    m_MapImage.Map.Mask = null;
                    m_MapImage.Refresh();
                    return;
                }
                long m_longIdfs = -101;
                if (m_IdfsRayon != null)
                {
                    long.TryParse(m_IdfsRayon.ToString(), out m_longIdfs);
                    if (m_longIdfs != -101)
                    {
                        m_MapImage.Map.Mask =
                            Extents.GetGeomById((SqlConnection) ConnectionManager.DefaultInstance.Connection,
                                                "gisWKBRayon", (long) form.IdfsRayon);
                        //GIS_V4.Utils.GeometryUtils.CreateBuffer(
                        //        Extents.GetGeomById((SqlConnection) ConnectionManager.DefaultInstance.Connection,
                        //                            "gisWKBRayon", (long) form.IdfsRayon), 10000);
                        m_MapImage.Refresh();
                        return;
                    }
                }
                if (m_IdfsRegion != null)
                {
                    long.TryParse(m_IdfsRegion.ToString(), out m_longIdfs);
                    if (m_longIdfs != -101)
                    {
                        m_MapImage.Map.Mask =
                            Extents.GetGeomById((SqlConnection) ConnectionManager.DefaultInstance.Connection,
                                                "gisWKBRegion", (long) form.IdfsRegion);
                            //GIS_V4.Utils.GeometryUtils.CreateBuffer(
                            //    Extents.GetGeomById((SqlConnection) ConnectionManager.DefaultInstance.Connection,
                            //                        "gisWKBRegion", (long) form.IdfsRegion), 10000);
                        m_MapImage.Refresh();
                        return;
                    }
                }
                if (m_IdfsCountry != null)
                {
                    long.TryParse(m_IdfsCountry.ToString(), out m_longIdfs);
                    if (m_longIdfs != -101)
                    {
                        m_MapImage.Map.Mask =
                            Extents.GetGeomById((SqlConnection) ConnectionManager.DefaultInstance.Connection,
                                                "gisWKBCountry", (long) form.IdfsCountry);
                            //GIS_V4.Utils.GeometryUtils.CreateBuffer(
                            //    Extents.GetGeomById((SqlConnection) ConnectionManager.DefaultInstance.Connection,
                            //                        "gisWKBCountry", (long) form.IdfsCountry), 10000);
                        m_MapImage.Refresh();
                    }
                }
            }
        }

        private bool m_UseMask = false;
        private object m_IdfsCountry = null;
        private object m_IdfsRegion = null;
        private object m_IdfsRayon = null;
    }
}
