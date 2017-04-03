using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace eidss.model.Schema
{
    public partial class LabTest
    {
        protected static void CustomValidations(LabTest obj)
        {
            var acc = FFPresenterModel.Accessor.Instance(null);
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc.Validate(manager, obj.FFPresenter, true, false, true);
            }
        }

        /*public LabTest DeepClone()
        {
            LabTest ret = base.Clone() as LabTest;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
            Accessor acc = Accessor.Instance(null);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc._SetupLoad(manager, ret);
            }
            return ret;
        }*/
    }
}
