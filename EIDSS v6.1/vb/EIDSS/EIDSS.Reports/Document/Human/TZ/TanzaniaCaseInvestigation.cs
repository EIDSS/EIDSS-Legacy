using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Document.Human.TZ.DataSets;

namespace EIDSS.Reports.Document.Human.TZ
{
    public partial class TanzaniaCaseInvestigation : BaseDocumentReport
    {
        public TanzaniaCaseInvestigation()
        {
            InitializeComponent();
        }

        public override void SetParameters
            (string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(lang, parameters, manager, archiveManager);

            long caseId = GetLongParameter(parameters, "@ObjID");

            InvestigationAdapter.Connection = (SqlConnection) manager.Connection;
            InvestigationAdapter.Transaction = (SqlTransaction) manager.Transaction;
            InvestigationAdapter.CommandTimeout = CommandTimeout;
            InvestigationDataSet.EnforceConstraints = false;

            InvestigationAdapter.Fill(InvestigationDataSet.spRepHumTanzaniaInvestigation, lang, caseId);

            SpecimenAdapter.Connection = (SqlConnection) manager.Connection;
            SpecimenAdapter.Transaction = (SqlTransaction) manager.Transaction;
            SpecimenDataSet.EnforceConstraints = false;
            SpecimenAdapter.Fill(SpecimenDataSet.spRepHumTanzaniaSpecimen, lang, caseId);

            Rebind();
        }

        private void Rebind()
        {
            if (InvestigationDataSet.spRepHumTanzaniaInvestigation.Rows.Count > 0)
            {
                var row = (TanzaniaInvestigationDataSet.spRepHumTanzaniaInvestigationRow)
                    InvestigationDataSet.spRepHumTanzaniaInvestigation.Rows[0];
                if ((!row.IsblnAFPNull() && row.blnAFP) ||
                    (!row.IsblnCholeraNull() && row.blnCholera) ||
                    (!row.IsblnMeaslesNull() && row.blnMeasles) ||
                    (!row.IsblnMeningitisNull() && row.blnMeningitis) ||
                    (!row.IsblnNeonatalTetanusNull() && row.blnNeonatalTetanus) ||
                    (!row.IsblnPlagueNull() && row.blnPlague) ||
                    (!row.IsblnVHFNull() && row.blnVHF) ||
                    (!row.IsblnYellowFeverNull() && row.blnYellowFever)
                    )
                {
                    OtherDiagnosisCell.DataBindings.Clear();

                    const string xMark = "X";
                    if (!row.IsblnAFPNull() && row.blnAFP)
                    {
                        AFPCell.Text = xMark;
                    }
                    if (!row.IsblnCholeraNull() && row.blnCholera)
                    {
                        CholeraCell.Text = xMark;
                    }
                    if (!row.IsblnMeaslesNull() && row.blnMeasles)
                    {
                        MeaslesCell.Text = xMark;
                    }

                    if (!row.IsblnMeningitisNull() && row.blnMeningitis)
                    {
                        MeningitisCell.Text = xMark;
                    }
                    if (!row.IsblnNeonatalTetanusNull() && row.blnNeonatalTetanus)
                    {
                        NeonatalTetanusCell.Text = xMark;
                    }
                    if (!row.IsblnPlagueNull() && row.blnPlague)
                    {
                        PlagueCell.Text = xMark;
                    }
                    if (!row.IsblnVHFNull() && row.blnVHF)
                    {
                        VHFCell.Text = xMark;
                    }
                    if (!row.IsblnYellowFeverNull() && row.blnYellowFever)
                    {
                        YellowFeverCell.Text = xMark;
                    }
                    if (!row.IsstrPatientResidenceAddressNull())
                    {
                        Graphics graphics = new Label().CreateGraphics();
                        string address = row.strPatientResidenceAddress;
                        Font font = PatientResidence1Cell.Font;
                        SizeF measure = graphics.MeasureString(address, font);
                        if (PatientResidence1Cell.WidthF < measure.Width)
                        {
                            // word wrap. I know that algorythm is not optimized, but i doesn't matter
                            double width = 0;
                            int index = 0;
                            double spaceWidth = graphics.MeasureString(" ", font).Width;
                            foreach (string word in address.Split(' '))
                            {
                                width += spaceWidth + graphics.MeasureString(word, font).Width;
                                if (PatientResidence1Cell.WidthF < width)
                                {
                                    break;
                                }
                                index += word.Length + 1;
                            }
                            if (index > 0)
                            {
                                PatientResidence1Cell.DataBindings.Clear();

                                PatientResidence1Cell.Text = address.Substring(0, index);
                                PatientResidence2Cell.Text = address.Substring(index, address.Length - index);
                            }
                        }
                    }
                }

                if (!row.IsdatPatientDOBNull())
                {
                    AgeYearCell.DataBindings.Clear();
                }
            }
        }
    }
}