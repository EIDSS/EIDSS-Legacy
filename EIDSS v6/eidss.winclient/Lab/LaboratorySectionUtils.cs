using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLToolkit.EditableObjects;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraLayout;
using bv.common.Core;
using bv.common.Enums;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.BasePanel.ListPanelComponents;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.FlexForms;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;

namespace eidss.winclient.Lab
{
    internal class LaboratorySectionUtils
    {
        static internal void ShowCaseOrSessionForm(LaboratorySectionItem item, Control owner)
        {
            IApplicationForm detail = null;
            object id = null;
            if (item == null) return;

            if (item.idfHumanCase.HasValue)
            {
                detail = ClassLoader.LoadClass("HumanCaseDetail") as IApplicationForm;
                ReflectionHelper.SetProperty(detail, "ShowNavigators", false);
                id = item.idfHumanCase.Value;
            }
            else if (item.idfVetCase.HasValue)
            {
                if (item.idfsCaseType == (long)eidss.model.Enums.CaseTypeEnum.Livestock)
                {
                    detail = ClassLoader.LoadClass("VetCaseLiveStockDetail") as IApplicationForm;
                }
                else if (item.idfsCaseType == (long)eidss.model.Enums.CaseTypeEnum.Avian)
                {
                    detail = ClassLoader.LoadClass("VetCaseAvianDetail") as IApplicationForm;
                }
                id = item.idfVetCase.Value;
            }
            else if (item.idfMonitoringSession.HasValue)
            {
                detail = ClassLoader.LoadClass("AsSessionDetail") as IApplicationForm;
                id = item.idfMonitoringSession.Value;
            }
            else if (item.idfVectorSurveillanceSession.HasValue)
            {
                detail = ClassLoader.LoadClass("VsSessionDetail") as IApplicationForm;
                id = item.idfVectorSurveillanceSession.Value;
            }

            if (detail != null)
            {
                BaseFormManager.ShowModal_ReadOnly(detail, owner, ref id, null, null);
            }
            else
            {
                ErrorForm.ShowMessage("msgCaseSessionNotFound", "Case/Session with such ID is not found");
            }
        }

        static internal void ShowSampleForm(LaboratorySectionItem item, Control owner)
        {
            if (item.idfParentMaterial.HasValue)
            {
                object id = item.idfParentMaterial;
                var detail = ClassLoader.LoadClass("SampleDetail") as IApplicationForm;
                if (detail != null)
                {
                    BaseFormManager.ShowModal_ReadOnly(detail, owner, ref id, null, null);
                }
            }
        }


        static internal void BindNodes(BaseListGridControl Grid, Control _this, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest, out LayoutControlGroup groupFF)
        {
            var sil = new SupportInitializeList();
            sil.Add(Grid.GridControl);
            sil.Add(Grid.GridView);
            _this.SuspendLayout();

            Grid.GridControl.LevelTree.Nodes.Clear();
            Grid.GridControl.LevelTree.Nodes.AddRange(new[] 
            {
                LayoutBuilder.Node(LayoutBuilder.LayoutView(sil, Grid.GridControl, 
                    LayoutBuilder.LayoutViewCard(sil, 
                        new []
                        {
                            LayoutBuilder.LayoutControlGroup(sil, new Point(0,0), new Size(370, 100), new[]
                                {
                                    LayoutBuilder.LayoutViewField(sil, lclSample, new Point(0, 0), new Size(370, 24), new Size(200, 22), "datFieldCollectionDate"),
                                    LayoutBuilder.LayoutViewField(sil, lclSample, new Point(0, 24), new Size(370, 24), new Size(200, 22), "idfSubdivision"),
                                    LayoutBuilder.LayoutViewField(sil, lclSample, new Point(0, 48), new Size(370, 24), new Size(200, 22), "idfInDepartment"),
                                    LayoutBuilder.LayoutViewField(sil, lclSample, new Point(0, 72), new Size(370, 24), new Size(200, 22), "strParentMaterial"),
                                }),
                            LayoutBuilder.LayoutControlGroup(sil, new Point(370,0), new Size(600, 100), new[]
                                {
                                    LayoutBuilder.LayoutViewField(sil, lclSample, new Point(0, 0), new Size(640, 24), new Size(370, 22), "idfsCaseType"),
                                    LayoutBuilder.LayoutViewField(sil, lclSample, new Point(0, 24), new Size(640, 24), new Size(370, 22), "SpeciesVectorInfo"),
                                    LayoutBuilder.LayoutViewField(sil, lclSample, new Point(0, 48), new Size(640, 24), new Size(370, 22), "strTestCount"),
                                    LayoutBuilder.LayoutViewField(sil, lclSample, new Point(0, 72), new Size(640, 24), new Size(370, 22), "idfSendToOffice"),
                                }),
                            LayoutBuilder.LayoutControlGroup(sil, new Point(1010,0), new Size(370, 100), new[]
                                {
                                    LayoutBuilder.LayoutViewField(sil, lclSample, new Point(0, 0), new Size(370, 24), new Size(200, 22), "idfFieldCollectedByOffice"),
                                    LayoutBuilder.LayoutViewField(sil, lclSample, new Point(0, 24), new Size(370, 24), new Size(200, 22), "idfFieldCollectedByPerson"),
                                    LayoutBuilder.LayoutViewField(sil, lclSample, new Point(0, 48), new Size(370, 24), new Size(200, 22), "idfSendToOfficeOut"),
                                    LayoutBuilder.LayoutViewField(sil, lclSample, new Point(0, 72), new Size(370, 24), new Size(200, 22), "idfsDestructionMethod"),
                                }),
                            LayoutBuilder.LayoutControlGroup(sil, new Point(1380,0), new Size(400, 100), new BaseLayoutItem[]{}),
                            LayoutBuilder.LayoutControlGroup(sil, new Point(0,100), new Size(1200, 30), new[]
                                {
                                    LayoutBuilder.LayoutViewField(sil, lclSample, new Point(0, 0), new Size(1200, 24), new Size(200, 22), "strSampleNote"),
                                }),
                            LayoutBuilder.LayoutControlGroup(sil, new Point(1200,100), new Size(400, 30), new BaseLayoutItem[]{}),
                            LayoutBuilder.LayoutControlGroup(sil, new Point(0,100), new Size(1600, 1), new BaseLayoutItem[]{}),
                        }), 
                    lclSample.ToArray()
                ), "Sample"),
                LayoutBuilder.Node(LayoutBuilder.LayoutView(sil, Grid.GridControl, 
                    LayoutBuilder.LayoutViewCard(sil, 
                        new []
                        {
                            LayoutBuilder.LayoutControlGroup(sil, new Point(0,0), new Size(500, 100), new[]
                                {
                                    LayoutBuilder.LayoutViewField(sil, lclTest, new Point(0, 0), new Size(500, 24), new Size(330, 22), "idfTestedByPerson"),
                                    LayoutBuilder.LayoutViewField(sil, lclTest, new Point(0, 24), new Size(500, 24), new Size(330, 22), "idfResultEnteredByPerson"),
                                    LayoutBuilder.LayoutViewField(sil, lclTest, new Point(0, 48), new Size(500, 24), new Size(330, 22), "idfValidatedByPerson"),
                                    LayoutBuilder.LayoutViewField(sil, lclTest, new Point(0, 72), new Size(500, 24), new Size(330, 22), "blnExternalTest"),
                                    LayoutBuilder.LayoutViewField(sil, lclTest, new Point(0, 96), new Size(500, 24), new Size(330, 22), "idfPerformedByOffice"),
                                    LayoutBuilder.LayoutViewField(sil, lclTest, new Point(0, 120), new Size(500, 24), new Size(330, 22), "datReceivedDate"),
                                    LayoutBuilder.LayoutViewField(sil, lclTest, new Point(0, 144), new Size(500, 24), new Size(330, 22), "strContactPerson"),
                                }),
                            LayoutBuilder.LayoutControlGroup(sil, new Point(500,0), new Size(400, 100), new BaseLayoutItem[]
                                {
                                }, out groupFF),
                            LayoutBuilder.LayoutControlGroup(sil, new Point(900,0), new Size(400, 100), new BaseLayoutItem[]{}),
                            LayoutBuilder.LayoutControlGroup(sil, new Point(0,100), new Size(800, 1), new BaseLayoutItem[]{}),
                        }), 
                    lclTest.ToArray()
                ), "Test"),
                LayoutBuilder.Node(LayoutBuilder.GridView(sil, Grid.GridControl, 
                    new [] 
                    {
                        LayoutBuilder.GridColumn("datAmendmentDateNullable", "datAmendmentDate"),
                        LayoutBuilder.GridColumn("strName", "strAmendByPerson"),
                        LayoutBuilder.GridColumn("strOffice", "strOfficeAmendedBy"),
                        LayoutBuilder.GridColumn("strOldTestResult"),
                        LayoutBuilder.GridColumn("strNewTestResult"),
                        LayoutBuilder.GridColumn("strReason"),
                    }
                ), "AmendmentHistory"),
            });

            sil.ForEach(c => c.EndInit());
            _this.ResumeLayout(false);
        }

        static internal void SetReadOnlyColumns(BaseListGridControl Grid, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            var i = Grid.GridView.GetFocusedRow() as LaboratorySectionItem;
            if (i == null) return;

            foreach (GridColumn col in Grid.GridView.Columns)
            {
                var readOnly = i.IsReadOnly(col.Name);
                if (col.Name != "strCalculatedCaseID")
                    col.OptionsColumn.AllowEdit = !readOnly;
                col.OptionsColumn.ReadOnly = readOnly;
            }

            foreach (var field in lclSample)
            {
                var readOnly = i.IsReadOnly(field.FieldName);
                if (field.FieldName != "strParentMaterial")
                    field.OptionsColumn.AllowEdit = !readOnly;
                field.OptionsColumn.ReadOnly = readOnly;
            }
            foreach (var field in lclTest)
            {
                var readOnly = i.IsReadOnly(field.FieldName);
                field.OptionsColumn.AllowEdit = !readOnly;
                field.OptionsColumn.ReadOnly = readOnly;
            }
        }

        static internal void SetRowStyle(RowStyleEventArgs args, GridView view)
        {
            var f = new Font(args.Appearance.Font, args.Appearance.Font.Style | FontStyle.Bold);
            args.Appearance.Font = f;
            args.Appearance.Options.UseFont = true;
            args.Appearance.ForeColor = Color.Brown;
            if ((args.State & GridRowCellState.Selected) != 0)
            {
                args.Appearance.Options.UseForeColor = false;
            }
            else
            {
                args.Appearance.Options.UseForeColor = true;
            }
            args.Appearance.BackColor =
                (args.State & GridRowCellState.Selected) != 0 ? view.Appearance.SelectedRow.BackColor
                : view.Appearance.Row.BackColor;
            args.HighPriority = true;
        }

        static internal void RelationDisplayCaption(object sender, MasterRowGetRelationNameEventArgs e)
        {
            switch (e.RelationIndex)
            {
                case 0:
                    e.RelationName = EidssMessages.Get("tabTitleSample");
                    break;
                case 1:
                    e.RelationName = EidssMessages.Get("tabTitleTest");
                    break;
                case 2:
                    e.RelationName = EidssMessages.Get("tabTitleAmendmentHistory");
                    break;
            }
        }


        static internal void RelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            switch (e.RelationIndex)
            {
                case 0:
                    e.RelationName = "Sample";
                    break;
                case 1:
                    e.RelationName = "Test";
                    break;
                case 2:
                    e.RelationName = "AmendmentHistory";
                    break;
            }
        }

        static internal void RelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 3;
        }

        static internal void BindLookups(LaboratorySectionItem row, BaseListGridControl Grid, Control _this, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest, LayoutControlGroup groupFF)
        {
            LayoutViewColumn column = lclSample.FirstOrDefault(c => c.FieldName == "strParentMaterial");
            if (column != null)
            {
                var edt = new RepositoryItemButtonEdit();
                column.ColumnEdit = edt;
                edt.ButtonClick += (sender, args) => ShowSampleForm(row, _this);
            }

            BindLookup(lclSample, "idfSubdivision", row.FreezerLookup, _this, Grid, lclSample, lclTest);
            BindLookup(lclSample, "idfInDepartment", row.DepartmentLookup, Grid, lclSample, lclTest);
            BindLookup(lclSample, "idfsCaseType", row.CaseTypeLookup, Grid, lclSample, lclTest);
            BindLookup(lclSample, "SpeciesVectorInfo", row.SpeciesVectorInfoLookup, Grid, lclSample, lclTest);
            BindLookup(lclSample, "idfFieldCollectedByOffice", row.CollectedByOfficeLookup, Grid, lclSample, lclTest);
            BindLookup(lclSample, "idfFieldCollectedByPerson", row.CollectedByPersonLookup, Grid, lclSample, lclTest);
            BindLookup(lclSample, "idfSendToOffice", row.SendToOfficeLookup, Grid, lclSample, lclTest);
            BindLookup(lclSample, "idfSendToOfficeOut", row.SendToOfficeOutLookup, Grid, lclSample, lclTest);
            BindLookup(lclSample, "idfsDestructionMethod", row.DestructionMethodLookup, Grid, lclSample, lclTest);
            BindLookup(lclTest, "idfTestedByPerson", row.TestedByPersonLookup, Grid, lclSample, lclTest);
            BindLookup(lclTest, "idfResultEnteredByPerson", row.ResultEnteredByPersonLookup, Grid, lclSample, lclTest);
            BindLookup(lclTest, "idfValidatedByPerson", row.ValidatedByPersonLookup, Grid, lclSample, lclTest);
            BindLookup(lclTest, "idfPerformedByOffice", row.PerformedByOfficeLookup, Grid, lclSample, lclTest);
            BindCheckbox(lclTest, "blnExternalTest", Grid, lclSample, lclTest);
            /*
            var presenter = new FFPresenter(row.FFPresenter);
            groupFF.AddItem("", presenter);
            //groupFF.Container.Add(presenter);
            //tpVectorSpecificData.Controls.Add(presenter);
            
            presenter.Dock = DockStyle.Fill;
            //presenter.Left = 400;
            //presenter.Top = 100;
            //presenter.Width = 400;
            //presenter.Height = 500;
            presenter.ShowFlexibleForm();
            */
        }

        static internal void ChildList(MasterRowGetChildListEventArgs e, BaseListGridControl Grid, Control _this, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest, LayoutControlGroup groupFF)
        {
            switch (e.RelationIndex)
            {
                case 0:
                    var list = new List<object>();
                    var row = Grid.GridView.GetRow(e.RowHandle) as LaboratorySectionItem;
                    if (row != null)
                    {
                        list.Add(row);
                        e.ChildList = list;

                        BindLookups(row, Grid, _this, lclSample, lclTest, groupFF);
                    }
                    break;
                case 1:
                    list = new List<object>();
                    row = Grid.GridView.GetRow(e.RowHandle) as LaboratorySectionItem;
                    if (row != null)
                    {
                        list.Add(row);
                        e.ChildList = list;
                    }
                    break;
                case 2:
                    list = new List<object>();
                    row = Grid.GridView.GetRow(e.RowHandle) as LaboratorySectionItem;
                    if (row != null)
                    {
                        if (row.AmendmentHistory.Count == 0)
                        {
                            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                            {
                                list.Add(LabTestAmendment.Accessor.Instance(null).CreateNew(manager, row));
                                e.ChildList = list;
                            }
                        }
                        else
                        {
                            e.ChildList = row.AmendmentHistory;
                        }
                    }
                    break;
            }
        }

        static internal ActResult CreateSample(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject, BaseListGridControl Grid, List<LaboratorySectionItem> DataSource, EditableList<LaboratorySectionItem> list, bool bIsMyPref, BaseListPanel<LaboratorySectionItem> panel, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager, ParentObject, LabNewModeEnum.CreateSample, 0, null, null, null, null);
            var ret = BaseFormManager.ShowModal(new LaboratorySectionCreateNew(ParentObject, Grid, DataSource, list, bIsMyPref, panel, lclSample, lclTest), obj).DialogResult;
            return new ActResult(true, bo);
        }

        static internal ActResult ItemCreateSample(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject, bool bIsMyPref)
        {
            var obj = bo as LaboratorySectionItem;
            parameters.Clear();
            parameters.Add(obj.intNewSample.Value);
            parameters.Add(ParentObject);
            parameters.Add(obj);
            parameters.Add(obj.idfsSampleTypeFiltered);
            parameters.Add(bIsMyPref);
            return new ActResult(true, bo);
        }

        static internal ActResult GroupAccessionIn(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject, BaseListGridControl Grid, List<LaboratorySectionItem> DataSource, EditableList<LaboratorySectionItem> list, bool bIsMyPref, BaseListPanel<LaboratorySectionItem> panel, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager, ParentObject, LabNewModeEnum.GroupAccessionIn, 0, null, null, null, null);
            var ret = BaseFormManager.ShowModal(new LaboratorySectionGroupAccessionIn(ParentObject, Grid, DataSource, list, bIsMyPref, panel, lclSample, lclTest), obj).DialogResult;
            return new ActResult(true, bo);
        }

        static internal ActResult ItemGroupAccessionIn(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject, bool bIsMyPref)
        {
            parameters.Clear();
            parameters.Add(ParentObject);
            parameters.Add(bIsMyPref);
            return new ActResult(true, bo);
        }


        static internal ActResult MenuAssignTest(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject, BaseListGridControl Grid, List<LaboratorySectionItem> DataSource, EditableList<LaboratorySectionItem> list, BaseListPanel<LaboratorySectionItem> panel, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            List<IObject> cc = parameters[0] as List<IObject>;
            var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager, ParentObject, LabNewModeEnum.AssignTest, (bo as LaboratorySectionItem).idfsSampleType, null, (bo as LaboratorySectionItem).idfCaseOrSession, (bo as LaboratorySectionItem).idfsCaseType, (bo as LaboratorySectionItem).intCaseHACode, null, null, (bo as LaboratorySectionItem).idfMaterial, (bo as LaboratorySectionItem).idfsShowDiagnosis);
            var ret = BaseFormManager.ShowModal(new LaboratorySectionAssignTest(ParentObject, cc, Grid, DataSource, list, panel, lclSample, lclTest), obj).DialogResult;
            return new ActResult(true, bo);
        }

        static internal ActResult ItemAssignTest(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject, List<IObject> list)
        {
            var obj = bo as LaboratorySectionItem;
            parameters.Clear();
            parameters.Add(list);
            parameters.Add(ParentObject);
            parameters.Add(((LaboratorySectionItem)list[0]).bIsMyPref);
            return new ActResult(true, bo);
        }


        
        static internal ActResult MenuCreateAliquot(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject)
        {
            var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager, ParentObject, LabNewModeEnum.CreateAliquot, (bo as LaboratorySectionItem).idfsSampleType, null, null, null, null);
            var ret = BaseFormManager.ShowModal(new LaboratorySectionCreateAliquot(), obj).DialogResult;
            if (ret == DialogResult.OK)
            {
                parameters.Clear();
                parameters.Add(obj.intNewSample.Value);
                return new ActResult(true, bo);
            }
            return false;
        }

        static internal ActResult MenuCreateDerivative(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject)
        {
            var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager, ParentObject, LabNewModeEnum.CreateDerivative, (bo as LaboratorySectionItem).idfsSampleType, null, null, null, null);
            var ret = BaseFormManager.ShowModal(new LaboratorySectionCreateDerivative(), obj).DialogResult;
            if (ret == DialogResult.OK)
            {
                parameters.Clear();
                parameters.Add(obj.intNewSample.Value);
                parameters.Add(obj.DerivativeType.idfsDerivativeType);
                return new ActResult(true, bo);
            }
            return false;
        }

        static internal ActResult AcceptedInPoorCondition(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject)
        {
            var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager, ParentObject, LabNewModeEnum.Accept, 0, null, null, null, null);
            var ret = BaseFormManager.ShowModal(new LaboratorySectionAcceptedInPoorCondition(), obj).DialogResult;
            if (ret == DialogResult.OK)
            {
                parameters.Clear();
                parameters.Add(obj.strComments);
                return new ActResult(true, bo);
            }
            return false;
        }

        static internal ActResult AcceptedReject(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject)
        {
            var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager, ParentObject, LabNewModeEnum.Accept, 0, null, null, null, null);
            var ret = BaseFormManager.ShowModal(new LaboratorySectionAcceptedReject(), obj).DialogResult;
            if (ret == DialogResult.OK)
            {
                parameters.Clear();
                parameters.Add(obj.strComments);
                return new ActResult(true, bo);
            }
            return false;
        }

        static internal ActResult MenuTransferOutSample(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject)
        {
            var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager, ParentObject, LabNewModeEnum.TransferOutSample, 0, null, null, null, null, null, DateTime.Today);
            var ret = BaseFormManager.ShowModal(new LaboratorySectionTransferOut(), obj).DialogResult;
            if (ret == DialogResult.OK)
            {
                parameters.Clear();
                parameters.Add(obj.idfSendToOfficeOut);
                parameters.Add(obj.datSendDate);
                return new ActResult(true, bo);
            }
            return false;
        }

        static internal ActResult MenuAmendTestResult(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject)
        {
            var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager, ParentObject, LabNewModeEnum.AmendTestResult, 0, (bo as LaboratorySectionItem).idfsTestName.Value, null, null, null, (bo as LaboratorySectionItem).GetOriginalTestResult());
            var ret = BaseFormManager.ShowModal(new LaboratorySectionAmendTestResult(), obj).DialogResult;
            if (ret == DialogResult.OK)
            {
                parameters.Clear();
                parameters.Add(obj.strReason);
                parameters.Add(obj.idfsTestResult);
                return new ActResult(true, bo);
            }
            return false;
        }

        private class SampleBarcodeDTOComparator : EqualityComparer<SampleBarcodeDTO>
        {
            public override bool Equals(SampleBarcodeDTO x, SampleBarcodeDTO y)
            {
                return x.Barcode == y.Barcode
                    && x.CollectionDate == y.CollectionDate
                    && x.OwnerId == y.OwnerId
                    && x.SpeciesCode == y.SpeciesCode
                    && x.SpecimenCode == y.SpecimenCode
                    ;
            }

            public override int GetHashCode(SampleBarcodeDTO obj)
            {
                return base.GetHashCode();
            }
        }

        static internal ActResult MenuPrintBarcode(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject)
        {
            var items = parameters[0] as IEnumerable<IObject>;
            var model = items.Cast<LaboratorySectionItem>().Select(c => new SampleBarcodeDTO()
            {
                Barcode = c.strBarcode,
                CollectionDate = c.datFieldCollectionDate.HasValue ? c.datFieldCollectionDate.Value : DateTime.MinValue,
                OwnerId = c.strCalculatedCaseID,
                SpeciesCode = c.SpeciesVectorInfo == null ? "" : c.SpeciesVectorInfo.SpeciesOrVectorType,
                SpecimenCode = c.SampleType == null ? "" : c.SampleType.name
            }).Distinct(new SampleBarcodeDTOComparator()).ToList();

            EidssSiteContext.BarcodeFactory.ShowSamplePreview(model); 

            return true;
        }



        static internal ActResult DoNothing(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject)
        {
            return new ActResult(true, bo);
        }

        static internal ActResult ConfirmDelete(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject)
        {
            return new ActResult(WinUtils.ConfirmDelete(), bo);
        }

        static internal ActResult RefreshData(DbManagerProxy manager, IObject bo, List<object> parameters, IObject ParentObject, BaseListGridControl Grid, List<LaboratorySectionItem> DataSource, EditableList<LaboratorySectionItem> List, BaseListPanel<LaboratorySectionItem> panel, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            DataSourceCopyFrom(List, DataSource);
            Grid.GridView.RefreshData();
            SetReadOnlyColumns(Grid, lclSample, lclTest);
            return true;
        }


        static internal void Refresh(Form parentForm, IObject ParentObject, IObject BusinessObject, BaseListGridControl Grid, IBaseListPanel ibase, Func<List<LaboratorySectionItem>> baseRefresh, EditableList<LaboratorySectionItem> List, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest, Control _this, bool bIsMyPref)
        {
            if ((ParentObject as LaboratorySectionMaster).IsHasChanges(bIsMyPref))
            {
                var res = WinUtils.ConfirmMessage3Buttons(parentForm, BvMessages.Get("msgUnsavedRecordsPrompt"), BvMessages.Get("Confirmation"));
                if (res == DialogResult.Yes)
                {
                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        /*if ((ParentObject.GetAccessor() as IObjectMeta).Actions
                                                                       .FirstOrDefault(c => c.ActionType == ActionTypes.Save)
                                                                       .RunAction(manager, ParentObject).result == false)*/
                        if (((ParentObject as LaboratorySectionMaster).GetAccessor() as LaboratorySectionMaster.Accessor)
                            .PostHalf(manager, ParentObject, bIsMyPref) == false)
                            return;
                    }
                }
                if (res == DialogResult.Cancel)
                {
                    return;
                }
            }

            BindDataSource(ParentObject, BusinessObject, Grid, ibase, baseRefresh(), List, lclSample, lclTest, _this, bIsMyPref);
        }

        static internal void BindDataSource(IObject ParentObject, IObject BusinessObject, BaseListGridControl Grid, IBaseListPanel ibase, List<LaboratorySectionItem> DataSource, EditableList<LaboratorySectionItem> List, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest, Control _this, bool bIsMyPref)
        {
            foreach (var view in Grid.GridControl.ViewCollection)
            {
                if (view is LayoutView)
                {
                    //(view as LayoutView).OptionsSingleRecordMode.StretchCardToViewHeight = true;
                    (view as LayoutView).OptionsSingleRecordMode.StretchCardToViewWidth = true;
                }
            }

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                List.Clear();
                List.AddRange(DataSource.Select(
                    i =>
                    {
                        i.bIsMyPref = bIsMyPref;
                        i.Parent = ParentObject;
                        i.SetupLoad(manager);
                        i.Sample.Add(i);
                        i.Sample.AcceptChanges();
                        i.Test.Add(i);
                        i.Test.AcceptChanges();
                        i.Validation += (sender, args) => ErrorForm.ShowWarningFormat(args.MessageId, null, args.Pars);
                        return i;
                    }).ToList());
                (ParentObject as LaboratorySectionMaster).DeepAcceptChanges(bIsMyPref);


                var item = (BusinessObject as LaboratorySectionItem);
                if (item != null)
                {
                    item.SetupLoad(manager);

                    var column = Grid.GridView.Columns.ColumnByName("strCalculatedCaseID");
                    var edt = new RepositoryItemButtonEdit();
                    column.ColumnEdit = edt;
                    edt.ButtonClick += (sender, args) => ShowCaseOrSessionForm((ibase.FocusedItem as LaboratorySectionItem), _this);


                    BindLookupGrid("idfsSampleStatus", item.SampleStatusFullLookup, Grid, lclSample, lclTest);
                    BindLookupGrid("idfsSampleType", item.SampleTypeLookup, Grid, lclSample, lclTest);
                    BindLookupGrid("idfsAccessionCondition", item.AccessionConditionLookup, Grid, lclSample, lclTest, (o, args) =>
                    {
                        if ((long)args.NewValue == (long)eidss.model.Enums.AccessionConditionEnum.AcceptedInPoorCondition)
                        {
                            using (DbManagerProxy manager1 = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                            {
                                var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager1, ParentObject, LabNewModeEnum.Accept, 0, null, null, null, null);
                                var ret = BaseFormManager.ShowModal(new LaboratorySectionAcceptedInPoorCondition(), obj).DialogResult;
                                if (ret == DialogResult.OK)
                                {
                                    var f = (ibase.FocusedItem as LaboratorySectionItem);
                                    f.strCondition = obj.strComments;
                                }
                                else
                                {
                                    args.Cancel = true;
                                }
                            }
                        }
                        else if ((long)args.NewValue == (long)eidss.model.Enums.AccessionConditionEnum.Rejected)
                        {
                            using (DbManagerProxy manager1 = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                            {
                                var obj = LaboratorySectionItem.Accessor.Instance(null).CreateWithNewMode(manager1, ParentObject, LabNewModeEnum.Accept, 0, null, null, null, null);
                                var ret = BaseFormManager.ShowModal(new LaboratorySectionAcceptedReject(), obj).DialogResult;
                                if (ret == DialogResult.OK)
                                {
                                    var f = (ibase.FocusedItem as LaboratorySectionItem);
                                    f.strCondition = obj.strComments;
                                }
                                else
                                {
                                    args.Cancel = true;
                                }
                            }
                        }
                    });
                    BindLookupGrid("idfsDiagnosis", item.DiagnosisLookup, Grid, lclSample, lclTest);
                    BindLookupGrid("idfsTestName", item.TestNameRefLookup, Grid, lclSample, lclTest);
                    BindLookupGrid("idfsTestStatus", item.TestStatusFullLookup, Grid, lclSample, lclTest);
                    BindLookupGrid("idfsTestResult", item.TestResultDummyLookup, Grid, lclSample, lclTest);
                    BindLookupGrid("idfsTestCategory", item.TestCategoryRefLookup, Grid, lclSample, lclTest);

                    BindFFGrid("strObservation", Grid, lclSample, lclTest);

                    Grid.GridView.CustomRowCellEditForEditing += (sender, args) =>
                    {
                        if (args.Column.Name == "idfsDiagnosis")
                        {
                            var row = Grid.GridView.GetRow(args.RowHandle) as LaboratorySectionItem;
                            if (row != null)
                            {
                                var lookupEdit = new RepositoryItemLookUpEdit();
                                LookupBinder.BindTestDiagnosisRepositoryLookup(lookupEdit, row.DiagnosisForTestLookup);
                                lookupEdit.Closed += (s, a) => SetReadOnlyColumns(Grid, lclSample, lclTest);
                                args.RepositoryItem = lookupEdit;
                            }
                        }
                        else if (args.Column.Name == "idfsTestName")
                        {
                            var row = Grid.GridView.GetRow(args.RowHandle) as LaboratorySectionItem;
                            if (row != null)
                            {
                                var lookupEdit = new RepositoryItemLookUpEdit();
                                LookupBinder.BindTestForDiseaseRepositoryLookup(lookupEdit, row.TestNameRefLookup);
                                lookupEdit.Closed += (s, a) => SetReadOnlyColumns(Grid, lclSample, lclTest);
                                args.RepositoryItem = lookupEdit;
                            }
                        }
                        else if (args.Column.Name == "idfsTestResult")
                        {
                            var row = Grid.GridView.GetRow(args.RowHandle) as LaboratorySectionItem;
                            if (row != null)
                            {
                                var lookupEdit = new RepositoryItemLookUpEdit();
                                LookupBinder.BindTestResultRepositoryLookup(lookupEdit, row.TestResultRefLookup);
                                lookupEdit.Closed += (s, a) => SetReadOnlyColumns(Grid, lclSample, lclTest);
                                args.RepositoryItem = lookupEdit;
                            }
                        }
                        else if (args.Column.Name == "idfsTestStatus")
                        {
                            var row = Grid.GridView.GetRow(args.RowHandle) as LaboratorySectionItem;
                            if (row != null)
                            {
                                var lookupEdit = new RepositoryItemLookUpEdit();
                                LookupBinder.BindBaseRepositoryLookup(lookupEdit, row.TestStatusShortLookup);
                                lookupEdit.Closed += (s, a) => SetReadOnlyColumns(Grid, lclSample, lclTest);
                                args.RepositoryItem = lookupEdit;
                            }
                        }
                        else if (args.Column.Name == "strObservation")
                        {
                            var row = Grid.GridView.GetRow(args.RowHandle) as LaboratorySectionItem;
                            if (row != null)
                            {
                                var lookupEdit = (RepositoryItemPopupContainerEdit)args.RepositoryItem;
                                lookupEdit.PopupControl.Controls.Clear();
                                lookupEdit.Closed += (s, a) => SetReadOnlyColumns(Grid, lclSample, lclTest);
                                var presenter = new FFPresenter(row.FFPresenter);
                                presenter.Dock = DockStyle.Fill;
                                lookupEdit.PopupControl.Controls.Add(presenter);
                                presenter.ShowFlexibleForm();
                                presenter.ReadOnly = row.isTestFinalOrAmend && !row.isTestFinalExternalBefore;
                            }
                        }
                    };

                    Grid.GridView.FocusedRowChanged += (sender, args) => SetReadOnlyColumns(Grid, lclSample, lclTest);
                    SetReadOnlyColumns(Grid, lclSample, lclTest);
                }
            }
        }

        private static void BindFFGrid(string name, BaseListGridControl Grid, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            var column = Grid.GridView.Columns.ColumnByName(name);
            if (column != null)
            {
                var lookupEdit = new RepositoryItemPopupContainerEdit();
                column.ColumnEdit = lookupEdit;
                lookupEdit.Closed += (sender, args) => SetReadOnlyColumns(Grid, lclSample, lclTest);
                var container = new PopupContainerControl();
                lookupEdit.PopupControl = container;
                lookupEdit.PopupSizeable = true;
                lookupEdit.ShowPopupCloseButton = true;
                container.Width = 300;
                container.Height = 400;
            }
        }

        private static void BindLookupGrid(string name, BaseReferenceList list, BaseListGridControl Grid, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest, Action<object, ChangingEventArgs> changingHandling = null)
        {
            var column = Grid.GridView.Columns.ColumnByName(name);
            if (column != null)
            {
                var editor = column.SetLookupEditor();
                if (changingHandling != null)
                    editor.EditValueChanging += (sender, args) => changingHandling(sender, args);
                LookupBinder.BindBaseRepositoryLookup(editor, list);
                editor.Closed += (sender, args) => SetReadOnlyColumns(Grid, lclSample, lclTest);
            }
        }

        private static void BindLookupGrid(string name, List<TestForDiseaseLookup> list, BaseListGridControl Grid, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest, Action<object, ChangingEventArgs> changingHandling = null)
        {
            var column = Grid.GridView.Columns.ColumnByName(name);
            if (column != null)
            {
                var editor = column.SetLookupEditor();
                if (changingHandling != null)
                    editor.EditValueChanging += (sender, args) => changingHandling(sender, args);
                LookupBinder.BindTestForDiseaseRepositoryLookup(editor, list);
                editor.Closed += (sender, args) => SetReadOnlyColumns(Grid, lclSample, lclTest);
            }
        }

        private static void BindLookupGrid(string name, List<DiagnosisLookup> list, BaseListGridControl Grid, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            var column = Grid.GridView.Columns.ColumnByName(name);
            if (column != null)
            {
                var editor = column.SetLookupEditor();
                LookupBinder.BindDiagnosisRepositoryLookup(editor, list, HACode.All);
                editor.Closed += (sender, args) => SetReadOnlyColumns(Grid, lclSample, lclTest);
            }
        }



        static private void DataSourceCopyFrom(EditableList<LaboratorySectionItem> list, List<LaboratorySectionItem> DataSource)
        {
            list.ForEach(c =>
            {
                if (!DataSource.Exists(i => i.ID == c.ID && i.idfsSampleStatus == c.idfsSampleStatus))
                {
                    c.Validation += (sender, args) => ErrorForm.ShowWarningFormat(args.MessageId, null, args.Pars);
                    DataSource.Add(c);
                }
            });
            var l = list.ToList();
            DataSource.RemoveAll(c => !l.Exists(i => i.ID == c.ID && i.idfsSampleStatus == c.idfsSampleStatus));
        }

        private static void BindLookup(LayoutViewColumnList columns, string name, BaseReferenceList list, BaseListGridControl Grid, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            LayoutViewColumn column = columns.FirstOrDefault(c => c.FieldName == name);
            if (column != null)
            {
                var editor = column.SetLookupEditor();
                LookupBinder.BindBaseRepositoryLookup(editor, list);
                editor.Closed += (sender, args) => SetReadOnlyColumns(Grid, lclSample, lclTest);
            }
        }
        private static void BindLookup(LayoutViewColumnList columns, string name, List<DepartmentLookup> list, BaseListGridControl Grid, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            LayoutViewColumn column = columns.FirstOrDefault(c => c.FieldName == name);
            if (column != null)
            {
                var editor = column.SetLookupEditor();
                LookupBinder.BindDepartmentRepositoryLookup(editor, list, true);
                editor.Closed += (sender, args) => SetReadOnlyColumns(Grid, lclSample, lclTest);
            }
        }
        private static void BindLookup(LayoutViewColumnList columns, string name, List<OrganizationLookup> list, BaseListGridControl Grid, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            LayoutViewColumn column = columns.FirstOrDefault(c => c.FieldName == name);
            if (column != null)
            {
                var editor = column.SetLookupEditor();
                LookupBinder.BindOrganizationRepositoryLookup(editor, list, HACode.None);
                editor.Closed += (sender, args) => SetReadOnlyColumns(Grid, lclSample, lclTest);
            }
        }
        private static void BindLookup(LayoutViewColumnList columns, string name, List<PersonLookup> list, BaseListGridControl Grid, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            LayoutViewColumn column = columns.FirstOrDefault(c => c.FieldName == name);
            if (column != null)
            {
                var editor = column.SetLookupEditor();
                LookupBinder.BindPersonRepositoryLookup(editor, list);
                editor.Closed += (sender, args) => SetReadOnlyColumns(Grid, lclSample, lclTest);
            }
        }
        private static void BindLookup(LayoutViewColumnList columns, string name, List<SpeciesVectorInfoLookup> list, BaseListGridControl Grid, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            LayoutViewColumn column = columns.FirstOrDefault(c => c.FieldName == name);
            if (column != null)
            {
                var editor = column.SetLookupEditor();
                LookupBinder.BindSpeciesVectorInfoRepositoryLookup(editor, list);
                editor.Closed += (sender, args) => SetReadOnlyColumns(Grid, lclSample, lclTest);
            }
        }

        private static void BindLookup(LayoutViewColumnList columns, string name, List<FreezerTreeLookup> list, Control _this, BaseListGridControl Grid, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            LayoutViewColumn column = columns.FirstOrDefault(c => c.FieldName == name);
            if (column != null)
            {
                var editor = column.SetLookupEditor();
                BindFreezerLocation(editor, list, _this);
                editor.Closed += (sender, args) => SetReadOnlyColumns(Grid, lclSample, lclTest);
            }
        }

        private static void BindCheckbox(LayoutViewColumnList columns, string name, BaseListGridControl Grid, LayoutViewColumnList lclSample, LayoutViewColumnList lclTest)
        {
            LayoutViewColumn column = columns.FirstOrDefault(c => c.FieldName == name);
            if (column != null)
            {
                var editor = column.SetCheckEditor();
                editor.EditValueChanged += (sender, args) =>
                    {
                        ((sender as CheckEdit).Parent as GridControl).FocusedView.PostEditor();
                        SetReadOnlyColumns(Grid, lclSample, lclTest);
                    };
            }
        }

        private static void BindFreezerLocation(RepositoryItemLookUpEdit ctrl, List<FreezerTreeLookup> list, Control _this)
        {
            ctrl.Buttons.Clear();
            ctrl.Buttons.Add(new EditorButton(ButtonPredefines.Combo));
            ctrl.Buttons[0].Visible = false;
            ctrl.Buttons.Add(new EditorButton(ButtonPredefines.Ellipsis));
            ctrl.Buttons.Add(new EditorButton(ButtonPredefines.Delete));

            ctrl.DataSource = list;
            ctrl.DisplayMember = "Path";
            ctrl.ValueMember = "ID";
            ctrl.NullText = null;
            ctrl.ShowDropDown = ShowDropDown.Never;
            ctrl.UseCtrlScroll = false;

            ctrl.ButtonPressed += (sender, args) =>
            {
                var editor = sender as LookUpEdit;
                if (editor != null)
                {
                    if (args.Button.Kind == ButtonPredefines.Ellipsis)
                    {
                        object id = editor.EditValue;
                        var detail = ClassLoader.LoadClass("FreezerTree") as IApplicationForm;
                        if (detail != null)
                        {
                            if (BaseFormManager.ShowModal(detail, _this, ref id, null, null))
                            {
                                editor.EditValue = id;
                            }
                        }
                    }
                    else if (args.Button.Kind == ButtonPredefines.Delete)
                    {
                        editor.EditValue = null;
                    }
                }
            };
        }

    }
}
