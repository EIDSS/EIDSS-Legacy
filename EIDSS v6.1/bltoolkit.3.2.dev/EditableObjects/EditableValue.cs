#pragma warning disable 3008
using System;
using System.Collections;
using System.Reflection;
using System.Xml.Serialization; // BVChanges

using BLToolkit.TypeBuilder;

namespace BLToolkit.EditableObjects
{
	[Serializable]
	public struct EditableValue<T>: IEditable, IMemberwiseEditable, IPrintDebugState
	{
        public T _original; // BVChanges: private -> public for serialization
        private T _current;
        public T _previous; // BVChanges: adding _previous field

		public EditableValue(T value)
		{
			_original = value;
			_current  = value;
            _previous = value; // BVChanges: adding _previous field
		}

        // BVChanges: begin: adding OriginalValue property
        public T OriginalValue
        {
            get { return _original; }
        }
        // BVChanges: end OriginalValue property

        // BVChanges: begin: adding PreviousValue property
        public T PreviousValue
        {
            get { return _previous; }
        }
        // BVChanges: end: adding PreviousValue property

        // BVChanges: begin: adding SetVal
        public void SetVal(T val)
        {
            Value = val;
        }
        // BVChanges: end: adding SetVal

	    [GetValue, SetValue]
		public T Value
		{
			get { return _current;  }
			set
            { 
                // BVChanges: begin: _previous logic
                object v = value;
                object c = _current;
                bool isChanging = v == null ? c != null : v.Equals(c) == false;
                if (isChanging)
                {
                    _previous = _current;
                }
                // BVChanges: end: _previous logic
                _current = value;
			}
		}

		#region IEditable Members

		public void AcceptChanges()
		{
			_original = _current;
		}

		public void RejectChanges()
		{
			_current = _original;
		}

        // BVChanges: begin: adding CancelLastChanges method
        public void CancelLastChanges()
        {
            _current = _previous;
        }
        // BVChanges: end: adding CancelLastChanges method

        public bool IsDirty
		{
			get
			{
				object o = _original;
				object c = _current;

				return o == null? c != null: o.Equals(c) == false;
			}
		}

		#endregion

		#region IMemberwiseEditable Members

		public bool AcceptMemberChanges(PropertyInfo propertyInfo, string memberName)
		{
			if (memberName != propertyInfo.Name)
				return false;

			AcceptChanges();

			return true;
		}

		public bool RejectMemberChanges(PropertyInfo propertyInfo, string memberName)
		{
			if (memberName != propertyInfo.Name)
				return false;

			RejectChanges();

			return true;
		}

        // BVChanges: begin: adding CancelMemberLastChanges method
        public bool CancelMemberLastChanges(PropertyInfo propertyInfo, string memberName)
        {
            if (memberName != propertyInfo.Name)
                return false;

            CancelLastChanges();

            return true;
        }
        // BVChanges: end: adding CancelMemberLastChanges method

        public bool IsDirtyMember(PropertyInfo propertyInfo, string memberName, ref bool isDirty)
		{
			if (memberName != propertyInfo.Name)
				return false;

			isDirty = IsDirty;

			return true;
		}

		public void GetDirtyMembers(PropertyInfo propertyInfo, ArrayList list)
		{
			if (IsDirty)
				list.Add(propertyInfo);
		}

		#endregion

		#region IPrintDebugState Members

		public void PrintDebugState(PropertyInfo propertyInfo, ref string str)
		{
			str += string.Format("{0,-20} {1} {2,-40} {3,-40} \r\n",
				propertyInfo.Name, IsDirty? "*": " ", _original, _current);
		}

		#endregion
	}
}
