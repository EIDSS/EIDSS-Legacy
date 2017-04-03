using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BLToolkit
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ComplexBindingPropertiesAttribute : Attribute
    {
        public ComplexBindingPropertiesAttribute(string dataSource){}
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ToolboxBitmapAttribute : Attribute
    {
        public ToolboxBitmapAttribute(Type t){}
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class AttributeProviderAttribute : Attribute
    {
        public AttributeProviderAttribute(Type type){}
    }

    [AttributeUsage(AttributeTargets.All)]
    public sealed class BindableAttribute : Attribute
    {
        public BindableAttribute(bool bindable){}
        public static readonly BindableAttribute No;
        public static readonly BindableAttribute Yes;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class ConfigurationCollectionAttribute : Attribute
    {
        public ConfigurationCollectionAttribute(Type itemType){}
    }


    public interface ICancelAddNew
    {
        void CancelNew(int itemIndex);
        void EndNew(int itemIndex);
    }



    public class BindingSource
    {
        public object DataSource { get; set; }
    }


    public abstract class ConfigurationElement
    {
        protected virtual ConfigurationPropertyCollection Properties { get { return null; } }
        protected virtual bool OnDeserializeUnrecognizedAttribute(string name, string value) { return false; }
        protected internal object this[ConfigurationProperty prop] { get { return null; } set {} }
    }

    public class ConfigurationPropertyCollection : ICollection, IEnumerable
    {
        public void Add(ConfigurationProperty property){}
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    public abstract class ConfigurationElementCollection : ConfigurationElement, ICollection, IEnumerable
    {
        protected internal ConfigurationElement BaseGet(object key) { return null; }
        protected internal ConfigurationElement BaseGet(int index) { return null; }
        protected virtual ConfigurationElement CreateNewElement() { return null; }
        protected virtual object GetElementKey(ConfigurationElement element) { return null; }
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public sealed class ConfigurationProperty
    {
        public ConfigurationProperty(string name, Type type, object defaultValue){}
        public ConfigurationProperty(string name, Type type, object defaultValue, ConfigurationPropertyOptions options){}
    }

    [Flags]
    public enum ConfigurationPropertyOptions
    {
        None = 0,
        IsDefaultCollection = 1,
        IsRequired = 2,
        IsKey = 4,
        IsTypeStringTransformationRequired = 8,
        IsAssemblyStringTransformationRequired = 16,
        IsVersionCheckRequired = 32,
    }

    public abstract class ConfigurationSection : ConfigurationElement
    {
        
    }

    public static class ConfigurationManager
    {
        public static object GetSection(string sectionName) { return null; }
    }


    public class TraceSwitch
    {
        public TraceSwitch(string displayName, string description, string defaultSwitchValue){}
        public string DisplayName { get { return ""; } }
        public bool TraceError { get { return false; }}
        public bool TraceInfo { get { return false; } }
        public bool TraceVerbose { get { return false; } }
        public bool TraceWarning { get { return false; } }

    }
}