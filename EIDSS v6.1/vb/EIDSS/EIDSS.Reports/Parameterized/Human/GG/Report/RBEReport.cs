using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.DataSet;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public sealed partial class RBEReport : BaseIntervalReport
    {
        public RBEReport()
        {
            InitializeComponent();
        }

        public void SetParameters(RBESurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            SetParameters( (BaseIntervalModel)model, manager, archiveManager);
            YearMainHeaderCell.Text = YearCasesHeaderCell.Text = YearAnimalsHeaderCell.Text = model.Year.ToString();
            QuarterMainHeaderCell.Text = model.QuarterName;
            QuarterCasesHeaderCell.Text = QuarterAnimalsHeaderCell.Text = model.QuarterLongName;
            if (!model.AddSignature)
            {
                PersonHeaderCell.DataBindings.Clear();
            }

            const string casesSortField = "datDate, strArea";
            const string animalsSortField = "strArea";
            const string casesKeyField = "intRowNumber";
            const string aniumalsKeyField = "strAreaKey";

            string regionsXml = FilterHelper.GetXmlFromList(model.Regions);
            string rayonsXml = FilterHelper.GetXmlFromList(model.Rayons);

            Action<SqlConnection, SqlTransaction> casesAction = ((connection, transaction) =>
            {
                m_CasesAdapter.Connection = connection;
                m_CasesAdapter.CommandTimeout = CommandTimeout;
                m_CasesAdapter.Transaction = transaction;
                m_CasesDataSet.EnforceConstraints = false;
                m_CasesAdapter.Fill(m_CasesDataSet.RBECases,
                    model.Language,
                    model.StartDate1,
                    model.EndDate1,
                    model.StartDate2,
                    model.EndDate2,
                    regionsXml,
                    rayonsXml,
                    model.UserId);
            });

            FillDataTableWithArchive(casesAction,
               manager, archiveManager,
                m_CasesDataSet.RBECases,
                model.Mode,
                new[] {casesKeyField});

            m_CasesDataSet.RBECases.DefaultView.Sort = casesSortField;

            Action<SqlConnection, SqlTransaction> animalsAction = ((connection, transaction) =>
            {
                m_AnimalsAdapter.Connection = connection;
                m_AnimalsAdapter.CommandTimeout = CommandTimeout;
                m_AnimalsAdapter.Transaction = transaction;
                m_AnimalsDataSet.EnforceConstraints = false;
                m_AnimalsAdapter.Fill(m_AnimalsDataSet.RBEAnimals,
                    model.Language,
                    model.StartDate1,
                    model.EndDate1,
                    model.StartDate2,
                    model.EndDate2,
                    regionsXml,
                    rayonsXml);
            });

            FillDataTableWithArchive(animalsAction,
                manager, archiveManager,
                m_AnimalsDataSet.RBEAnimals,
                model.Mode,
                new[] {aniumalsKeyField});

            m_AnimalsDataSet.RBEAnimals.DefaultView.Sort = animalsSortField;

            ProcessTotalCases();
        }

        private void ProcessTotalCases()
        {
            int totalDomestic = GetTotalDomesticCases();
            int totalWildLife = GetTotalWildLifeCases();

            TotalDomesticCell.Text = totalDomestic.ToString();
            TotalWildLifeCell.Text = totalWildLife.ToString();
            TotalCell.Text = (totalDomestic + totalWildLife).ToString();
        }

        private int GetTotalDomesticCases()
        {
            int totalDomestic = 0;

            foreach (RBECasesDataSet.RBECasesRow row in m_CasesDataSet.RBECases)
            {
                if (!row.IsintDomesticDogNull())
                {
                    totalDomestic += row.intDomesticDog;
                }

                if (!row.IsintDomesticCatNull())
                {
                    totalDomestic += row.intDomesticCat;
                }

                if (!row.IsintDomesticCattleNull())
                {
                    totalDomestic += row.intDomesticCattle;
                }

                if (!row.IsintDomesticEquineNull())
                {
                    totalDomestic += row.intDomesticEquine;
                }

                if (!row.IsintDomesticSheepNull())
                {
                    totalDomestic += row.intDomesticSheep;
                }
                if (!row.IsintDomesticGoatNull())
                {
                    totalDomestic += row.intDomesticGoat;
                }

                if (!row.IsintDomesticPigNull())
                {
                    totalDomestic += row.intDomesticPig;
                }

                if (!row.IsintDomesticStrayDogNull())
                {
                    totalDomestic += row.intDomesticStrayDog;
                }

                if (!row.IsintDomesticOtherNull())
                {
                    totalDomestic += row.intDomesticOther;
                }

                if (!row.IsintDomesticUnspecifiedNull())
                {
                    totalDomestic += row.intDomesticUnspecified;
                }
            }
            return totalDomestic;
        }

        private int GetTotalWildLifeCases()
        {
            int totalWildLife = 0;

            foreach (RBECasesDataSet.RBECasesRow row in m_CasesDataSet.RBECases)
            {
                if (!row.IsintWildlifeFoxNull())
                {
                    totalWildLife += row.intWildlifeFox;
                }

                if (!row.IsintWildlifeRaccoonDogNull())
                {
                    totalWildLife += row.intWildlifeRaccoonDog;
                }
                if (!row.IsintWildlifeRaccoonNull())
                {
                    totalWildLife += row.intWildlifeRaccoon;
                }

                if (!row.IsintWildlifeWolfNull())
                {
                    totalWildLife += row.intWildlifeWolf;
                }

                if (!row.IsintWildlifeBadgerNull())
                {
                    totalWildLife += row.intWildlifeBadger;
                }

                if (!row.IsintWildlifeMartenNull())
                {
                    totalWildLife += row.intWildlifeMarten;
                }
                if (!row.IsintWildlifeOtherMustelidesNull())
                {
                    totalWildLife += row.intWildlifeOtherMustelides;
                }
                if (!row.IsintWildlifeOtherCarnivoresNull())
                {
                    totalWildLife += row.intWildlifeOtherCarnivores;
                }
                if (!row.IsintWildlifeWildBoarNull())
                {
                    totalWildLife += row.intWildlifeWildBoar;
                }
                if (!row.IsintWildlifeRoeDeerNull())
                {
                    totalWildLife += row.intWildlifeRoeDeer;
                }
                if (!row.IsintWildlifeRedDeerNull())
                {
                    totalWildLife += row.intWildlifeRedDeer;
                }
                if (!row.IsintWildlifeFallowDeerNull())
                {
                    totalWildLife += row.intWildlifeFallowDeer;
                }
                if (!row.IsintWildlifeOtherNull())
                {
                    totalWildLife += row.intWildlifeOther;
                }
                if (!row.IsintWildlifeBatNull())
                {
                    totalWildLife += row.intWildlifeBat;
                }
                if (!row.IsintWildlifeUnspecifiedNull())
                {
                    totalWildLife += row.intWildlifeUnspecified;
                }
            }
            return totalWildLife;
        }
    }
}