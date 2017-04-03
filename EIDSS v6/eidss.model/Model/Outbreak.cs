using System.Collections.Generic;
using BLToolkit.Data;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
using System.Linq;

namespace eidss.model.Schema
{
    public partial class Outbreak
    {
        public partial class Accessor 
        {
            protected void CheckDiagnosisOnChange(Outbreak obj)
            {
                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    var strWarn = "";
                    var strErr = "";
                    obj.Cases.Where(c => !c.IsMarkedToDelete).ToList().ForEach(c =>
                        {
                            if (obj.idfsDiagnosisOrDiagnosisGroup != null)
                            {
                                var ret = manager.SetCommand("select dbo.fnIsCaseSessionDiagnosesInGroup(@idfCase, @idfsDiagnosisOrDiagnosisGroup)",
                                    manager.Parameter("@idfCase", c.idfCase),
                                    manager.Parameter("@idfsDiagnosisOrDiagnosisGroup", obj.idfsDiagnosisOrDiagnosisGroup))
                                    .ExecuteScalar<long>();
                                if (ret > 0)
                                    strWarn += (strWarn.Length > 0 ? ", " : "") + c.strCaseID;
                                else if (ret == 0)
                                    strErr += (strErr.Length > 0 ? ", " : "") + c.strCaseID;
                            }
                        });
                    if (strErr.Length > 0)
                        throw new ValidationModelException("msgOutbreakDiagnosisErrorCases2", 
                            "idfsDiagnosisOrDiagnosisGroup", "idfsDiagnosisOrDiagnosisGroup", 
                            new object[] { strErr }, GetType(), false, obj);
                    if (strWarn.Length > 0)
                        throw new ValidationModelException("msgUpOutbreakDiagnosisToGroup2",
                            "idfsDiagnosisOrDiagnosisGroup", "idfsDiagnosisOrDiagnosisGroup",
                            new object[]
                                {
                                    obj.DiagnosisLookup.Single(c => c.idfsDiagnosisOrDiagnosisGroup == obj.idfsDiagnosisOrDiagnosisGroup).name,
                                    strWarn,
                                    obj.DiagnosisLookup.Single(i => i.idfsDiagnosisOrDiagnosisGroup == obj.DiagnosisLookup.Single(c => c.idfsDiagnosisOrDiagnosisGroup == obj.idfsDiagnosisOrDiagnosisGroup).idfsDiagnosisGroup).name
                                }, GetType(), true, obj);
                }
            }

            protected void CheckOnAddCase(Outbreak obj, OutbreakCase item)
            {
                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    if (obj.idfsDiagnosisOrDiagnosisGroup != null)
                    {
                        var ret = manager.SetCommand("select dbo.fnIsCaseSessionDiagnosesInGroup(@idfCase, @idfsDiagnosisOrDiagnosisGroup)",
                            manager.Parameter("@idfCase", item.idfCase),
                            manager.Parameter("@idfsDiagnosisOrDiagnosisGroup", obj.idfsDiagnosisOrDiagnosisGroup))
                            .ExecuteScalar<long>();
                        if (ret == 0)
                            throw new ValidationModelException("msgOutbreakDiagnosisErrorCases",
                                "", "", new object[]
                                {
                                    item.strCaseID, 
                                    obj.strOutbreakID,
                                    obj.DiagnosisLookup.Single(c => c.idfsDiagnosisOrDiagnosisGroup == obj.idfsDiagnosisOrDiagnosisGroup).name
                                }, GetType(), false, obj);
                        if (ret > 0)
                            throw new ValidationModelException("msgUpOutbreakDiagnosisToGroup",
                                "", "", new object[]
                                {
                                    obj.DiagnosisLookup.Single(c => c.idfsDiagnosisOrDiagnosisGroup == obj.idfsDiagnosisOrDiagnosisGroup).name,
                                    item.strCaseID,
                                    obj.DiagnosisLookup.Single(c => c.idfsDiagnosisOrDiagnosisGroup == ret).name,
                                    obj.DiagnosisLookup.Single(i => i.idfsDiagnosisOrDiagnosisGroup == obj.DiagnosisLookup.Single(c => c.idfsDiagnosisOrDiagnosisGroup == obj.idfsDiagnosisOrDiagnosisGroup).idfsDiagnosisGroup).name
                                }, GetType(), true, obj);
                    }

                    var strOutbreakID = manager.SetCommand("select dbo.fnIsCaseInOutbreak(@CaseID, @OutbreakID)",
                        manager.Parameter("@CaseID", item.idfCase),
                        manager.Parameter("@OutbreakID", obj.idfOutbreak))
                        .ExecuteScalar<string>();
                    if (!Utils.IsEmpty(strOutbreakID))
                        throw new ValidationModelException(item.idfsCaseType == (long)CaseTypeEnum.Vector ? "msgSessionInOutbreak" : "msgCaseInOutbreak",
                            "", "", new object[]
                                {
                                    item.strCaseID,
                                    strOutbreakID
                                }, GetType(), true, obj);
                }
            }
        }
    }
}