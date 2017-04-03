using System;
using System.Globalization;
using System.Reflection;
using bv.common.Diagnostics;



namespace bv.common.Core
{
	public class ReflectionHelper
	{
		
		private ReflectionHelper()
		{
			// NOOP
		}
		
		public static void SetProperty(object obj, string name, object val)
		{
			Type type = obj.GetType();
			PropertyInfo pInfo = type.GetProperty(name);
			Dbg.Assert(!(pInfo == null), "unable to find property {0} for type {1}", name, obj.GetType());
			
			Type targetType = pInfo.PropertyType;
			if (! targetType.IsAssignableFrom(val.GetType())) //targetType Is val.GetType() Then
			{
				if (targetType.IsEnum)
				{
					val = Enum.Parse(targetType, val.ToString());
				}
				else
				{
					val = Convert.ChangeType(val, targetType, CultureInfo.InvariantCulture);
				}
			}
			pInfo.SetValue(obj, val, null);
		}
		
		public static object GetProperty(object obj, string name, BindingFlags flags)
		{
			Type type = obj.GetType();
			PropertyInfo pInfo = type.GetProperty(name, flags);
			Dbg.Assert(!(pInfo == null), "unable to find property {0} for type {1}", name, obj.GetType());
			return pInfo.GetValue(obj, null);
		}
		public static bool HasProperty(object obj, string name, BindingFlags flags)
		{
			Type type = obj.GetType();
			PropertyInfo pInfo = type.GetProperty(name, flags);
			return !(pInfo == null);
		}
		
		public static object GetProperty(object obj, string name)
		{
			Type type = obj.GetType();
			PropertyInfo pInfo = type.GetProperty(name);
			Dbg.Assert(!(pInfo == null), "unable to find property {0} for type {1}", name, obj.GetType());
			return pInfo.GetValue(obj, null);
		}
		public static bool HasProperty(object obj, string name)
		{
			Type type = obj.GetType();
			PropertyInfo pInfo = type.GetProperty(name);
			return !(pInfo == null);
		}

        public static bool HasMethod(object obj, string name)
        {
            Type type = obj.GetType();
            MethodInfo mInfo = type.GetMethod(name);
            return !(mInfo == null);
        }
        public static object InvokeMethod(object obj, string name, object[] @params)
		{
			Type type = obj.GetType();
			MethodInfo mInfo = type.GetMethod(name);
			Dbg.Assert(!(mInfo == null), "unable to find method {0} for type {1}", name, obj.GetType());
			return mInfo.Invoke(obj, @params);
		}
	}
	
	
}
