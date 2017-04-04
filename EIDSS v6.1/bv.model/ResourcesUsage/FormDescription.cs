using System.Collections.Generic;

namespace bv.model.ResourcesUsage
{
    public class FormDescription
    {
        #region Constructors
        public FormDescription()
        {
            Views = new Dictionary<string, ViewDescription>();
            Paths = new List<string>();
            Obsolete = false;
        }
        #endregion

        #region Properties
        public string Key
        {
            get;
            set;
        }

        public string Caption
        {
            get;
            set;
        }

        public string FormID
        {
            get;
            set;
        }

        public string Apptype
        {
            get;
            set;
        }

        public Dictionary<string, ViewDescription> Views
        {
            get;
            set;
        }

        public string ViewsString
        {
            get
            {
                string views = "";
                foreach (ViewDescription v in Views.Values)
                    views += v.Key + ", ";
                return views.TrimEnd(new char[] { ',', ' ' });
            }
        }

        public List<string> Paths
        {
            get;
            set;
        }

        public string PathsString
        {
            get
            {
                string path = "";
                foreach (string p in Paths)
                    path += p + ", ";
                return path.TrimEnd(new char[] { ',', ' ' });
            }
            set
            {
                Paths.Clear();
                string[] paths = value.Split(new char[] { ',' });
                foreach (string path in paths)
                {
                    if(path.Trim().Length > 0)
                        Paths.Add(path.Trim());
                }
            }
        }

        public string Comment
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

        public bool AddView(string key)
        {
            if (!Views.ContainsKey(key))
            {
                Views.Add(key, new ViewDescription(key));
                return true;
            }
            return false;
        }

        public void DeleteView(string key)
        {
            Views.Remove(key);
        }

        #region IObject
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to FormDescription return false.
            var p = obj as FormDescription;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            if(!(Key == p.Key && Caption == p.Caption && FormID == p.FormID && Apptype == p.Apptype && Comment == p.Comment))
                return false;
            if(Views.Count != p.Views.Count)
                return false;
            foreach (string key in Views.Keys)
            {
                if (!p.Views.ContainsKey(key) || !Views[key].Equals(p.Views[key]))
                    return false;
            }
            if(Paths.Count != p.Paths.Count)
                return false;
            for (int i = 0; i < Paths.Count; i++)
            {
                if (!Paths[i].Equals(p.Paths[i]))
                    return false;
            }
                
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }

    public class ViewDescription
    {
        #region Constructors
        public ViewDescription(string key)
        {
            Key = key;
        }
        public ViewDescription(string key, string comment)
        {
            Key = key;
            Comment = comment;
        }
        #endregion

        #region Properties
        public string Key
        {
            get;
            set;
        }
        public string Path
        {
            get;
            set;
        }
        public string Comment
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

            // If parameter cannot be cast to ViewDescription return false.
            var p = obj as ViewDescription;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return Key == p.Key && Comment == p.Comment;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
