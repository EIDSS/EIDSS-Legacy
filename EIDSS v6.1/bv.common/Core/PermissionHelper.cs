using System;
using System.Text;

namespace bv.common.Core
{
    public class PermissionHelper
    {
        public const string AccessToPersonalData = ".Access To Personal Data";
        public const string Select = ".Select";
        public const string Insert = ".Insert";
        public const string Update = ".Update";
        public const string Delete = ".Delete";
        public const string Execute = ".Execute";

        public static string PersonalDataPermission(Enum permObj)
        {
            return permObj + AccessToPersonalData;
        }

        public static string SelectPermission(Enum permObj)
        {
            return permObj + Select;
        }

        public static string SelectPermission(Enum[] permObj)
        {
            var permString = new StringBuilder();
            foreach (Enum obj in permObj)
            {
                if (permString.Length != 0)
                {
                    permString.Append("|");
                }
                permString.Append(SelectPermission(obj));
            }
            return permString.ToString();
        }

        public static string InsertPermission(Enum permObj)
        {
            return permObj + Insert;
        }

        public static string InsertPermission(Enum[] permObj)
        {
            var permString = new StringBuilder();
            foreach (Enum obj in permObj)
            {
                if (permString.Length != 0)
                {
                    permString.Append("|");
                }
                permString.Append(InsertPermission(obj));
            }
            return permString.ToString();
        }

        public static string UpdatePermission(Enum permObj)
        {
            return permObj + Update;
        }

        public static string UpdatePermission(Enum[] permObj)
        {
            var permString = new StringBuilder();
            foreach (Enum obj in permObj)
            {
                if (permString.Length != 0)
                {
                    permString.Append("|");
                }
                permString.Append(UpdatePermission(obj));
            }
            return permString.ToString();
        }

        public static string DeletePermission(Enum permObj)
        {
            return permObj + Delete;
        }

        public static string DeletePermission(Enum[] permObj)
        {
            var permString = new StringBuilder();
            foreach (Enum obj in permObj)
            {
                if (permString.Length != 0)
                {
                    permString.Append("|");
                }
                permString.Append(DeletePermission(obj));
            }
            return permString.ToString();
        }

        public static string ExecutePermission(Enum permObj)
        {
            return permObj + Execute;
        }

        public static string ExecutePermission(Enum[] permObj)
        {
            var permString = new StringBuilder();
            foreach (Enum obj in permObj)
            {
                if (permString.Length != 0)
                {
                    permString.Append("|");
                }
                permString.Append(ExecutePermission(obj));
            }
            return permString.ToString();
        }
    }
}