using System;
using System.ComponentModel;

using BLToolkit.Reflection;
using System.Collections.Generic; // BVChanges: support bidirectional binding

namespace BLToolkit.ComponentModel
{
	public class MemberPropertyDescriptor : PropertyDescriptor
	{
		public MemberPropertyDescriptor(Type componentType, string memberName)
			: base(memberName, null)
		{
			_componentType  = componentType;
			_memberAccessor = TypeAccessor.GetAccessor(componentType)[memberName];
		}

		private readonly Type _componentType;
		public  override Type  ComponentType
		{
			get { return _componentType; }
		}

		public override Type PropertyType
		{
			get { return _memberAccessor.Type; }
		}

		private readonly MemberAccessor _memberAccessor;
		public           MemberAccessor  MemberAccessor
		{
			get { return _memberAccessor; }
		}

		public override bool CanResetValue(object component)
		{
			if (PropertyType.IsValueType)
				return TypeAccessor.GetNullValue(PropertyType) != null;
			return PropertyType == typeof(string);
		}

		public override void ResetValue(object component)
		{
			SetValue(component, TypeAccessor.GetNullValue(PropertyType));
		}

		public override object GetValue(object component)
		{
			return component != null? _memberAccessor.GetValue(component): null;
		}

		public override void SetValue(object component, object value)
		{
            if (component != null)
            {
                if (value is DBNull)
                    value = null;

                // BVChanges: begin: _previous logic
                object v = value;
                object c = GetValue(component);
                bool isChanging = v == null ? c != null : v.Equals(c) == false;
                try
                {
                    if (isChanging)
                    {
                        _memberAccessor.SetValue(component, value);
                    }
                }
                catch (Exception)
                {
                }
                // BVChanges: end: _previous logic
                //_memberAccessor.SetValue(component, value);

            }
		}

		public override bool IsReadOnly
		{
			get { return !_memberAccessor.HasSetter; }
		}

		public override bool ShouldSerializeValue(object component)
		{
			return false;
		}

		private         AttributeCollection _attributes;
		public override AttributeCollection  Attributes
		{
			get
			{
				if (_attributes == null)
				{
					object[]    memberAttrs = _memberAccessor.GetAttributes();
					Attribute[] attrs       = new Attribute[memberAttrs == null? 0: memberAttrs.Length];

					if (memberAttrs != null)
						memberAttrs.CopyTo(attrs, 0);

					_attributes = new AttributeCollection(attrs);
				}

				return _attributes;
			}
		}

        // BVChanges: support bidirectional binding - begin
        public override bool SupportsChangeEvents
        {
            get
            {
                return true;
            }
        }

        private Dictionary<object, EventHandler> m_ValueChangedHandlers = new Dictionary<object,EventHandler>();
        public override void AddValueChanged(object component, EventHandler handler)
        {
            INotifyPropertyChanged notify = component as INotifyPropertyChanged;
            if (notify != null)
            {
                lock (m_ValueChangedHandlers)
                {
                    if (!m_ValueChangedHandlers.ContainsKey(component))
                    {
                        m_ValueChangedHandlers.Add(component, handler);
                    }
                }
                notify.PropertyChanged += new PropertyChangedEventHandler(notify_PropertyChanged);
            }

            base.AddValueChanged(component, handler);
        }

        void notify_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            lock (m_ValueChangedHandlers)
            {
                if (m_ValueChangedHandlers.ContainsKey(sender))
                {
                    m_ValueChangedHandlers[sender](sender, e);
                }
            }
        }

        public override void RemoveValueChanged(object component, EventHandler handler)
        {
            INotifyPropertyChanged notify = component as INotifyPropertyChanged;
            if (notify != null)
            {
                notify.PropertyChanged -= new PropertyChangedEventHandler(notify_PropertyChanged);
                lock (m_ValueChangedHandlers)
                {
                    if (m_ValueChangedHandlers.ContainsKey(component))
                    {
                        m_ValueChangedHandlers.Remove(component);
                    }
                }
            }

            base.RemoveValueChanged(component, handler);
        }
        // BVChanges: support bidirectional binding - end
    }
}
