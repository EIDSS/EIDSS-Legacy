using System;
using System.Reflection;

namespace bv.model.Model.Core
{
    public static class ObjectAccessor
    {
        private static object Instance(Type to)
        {
            if (to == null) return null;

            string name = to.Name;
            string fullname = (to.AssemblyQualifiedName != null) ? to.AssemblyQualifiedName.Replace(name, name + "+Accessor") : String.Empty;
            Type ta = Type.GetType(fullname);

            if (ta == null)
            {
                to = to.BaseType;
                if (to != null)
                {
                    name = to.Name;
                    fullname = (to.AssemblyQualifiedName != null)
                                   ? to.AssemblyQualifiedName.Replace(name, name + "+Accessor")
                                   : String.Empty;
                    ta = Type.GetType(fullname);
                }
            }

            if (ta != null)
            {
                MethodInfo mi = ta.GetMethod("Instance", BindingFlags.Static | BindingFlags.Public);
                if (mi != null)
                {
                    return mi.Invoke(null, new object[] {null});
                }
                //PropertyInfo pi = ta.GetProperty("Instance", BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.Public);
                //if (pi != null)
                //{
                //    return pi.GetValue(null, null);
                //}
            }
            return null;
        }
        private static object Instance<T>() where T : class
        {
            return Instance(typeof(T));
        }


        public static IObjectAccessor AccessorInterface<T>()
            where T : class
        {
            return Instance<T>() as IObjectAccessor;
        }
        public static IObjectAccessor AccessorInterface(Type to)
        {
            return Instance(to) as IObjectAccessor;
        }

        public static IObjectCreator CreatorInterface<T>()
            where T : class
        {
            return Instance<T>() as IObjectCreator;
        }
        public static IObjectCreator CreatorInterface(Type to)
        {
            return Instance(to) as IObjectCreator;
        }

        public static IObjectPost PostInterface<T>()
            where T : class
        {
            return Instance<T>() as IObjectPost;
        }
        public static IObjectPost PostInterface(Type to)
        {
            return Instance(to) as IObjectPost;
        }

        public static IObjectSelectDetail SelectDetailInterface<T>()
            where T : class
        {
            return Instance<T>() as IObjectSelectDetail;
        }
        public static IObjectSelectDetail SelectDetailInterface(Type to)
        {
            return Instance(to) as IObjectSelectDetail;
        }

        public static IObjectDelete DeleteInterface<T>()
            where T : class
        {
            return Instance<T>() as IObjectDelete;
        }
        public static IObjectDelete DeleteInterface(Type to)
        {
            return Instance(to) as IObjectDelete;
        }

        public static IObjectSelectDetailList SelectDetailListInterface<T>()
            where T : class
        {
            return Instance<T>() as IObjectSelectDetailList;
        }
        public static IObjectSelectDetailList SelectDetailListInterface(Type to)
        {
            return Instance(to) as IObjectSelectDetailList;
        }

        public static IObjectSelectList SelectListInterface<T>()
            where T : class
        {
            return Instance<T>() as IObjectSelectList;
        }
        public static IObjectSelectList SelectListInterface(Type to)
        {
            return Instance(to) as IObjectSelectList;
        }

        public static IObjectMeta MetaInterface<T>()
            where T : class
        {
            return Instance<T>() as IObjectMeta;
        }
        public static IObjectMeta MetaInterface(Type to)
        {
            return Instance(to) as IObjectMeta;
        }
        /*
        public static IObjectPermissions PermissionsInterface<T>()
            where T : class
        {
            return Instance<T>() as IObjectPermissions;
        }
        public static IObjectPermissions PermissionsInterface(Type to)
        {
            return Instance(to) as IObjectPermissions;
        }
        */
    }
}
