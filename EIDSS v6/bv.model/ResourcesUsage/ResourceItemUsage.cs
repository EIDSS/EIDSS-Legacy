using System;
using System.Collections.Generic;

namespace bv.model.ResourcesUsage
{
    public class ResourceItemUsage
    {
        #region Constructors
        public ResourceItemUsage()
        {
            Forms = new List<FormDescriptionLink>();
        }

        public ResourceItemUsage(string file, string key)
        {
            Forms = new List<FormDescriptionLink>();
            File = file;
            Key = key;
        }

        public ResourceItemUsage(string file, string key, string comment)
        {
            Forms = new List<FormDescriptionLink>();
            File = file;
            Key = key;
            Comment = comment;
        }
        #endregion

        #region Properties
        public string File
        {
            get;
            set;
        }

        public string Key
        {
            get;
            set;
        }

        public string Comment
        {
            get;
            set;
        }

        public List<FormDescriptionLink> Forms
        {
            get;
            set;
        }
        #endregion

        public void AddForm(string form, string view, FormDescriptionList forms)// forms - to check form if it is loaded in list
        {
            // find form-view in loaded list of forms
            FormDescription formD = forms[form];
            if (formD == null)
            {
                // form not found - look for views
                foreach (FormDescription fd in forms)
                {
                    if (fd.Views.ContainsKey(form))
                    {
                        AddFormIn(fd.Key, form);
                    }
                }
            }
            else
            {
                if (String.IsNullOrEmpty(view))
                    AddFormIn(form, "");
                else
                {
                    // form found - look for views
                    if (!formD.Views.ContainsKey(view))
                        formD.AddView(view);
                    AddFormIn(form, view);
                    //else
                    //    AddFormIn(form, view + " not found");
                }
            }
            //throw new Exception(String.Format("ResourceItemUsage.AddForm: Form '{0}' hasn't been loaded to the global list of forms.", form));
        }

        private void AddFormIn(string form, string view)
        {
            // don't add second instance of the pair form-view
            foreach (FormDescriptionLink f in Forms)
            {
                if (f.Form == form && f.View == view)
                {
                    f.Obsolete = false;
                    return;
                }
            }

            Forms.Add(new FormDescriptionLink(form, view));
        }

        #region IObject
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to ResourceItemUsage return false.
            var p = obj as ResourceItemUsage;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            if (!(File == p.File && Key == p.Key && Comment == p.Comment))
                return false;
            if (Forms.Count != p.Forms.Count)
                return false;
            for (int i = 0; i < Forms.Count; i++)
                if (!Forms[i].Equals(p.Forms[i]))
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }

}
