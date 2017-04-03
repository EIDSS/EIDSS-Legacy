using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using bv.common.Configuration;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.Core.Security;
namespace eidss.model.Core
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Contains the information about current system user and provides access to its properties
    /// </summary>
    /// <remarks>
    /// <i>eidss.model.Core.EidssUserContext.User</i> class should be initialized every time when user successfully login to the system and stores
    /// user ID, login, password, access permissions and other properties.
    /// </remarks>
    /// <history>
    /// 	[Mike]	30.03.2006	Created
    /// </history>
    /// -----------------------------------------------------------------------------
    ///
    [Serializable]
    public class EidssUser : IIdentity, IUser
    {
        private IDictionary<string, bool> m_Permissions;

        public IDictionary<string, bool> Permissions
        {
            get { return m_Permissions; }
            set
            {
                m_Permissions = value;
                if (m_Permissions != null)
                {
                    CheckOrganization();
                }
            }
        }

        private IDictionary<string, bool> m_SavedPermissions;
        public void RevokeWritePermissions()
        {
            if (m_SavedPermissions == null)
            {
                m_SavedPermissions = m_Permissions;
                m_Permissions = new Dictionary<string, bool>();
                foreach (var i in m_SavedPermissions)
                {
                    if (i.Key.Contains(".Update") || i.Key.Contains(".Insert") || i.Key.Contains(".Delete"))
                    {
                        m_Permissions.Add(i.Key, false);
                    }
                    else
                    {
                        m_Permissions.Add(i.Key, i.Value);
                    }
                }
            }
        }
        public void RestoreWritePermissions()
        {
            if (m_SavedPermissions != null)
            {
                m_Permissions = m_SavedPermissions;
                m_SavedPermissions = null;
            }
        }


        private IDictionary<string, bool> m_ObjectPermissions;

        public IDictionary<string, bool> ObjectPermissions
        {
            get { return m_ObjectPermissions; }
            set { m_ObjectPermissions = value; }
        }

        public string m_Name = "";

        public string LoginName
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private string m_FullName;

        public string FullName
        {
            get { return m_FullName; }
            set { m_FullName = value; }
        }

        private string m_FirstName;

        public string FirstName
        {
            get { return m_FirstName; }
            set { m_FirstName = value; }
        }

        private string m_SecondName;

        public string SecondName
        {
            get { return m_SecondName; }
            set { m_SecondName = value; }
        }

        private string m_LastName;

        public string LastName
        {
            get { return m_LastName; }
            set { m_LastName = value; }
        }

        private object m_ID;

        public object ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        private object m_OrganizationID;

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets the unique identifier of current user organization
        /// </summary>
        /// <returns>
        /// Returns the unique identifier of current user organization
        /// </returns>
        /// <remarks>
        /// This property works only in assumption that all organization information is stored inside <i>UserInfo</i>
        /// and can be retrieved from it using specific key name (idfInstitution).
        /// </remarks>
        /// <history>
        /// 	[Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public object OrganizationID
        {
            get { return m_OrganizationID; }
            set { m_OrganizationID = value; }
        }

        private string m_Organization;

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets the international abbreviation name of current user organization
        /// </summary>
        /// <returns>
        /// Returns the international abbreviation name of current user organization
        /// </returns>
        /// <remarks>
        /// This property works only in assumption that all organization information is stored inside <i>UserInfo</i>
        /// and can be retrieved from it using specific key name (Abbreviation).
        /// </remarks>
        /// <history>
        /// 	[Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public string Organization
        {
            get { return m_Organization; }
            set
            {
                m_Organization = value;
                CheckOrganization();
            }
        }

        private void CheckOrganization()
        {
            if (!string.IsNullOrEmpty(m_Organization) && UserConfigWriter.Instance.GetItem("Organization") != m_Organization)
            {
                UserConfigWriter.Instance.SetItem("Organization", m_Organization);
                UserConfigWriter.Instance.Save();
                Config.ReloadSettings();
            }
        }
        private object m_EmployeeID = DBNull.Value;

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets the unique identifier of employee that was logged in to the system as current user
        /// </summary>
        /// <returns>
        /// Returns the unique identifier of employee that was logged in to the system as current user
        /// </returns>
        /// <remarks>
        /// This property works only in assumption that employee information is stored inside <i>UserInfo</i>
        /// and can be retrieved from it using specific key name (idfEmployee).
        /// </remarks>
        /// <history>
        /// 	[Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public object EmployeeID
        {
            get { return m_EmployeeID; }
            set { m_EmployeeID = value; }
        }

        public bool HasPermission(string permString)
        {
            if (permString == null || permString.Trim() == "")
            {
                return false;
            }
            if (permString == "Always")
            {
                return true;
            }
            if (Permissions == null)
            {
                return true;
            }
            string[] names = permString.Split(new[] {'|'});
            return names.Any(name => Permissions.ContainsKey(name) && Permissions[name]);
        }

        public bool HasObjectPermission(string permString)
        {
            if (permString == null || permString.Trim() == "")
            {
                return false;
            }
            if (permString == "Always")
            {
                return true;
            }
            if (m_ObjectPermissions == null)
            {
                return true;
            }
            string[] names = permString.Split(new[] {'|'});
            bool containsPermission = false;
            foreach (string name in names)
            {
                if (m_ObjectPermissions.ContainsKey(name))
                {
                    containsPermission = true;
                    if (m_ObjectPermissions[name])
                        return true;
                }
            }
            return !containsPermission;
        }

        public void Clear()
        {
            EmployeeID = null;
            FullName = null;
            LoginName = null;
            ID = null;
            Organization = null;
            OrganizationID = null;
            Permissions = null;
            ObjectPermissions = null;
        }

        private List<PersonalDataGroup> m_ForbiddenPersonalDataGroups = new List<PersonalDataGroup>();

        public void SetForbiddenPersonalDataGroups(List<PersonalDataGroup> list = null, long? idfsCountry = null)
        {
            m_ForbiddenPersonalDataGroups = list ?? (new EidssSecurityManager()).GetPersonalDataGroups();
            m_ForbiddenPersonalDataGroups = m_ForbiddenPersonalDataGroups ?? new List<PersonalDataGroup>();
        }

        public List<PersonalDataGroup> ForbiddenPersonalDataGroups
        {
            get
            {
                return m_ForbiddenPersonalDataGroups ?? new List<PersonalDataGroup>();
            }
        }

        private readonly Dictionary<long, bool> m_DenyDiagnosis = new Dictionary<long, bool>();
        public void SetDenyDiagnosis(List<long> list)
        {
            m_DenyDiagnosis.Clear();
            list.ForEach(c => m_DenyDiagnosis.Add(c, false));
        }
        public Dictionary<long, bool> DenyDiagnosis
        {
            get
            {
                return m_DenyDiagnosis;
            }
        }

        #region IIdentity Interface

        private bool m_IsAuthenticated;
        public bool IsAuthenticated
        {
            get { return (m_IsAuthenticated || ID != null); }
            set { m_IsAuthenticated = value; }
        }

        public string AuthenticationType
        {
            get { return "eidss"; }
        }

        public string Name
        {
            get { return m_Name; }
        }

        #endregion
    }
}
