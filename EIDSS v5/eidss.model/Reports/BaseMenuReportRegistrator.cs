using System;
using System.Linq;
using System.Reflection;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Enums;

namespace eidss.model.Reports
{
    public abstract class BaseMenuReportRegistrator
    {
        private IMenuAction m_HumanCategory;
        private IMenuAction m_VetCategory;
        private IMenuAction m_LabCategory;
        private IMenuAction m_AdminCategory;

        #region Properties

        protected IMenuAction HumanCategory
        {
            get
            {
                return m_HumanCategory ??
                       (m_HumanCategory = RegisterSubMenu("MenuHumanReports", EIDSSPermissionObject.HumanCase, 10000));
            }
        }

        protected IMenuAction VetCategory
        {
            get
            {
                return m_VetCategory ??
                       (m_VetCategory = RegisterSubMenu("MenuVetReports", EIDSSPermissionObject.VetCase, 20000));
            }
        }

        protected IMenuAction LabCategory
        {
            get
            {
                return m_LabCategory ??
                       (m_LabCategory = RegisterSubMenu("MenuLaboratoryReports", EIDSSPermissionObject.Sample, 25000));
            }
        }

        protected IMenuAction AdminCategory
        {
            get
            {
                return m_AdminCategory ??
                       (m_AdminCategory = RegisterSubMenu("MenuAdministrativeReports", EIDSSPermissionObject.Report, 30000));
            }
        }

        #endregion

        protected abstract void RegisterReport(IMenuAction category, MenuReportDescriptionAttribute attribute, MethodInfo info);

        protected abstract IMenuAction RegisterSubMenu(string resourceKey, EIDSSPermissionObject permission, int order);


        protected void RegisterAllReports()
        {
            foreach (MethodInfo info in typeof (IReportFactory).GetMethods())
            {
                MenuReportDescriptionAttribute attribute = GetMenuActionDescriptionAttribute(info);

                if (!IsDenyInDescription(attribute) && !IsDenyInDataGroup(info) && !IsDenyInCustomization(info))
                {
                    IMenuAction category;
                    if (TryGetSubMenuCategory(attribute.SubMenu, out category))
                    {
                        RegisterReport(category, attribute, info);
                    }
                }
            }
        }


        protected internal static bool IsDenyInDescription(MenuReportDescriptionAttribute attribute)
        {
            if (attribute == null)
            {
                return true;
            }

            bool denyPermission = (attribute.Permission != 0 &&
                                   !EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(attribute.Permission)) &&
                                   !EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(attribute.Permission)));
            return denyPermission;
        }

        protected internal static bool IsDenyInDataGroup(MethodInfo info)
        {
            Utils.CheckNotNull(info, "handler");

            var attribute = (ForbiddenDataGroupAttribute)
                            info.GetCustomAttributes(typeof (ForbiddenDataGroupAttribute), true).FirstOrDefault();
            return (attribute != null) && attribute.DataGroups.Any(g => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(g));
        }

        protected internal static bool IsDenyInCustomization(MethodInfo info)
        {
            Utils.CheckNotNull(info, "handler");

            var attribute = (MenuReportCustomizationAttribute)
                            info.GetCustomAttributes(typeof (MenuReportCustomizationAttribute), true).FirstOrDefault();

            // If system has DTRA customization, 
            // if no attribute set - report denied
            // if  attribute set and has no DTRA customization flag - report denied 
            // if  attribute set and has DTRA customization flag - report allowed 
            if (EidssSiteContext.Instance.IsDTRACustomization)
            {
                return attribute == null || (!attribute.PresentInDtraCustomization);
            }

            // if no attribute set - report allowed
            if (attribute == null)
            {
                return false;
            }

            // attribute is set but has no allowed or forbidden countries - report allowed
            var allowedCountry = (long) attribute.AllowedCountry;
            Country[] forbiddenCountry = attribute.ForbiddenCountry ?? new Country[0];
            if (allowedCountry == 0 && forbiddenCountry.Length == 0)
            {
                return false;
            }

            // If allowed country doesn't equal to current country
            // or forbidden country equals to current country  - report denied
            //    EidssSiteContext.Instance.SiteOptions
            long countryID = EidssSiteContext.Instance.CountryID;
            if ((allowedCountry != 0 && allowedCountry != countryID) ||
                forbiddenCountry.Contains((Country) countryID))
            {
                return true;
            }

            return false;
        }

        protected internal static MenuReportDescriptionAttribute GetMenuActionDescriptionAttribute(MethodInfo info)
        {
            Utils.CheckNotNull(info, "info");

            var attribute = (MenuReportDescriptionAttribute)
                            info.GetCustomAttributes(typeof (MenuReportDescriptionAttribute), true).FirstOrDefault();

            return attribute;
        }

        protected bool TryGetSubMenuCategory(ReportSubMenu subMenu, out IMenuAction category)
        {
            category = null;
            switch (subMenu)
            {
                case ReportSubMenu.Admin:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.EventLog)))
                    {
                        return false;
                    }
                    category = AdminCategory;
                    break;
                case ReportSubMenu.Human:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase)))
                    {
                        return false;
                    }
                    category = HumanCategory;
                    break;
                case ReportSubMenu.Lab:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Sample)))
                    {
                        return false;
                    }
                    category = LabCategory;
                    break;
                case ReportSubMenu.Vet:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase)))
                    {
                        return false;
                    }

                    category = VetCategory;
                    break;
                default:
                    throw new ArgumentException(string.Format("{0} is not supportedtype of submenu", subMenu));
            }
            return true;
        }
    }
}