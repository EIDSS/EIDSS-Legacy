using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraVerticalGrid.Rows;
using SharpMap.Data;
using bv.winclient.Core;
using eidss.gis.Properties;

namespace eidss.gis.Tools.ToolForms
{
    public partial class InfoForm : BvForm
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private FeatureDataRow m_Feature;

        private DataTable m_StatTable;

        public bool IsAVR { get; set; }

        public bool IsSystem { get; set; }

        public DataTable StatTable
        {
            get { return m_StatTable; }
            set
            {
                if (m_StatTable!=null) featureGrid.Rows.Clear();
                m_StatTable = value;

                if (m_StatTable==null) return;
                if (m_StatTable.Columns.Count==0) return;
                if (m_StatTable.Rows == null) return;

                if (m_StatTable.Columns.Contains("strRegion"))
                {
                    if (!m_StatTable.Columns.Contains("strSettlement"))
                    {
                        // Region name
                        var columnReg = m_StatTable.Columns["strRegion"];
                        if (m_StatTable.Rows[0][columnReg.ColumnName] != null)
                        {
                            var val_reg = m_StatTable.Rows[0][columnReg.ColumnName];

                            var row_reg = new EditorRow(Resources.InfoForm_StatTable_Region) { Name = Resources.InfoForm_StatTable_Region, Enabled = true };

                            row_reg.Properties.Caption = Resources.InfoForm_StatTable_Region;
                            row_reg.Properties.RowEdit = persistentRepos.Items[0];
                            row_reg.Properties.Format.FormatType = FormatType.None;
                            row_reg.Properties.UnboundType = UnboundColumnType.String;

                            featureGrid.Rows.Add(row_reg);
                            featureGrid.SetCellValue(row_reg, 0, val_reg);
                        }

                        // Rayon name
                        var columnDistr = m_StatTable.Columns["strRayon"];
                        if (m_StatTable.Rows[0][columnDistr.ColumnName] != null)
                        {
                            var val_distr = m_StatTable.Rows[0][columnDistr.ColumnName];

                            var row_distr = new EditorRow(Resources.InfoForm_StatTable_Rayon) { Name = Resources.InfoForm_StatTable_Rayon, Enabled = true };

                            row_distr.Properties.Caption = Resources.InfoForm_StatTable_Rayon;
                            row_distr.Properties.RowEdit = persistentRepos.Items[0];
                            row_distr.Properties.Format.FormatType = FormatType.None;
                            row_distr.Properties.UnboundType = UnboundColumnType.String;

                            featureGrid.Rows.Add(row_distr);
                            featureGrid.SetCellValue(row_distr, 0, val_distr);
                        }
                    }
                    else
                    {
                        // Settlement name
                        var columnStt = m_StatTable.Columns["strSettlement"];
                        if (m_StatTable.Rows[0][columnStt.ColumnName] != null)
                        {
                            var val_stt = m_StatTable.Rows[0][columnStt.ColumnName];

                            var row_stt = new EditorRow(Resources.InfoForm_StatTable_Settlement) { Name = Resources.InfoForm_StatTable_Settlement, Enabled = true };

                            row_stt.Properties.Caption = Resources.InfoForm_StatTable_Settlement;
                            row_stt.Properties.RowEdit = persistentRepos.Items[0];
                            row_stt.Properties.Format.FormatType = FormatType.None;
                            row_stt.Properties.UnboundType = UnboundColumnType.String;

                            featureGrid.Rows.Add(row_stt);
                            featureGrid.SetCellValue(row_stt, 0, val_stt);
                        }

                        // Rayon name
                        var columnDistr1 = m_StatTable.Columns["strRayon"];
                        if (m_StatTable.Rows[0][columnDistr1.ColumnName] != null)
                        {
                            var val_distr1 = m_StatTable.Rows[0][columnDistr1.ColumnName];

                            var row_distr1 = new EditorRow(Resources.InfoForm_StatTable_Rayon) { Name = Resources.InfoForm_StatTable_Rayon, Enabled = true };

                            row_distr1.Properties.Caption = Resources.InfoForm_StatTable_Rayon;
                            row_distr1.Properties.RowEdit = persistentRepos.Items[0];
                            row_distr1.Properties.Format.FormatType = FormatType.None;
                            row_distr1.Properties.UnboundType = UnboundColumnType.String;

                            featureGrid.Rows.Add(row_distr1);
                            featureGrid.SetCellValue(row_distr1, 0, val_distr1);
                        }

                        // Region name
                        var columnReg1 = m_StatTable.Columns["strRegion"];
                        if (m_StatTable.Rows[0][columnReg1.ColumnName] != null)
                        {
                            var val_reg1 = m_StatTable.Rows[0][columnReg1.ColumnName];

                            var row_reg1 = new EditorRow(Resources.InfoForm_StatTable_Region) { Name = Resources.InfoForm_StatTable_Region, Enabled = true };

                            row_reg1.Properties.Caption = Resources.InfoForm_StatTable_Region;
                            row_reg1.Properties.RowEdit = persistentRepos.Items[0];
                            row_reg1.Properties.Format.FormatType = FormatType.None;
                            row_reg1.Properties.UnboundType = UnboundColumnType.String;

                            featureGrid.Rows.Add(row_reg1);
                            featureGrid.SetCellValue(row_reg1, 0, val_reg1);
                        }
                    }
                }
                else
                {
                    // Region name
                    var columnName = m_StatTable.Columns["strName"];
                    if (m_StatTable.Rows[0][columnName.ColumnName] != null)
                    {
                        var val_name = m_StatTable.Rows[0][columnName.ColumnName];

                        var row_name = new EditorRow(Resources.InfoForm_StatTable_Region) {Name = Resources.InfoForm_StatTable_Region, Enabled = true};

                        row_name.Properties.Caption = Resources.InfoForm_StatTable_Region;
                        row_name.Properties.RowEdit = persistentRepos.Items[0];
                        row_name.Properties.Format.FormatType = FormatType.None;
                        row_name.Properties.UnboundType = UnboundColumnType.String;

                        featureGrid.Rows.Add(row_name);
                        featureGrid.SetCellValue(row_name, 0, val_name);
                    }
                }

                if (!m_StatTable.Columns.Contains("strSettlement"))
                {
                    // Area
                    var columnArea = m_StatTable.Columns["varArea"];
                    if (m_StatTable.Rows[0][columnArea.ColumnName] != null)
                    {
                        var val_area = m_StatTable.Rows[0][columnArea.ColumnName];

                        var row_area = new EditorRow(Resources.InfoForm_StatTable_Area) {Name = Resources.InfoForm_StatTable_Area, Enabled = true};

                        row_area.Properties.Caption = Resources.InfoForm_StatTable_Area;
                        row_area.Properties.RowEdit = persistentRepos.Items[0];
                        row_area.Properties.Format.FormatType = FormatType.None;
                        row_area.Properties.UnboundType = UnboundColumnType.String;

                        featureGrid.Rows.Add(row_area);
                        featureGrid.SetCellValue(row_area, 0, val_area);
                    }

                    // Population
                    var columnPopulation = m_StatTable.Columns["varPopulation"];
                    if (m_StatTable.Rows[0][columnPopulation.ColumnName] != null)
                    {
                        var val_population = m_StatTable.Rows[0][columnPopulation.ColumnName];

                        var row_population = new EditorRow(Resources.InfoForm_StatTable_Human_population)
                                                 {Name = Resources.InfoForm_StatTable_Human_population, Enabled = true};

                        row_population.Properties.Caption = Resources.InfoForm_StatTable_Human_population;
                        row_population.Properties.RowEdit = persistentRepos.Items[0];
                        row_population.Properties.Format.FormatType = FormatType.None;
                        row_population.Properties.UnboundType = UnboundColumnType.String;

                        featureGrid.Rows.Add(row_population);
                        featureGrid.SetCellValue(row_population, 0, val_population);
                    }

                    // Population density
                    var columnPopDens = m_StatTable.Columns["varPopDens"];
                    if (m_StatTable.Rows[0][columnPopDens.ColumnName] != null)
                    {
                        var val_popdens = m_StatTable.Rows[0][columnPopDens.ColumnName];

                        var row_popdens = new EditorRow(Resources.InfoForm_StatTable_PopulationDens)
                                              {Name = Resources.InfoForm_StatTable_PopulationDens, Enabled = true};

                        row_popdens.Properties.Caption = Resources.InfoForm_StatTable_PopulationDens;
                        row_popdens.Properties.RowEdit = persistentRepos.Items[0];
                        row_popdens.Properties.Format.FormatType = FormatType.None;
                        row_popdens.Properties.UnboundType = UnboundColumnType.String;

                        featureGrid.Rows.Add(row_popdens);
                        featureGrid.SetCellValue(row_popdens, 0, val_popdens);
                    }
                }

            }
        }

        public FeatureDataRow Feature
        {
            get { return m_Feature; }
            set 
            { 
                if (m_Feature!=null) featureGrid.Rows.Clear();
                
                m_Feature = value;
                
                if (m_Feature == null) return;
                if (m_Feature.Table == null) return;
                if (m_Feature.Table.Columns.Count == 0) return;
                if (m_Feature.Table.Rows == null) return;
                if (m_Feature.Table.Rows.Count == 0) return;

                for (var i=0; i<m_Feature.Table.Columns.Count; i++)
                {
                    DataColumn column = m_Feature.Table.Columns[i];
                    if (m_Feature.Table.Rows[0][column.ColumnName]==null) continue;

                    if (IsAVR && i < m_Feature.Table.Columns.Count-6) continue;

                    var val = m_Feature.Table.Rows[0][column.ColumnName];

                    if (val==null) continue;

                    if (column.ColumnName == "info")
                    {
                        val = val.ToString().TrimStart('\r');
                        val = val.ToString().Trim('\n');
                        val = val.ToString().TrimEnd('\r');
                        val = val.ToString().Replace("\r\n", Environment.NewLine);
                    }

                    if (val.ToString().Trim()==string.Empty) continue;
                    
                    var row = new EditorRow(column.ColumnName) {Name = column.ColumnName, Enabled = true};
                    
                    row.Properties.Caption = column.ColumnName;
                    row.Properties.RowEdit = persistentRepos.Items[0];
                    row.Properties.Format.FormatType = FormatType.None;
                    row.Properties.UnboundType = UnboundColumnType.String;
                    
                    featureGrid.Rows.Add(row);
                    featureGrid.SetCellValue(row, i, val);
                }
            }
        }

        private void InfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; 
            Hide();
        }
    }
}