
namespace bv.model.ResourcesUsage
{
    public class FormDescriptionLink
    {
        #region Constructors
        public FormDescriptionLink(string form, string view)//FormDescription form, string view)
        {
            Form = form;
            View = view;
            Obsolete = false;
        }
        public FormDescriptionLink(string form, string view, bool obsolete)//FormDescription form, string view)
        {
            Form = form;
            View = view;
            Obsolete = obsolete;
        }
        #endregion

        #region Properties
        public string Form//FormDescription Form
        {
            get;
            set;
        }

        public string View
        {
            get;
            set;
        }

        public bool Obsolete
        {
            get;
            set;
        }
        #endregion

        #region IObject
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to FormDescriptionLink return false.
            var p = obj as FormDescriptionLink;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return Form == p.Form && View == p.View;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
