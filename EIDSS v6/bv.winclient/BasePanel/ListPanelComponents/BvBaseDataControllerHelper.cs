using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.Data;
using DevExpress.Data.Access;
using DevExpress.Data.Helpers;

namespace bv.winclient.BasePanel.ListPanelComponents
{
    class BvBaseDataControllerHelper : BaseDataControllerHelper
    {
        public BvBaseDataControllerHelper(DataControllerBase controller) : base(controller)
        {
        }

        //public override void PopulateColumns()
        //{
        //    base.PopulateColumns();
        //}
        //protected override void PopulateColumn(System.ComponentModel.PropertyDescriptor descriptor)
        //{
        //    base.PopulateColumn(descriptor);
        //}
    }

    class BvListDataControllerHelper : ListDataControllerHelper
    {
        public BvListDataControllerHelper(DataControllerBase controller)
            : base(controller)
        {
        }

        //public override void PopulateColumns()
        //{
        //    base.PopulateColumns();
        //}
        //protected override void PopulateColumn(System.ComponentModel.PropertyDescriptor descriptor)
        //{
        //    base.PopulateColumn(descriptor);
        //}
        //protected override PropertyDescriptorCollection GetPropertyDescriptorCollection()
        //{
        //    PropertyDescriptorCollection coll = GetPropertyDescriptorCollectionCore();
        //    if (coll != null)
        //    {
        //        IDataControllerData2 dc2 = Controller.DataClient as IDataControllerData2;
        //        if (dc2 != null)
        //            coll = dc2.PatchPropertyDescriptorCollection(coll);
        //        if (dc2 == null || dc2.CanUseFastProperties)
        //            coll = DevExpress.Data.Access.DataListDescriptor.GetFastProperties(coll);
        //    }
        //    return coll;
        //}
        //PropertyDescriptorCollection GetPropertyDescriptorCollectionCore()
        //{
        //    if (TypedList != null) return TypedList.GetItemProperties(null);
        //    bool isGenericIListRowType;
        //    Type rowType = GetRowType(out isGenericIListRowType);
        //    object row = null;
        //    if (rowType != null && isGenericIListRowType && typeof(ICustomTypeDescriptor).IsAssignableFrom(rowType) && List.Count > 0)
        //    {
        //        row = GetRow(0);
        //    }
        //    if (rowType == null)
        //    {
        //        row = GetFirstRow();
        //        rowType = row == null ? null : row.GetType();
        //        if (rowType == null) rowType = Controller.ForcedDataRowType;
        //    }
        //    if (DevExpress.Data.Access.ExpandoPropertyDescriptor.IsDynamicType(rowType))
        //    {
        //        return GetExpandoObjectProperties(row == null ? GetFirstRow() : row);
        //    }
        //    PropertyDescriptorCollection coll = null;
        //    if (!Controller.AlwaysUsePrimitiveDataSource && rowType != null && !rowType.Equals(typeof(string)) && !rowType.IsPrimitive && !rowType.IsDefined(typeof(DevExpress.Data.Access.DataPrimitiveAttribute), true))
        //    {
        //        if (row == null)
        //        {
        //            //if (Controller.UseFirstRowTypeWhenPopulatingColumns(rowType))
        //            //{
        //            //    object firstRow = GetFirstRow();
        //            //    if (firstRow != null)
        //            //    {
        //            //        Type firstRowType = firstRow.GetType();
        //            //        if (rowType == null || rowType.IsAssignableFrom(firstRowType))
        //            //            rowType = firstRow.GetType();
        //            //    }
        //            //}
        //            //else
        //            {
        //                PropertyDescriptorCollection collection = TryGetItemProperties();
        //                if (collection != null)
        //                    return collection;
        //            }
        //            coll = TypeDescriptor.GetProperties(rowType);
        //        }
        //        else
        //            coll = TypeDescriptor.GetProperties(row);
        //    }
        //    if (coll == null || coll.Count == 0) coll = CreateSimplePropertyDescriptor();
        //    return coll;
        //}

        //PropertyDescriptorCollection GetExpandoObjectProperties(object row)
        //{
        //    if (row == null) return null;
        //    IDictionary<string, object> properties = row as IDictionary<string, object>;
        //    if (properties == null) return null;
        //    List<PropertyDescriptor> list = new List<PropertyDescriptor>();
        //    foreach (KeyValuePair<string, object> pair in properties)
        //    {
        //        list.Add(new DevExpress.Data.Access.ExpandoPropertyDescriptor(Controller, pair.Key, pair.Value == null ? null : pair.Value.GetType()));
        //    }
        //    return new PropertyDescriptorCollection(list.ToArray());
        //}
        //object GetFirstRow()
        //{
        //    if (List.Count == 0 && this.EditableView != null)
        //        return EditableView.CurrentAddItem;
        //    return List.Count > 0 ? GetRow(0) : null;
        //}

    }
}
