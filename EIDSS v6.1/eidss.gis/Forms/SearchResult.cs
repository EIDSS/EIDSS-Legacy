using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using SharpMap.Geometries;
using SharpMap.Rendering;
using SharpMap.Styles;
using bv.common.db.Core;
using eidss.gis.Tools;
using eidss.gis.common;

namespace eidss.gis.Forms
{
    public partial class SearchResult : UserControl
    {
        private GeoSearch m_GeoSearch;
        

        public SearchResult(GeoSearch geoSearch)
        {
            m_GeoSearch = geoSearch;
            InitializeComponent();
            
            listSearchResults.DataSource = m_GeoSearch.SearchResultList;
            listSearchResults.DisplayMember = "Result";
            listSearchResults.ValueMember = "Result";

            //m_GeoSearch.NewSearchCall += m_GeoSearch_NewSearchCall;
        }

        //void m_GeoSearch_NewSearchCall(string searchString)
        //{
        //    listSearchResults.DataSource = null;
        //    listSearchResults.DataSource = m_GeoSearch.SearchResultList;
        //    listSearchResults.DisplayMember = "Result";
        //    listSearchResults.ValueMember = "Id";

        //    listSearchResults.Refresh();
        //}
        
        public void RefreshList()
        {
            listSearchResults.DataSource = null;
            listSearchResults.DataSource = m_GeoSearch.SearchResultList;
            listSearchResults.DisplayMember = "Result";
            listSearchResults.ValueMember = "Result";
            
            listSearchResults.Refresh();
            listSearchResults.SelectedIndex = 0;
        }

        private void moreButton_Click(object sender, EventArgs e)
        {
            m_GeoSearch.Search();
        }

        
        private void listSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSearchResults.SelectedIndex == -1) return;
            
            var item = (GeoSearch.SearchItem)listSearchResults.GetItem(listSearchResults.SelectedIndex);
            if (item == null) return;
            BoundingBox bbox;
            if (item.Settlement != "")
            {
                var geom = item.Shape;
                if (geom != null)
                {
                    bbox = geom.GetBoundingBox();
                    bbox = bbox.Grow(5000);
                }
                else return;
            }
            else if (item.Rayon != "")
            {
                var geom = item.Shape;
                if (geom != null)
                    bbox = geom.GetBoundingBox();
                else return;
            }
            else
            {
                var geom = item.Shape;
                if (geom != null)
                    bbox = geom.GetBoundingBox();
                else return;
            }
            
            m_GeoSearch.MapControl.Map.ZoomToBox(bbox);
            ((EidssMapControl)m_GeoSearch.MapControl.Parent).RefreshMap();

            // highlight
            DrawGeom(item.Shape);
        }

        private void DrawGeom(Geometry geom)
        {
            if (geom != null)
            {
                var g = m_GeoSearch.MapControl.CreateGraphics();
                
                Color fillColor = Color.Transparent, outlineColor = Color.Aqua;
                
                if (geom is Polygon)
                {
                    VectorRenderer.DrawPolygon(g, (Polygon) geom, new SolidBrush(fillColor),
                                               new Pen(Color.FromArgb(96, outlineColor), 7), false,
                                               m_GeoSearch.MapControl.Map);
                }
                else if (geom is MultiPolygon)
                {
                    VectorRenderer.DrawMultiPolygon(g, (MultiPolygon) geom, new SolidBrush(fillColor),
                                                    new Pen(Color.FromArgb(96, outlineColor), 7), false,
                                                    m_GeoSearch.MapControl.Map);
                }
                else if (geom is SharpMap.Geometries.Point)
                {
                    VectorRenderer.DrawPoint(g, (SharpMap.Geometries.Point) geom, MarkerTypes.Circle,
                                             new SolidBrush(Color.FromArgb(96, outlineColor)), false, new Pen(outlineColor) , 25, new PointF(0, 0),
                                             m_GeoSearch.MapControl.Map);
                }
                else if (geom is MultiPoint)
                {
                    VectorRenderer.DrawMultiPoint(g, (MultiPoint) geom, MarkerTypes.Circle, new SolidBrush(Color.FromArgb(96, outlineColor)),
                                                  false, new Pen(outlineColor), 25, new PointF(0, 0), m_GeoSearch.MapControl.Map);
                }

                m_GeoSearch.MapControl.PaintMapTitleAndLegend(g);
                g.Dispose();
            }
        }

        private void listSearchResults_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        public static float StringWidth(Graphics g, Font font, string text)
        {
            return g.MeasureString(text, font).Width;
        }

        public static string WrapText(Graphics g, Font font, string text, float lineWidth)
        {
            const string space = " ";
            string[] words = text.Split(new string[] { space }, StringSplitOptions.None);
            float spaceWidth = StringWidth(g, font, space),
                spaceLeft = lineWidth,
                wordWidth;
            StringBuilder result = new StringBuilder();

            foreach (string word in words)
            {
                wordWidth = StringWidth(g, font, word);
                if (wordWidth + spaceWidth > spaceLeft)
                {
                    result.AppendLine();
                    spaceLeft = lineWidth - wordWidth;
                }
                else
                {
                    spaceLeft -= (wordWidth + spaceWidth);
                }
                result.Append(word + space);
            }

            return result.ToString();
        }

        private void listSearchResults_DrawItem(object sender, DevExpress.XtraEditors.ListBoxDrawItemEventArgs e)
        {
            Brush backBrush1 = new SolidBrush(Color.FromArgb(224, 251, 254));
            Brush backBrush2 = new SolidBrush(Color.FromArgb(198, 241, 249));
            Brush backBrush3 = new SolidBrush(Color.FromArgb(253, 192, 47));
            // declare field representing the text of the item being drawn
            var lb = sender as DevExpress.XtraEditors.ListBoxControl;
            var itemText = WrapText(e.Graphics, e.Appearance.Font, (string)e.Item, lb.Width);
            
            if ((e.State & DrawItemState.Selected) != 0)
            {
                e.Cache.FillRectangle(backBrush3, e.Bounds);
                ControlPaint.DrawBorder3D(e.Graphics, e.Bounds);
                e.Cache.DrawString(itemText, e.Appearance.Font,
                                   new SolidBrush(e.Appearance.ForeColor),
                                   e.Bounds, e.Appearance.GetStringFormat());
                e.Handled = true;
                return;
            }
            if (e.Index % 2 == 0)
            {
                e.Cache.FillRectangle(backBrush1, e.Bounds);
            }
            else
            {
                e.Cache.FillRectangle(backBrush2, e.Bounds);
            }

            e.Cache.DrawString(itemText, lb.Font, new SolidBrush(lb.ForeColor), e.Bounds, e.Appearance.GetStringFormat());
            e.Handled = true;
        }

        static int LinesCount(string s)
        {
            int count = 1;
            int position = 0;
            while ((position = s.IndexOf('\n', position)) != -1)
            {
                count++;
                position++;         // Skip this occurrence!
            }
            return count;
        }

        private void listSearchResults_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            var lb = sender as DevExpress.XtraEditors.ListBoxControl;
            var itemValue = lb.GetItemText(e.Index);
            var itemText = WrapText(e.Graphics, lb.Font, itemValue, lb.Width);
            
            e.ItemHeight = e.ItemHeight * LinesCount(itemText);
            
        }
    }
}
