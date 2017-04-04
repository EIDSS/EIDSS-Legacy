using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;

using bv.common;
using bv.common.db;

namespace EIDSS
{
	public class ObjectAccessDetail_DB : BaseDbService
	{
		public override System.Data.DataSet GetDetail(object ID)
		{
            base.GetDetail(ID);
            m_IsNewObject = false;
            return new System.Data.DataSet();
		}
	
		public override bool PostDetail(DataSet ds, int postType, IDbTransaction transaction)
		{
			base.PostDetail (ds, postType, transaction);
			return true;
		}
	}
}
