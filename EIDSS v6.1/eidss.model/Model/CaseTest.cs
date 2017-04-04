using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace eidss.model.Schema
{
    public partial class CaseTest
    {
        protected static void CustomValidations(CaseTest obj)
        {
            var acc = FFPresenterModel.Accessor.Instance(null);
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc.Validate(manager, obj.FFPresenter, true, false, true);
            }
        }

        /*protected void CheckCanDelete(CaseTest obj)
        {
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                if (!Accessor.Instance(this.m_CS).ValidateCanDelete(manager, obj))
                {
                    throw new ValidationModelException("msgCantDeleteRecord", "_on_delete", "_on_delete", null, null, false);
                }
            }
        }*/
    }
}
