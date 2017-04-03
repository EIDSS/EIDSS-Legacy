using System.Reflection;
using System.Collections;

using BLToolkit.TypeBuilder;

namespace BLToolkit.EditableObjects
{
	public interface IMemberwiseEditable
	{
		[return: ReturnIfTrue] bool AcceptMemberChanges([PropertyInfo] PropertyInfo propertyInfo, string memberName);
		[return: ReturnIfTrue] bool RejectMemberChanges([PropertyInfo] PropertyInfo propertyInfo, string memberName);
        [return: ReturnIfTrue] bool CancelMemberLastChanges([PropertyInfo] PropertyInfo propertyInfo, string memberName); // BVChanges: adding CancelMemberLastChanges method
		[return: ReturnIfTrue] bool IsDirtyMember      ([PropertyInfo] PropertyInfo propertyInfo, string memberName, ref bool isDirty);

		void GetDirtyMembers([PropertyInfo] PropertyInfo propertyInfo, ArrayList list);
	}
}
