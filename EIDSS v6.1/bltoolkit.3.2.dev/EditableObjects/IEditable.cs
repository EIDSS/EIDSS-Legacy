using BLToolkit.TypeBuilder;

namespace BLToolkit.EditableObjects
{
	public interface IEditable
	{
		void AcceptChanges();
		void RejectChanges();
        void CancelLastChanges(); // BVChanges: adding CancelLastChanges method
        bool IsDirty { [return: ReturnIfTrue] get; }
	}
}
