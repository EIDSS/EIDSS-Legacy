﻿using System.Data.SqlClient;
using System.Linq;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;

namespace EIDSS.Reports.Document.Human.CaseInvestigation {
    
    
    public partial class TherapyDataSet {
    }
}

namespace EIDSS.Reports.Document.Human.CaseInvestigation.TherapyDataSetTableAdapters
{
       public partial class sp_rep_HUM_TherapyTableAdapter

       {

           private SqlTransaction m_Transaction;

           internal SqlTransaction Transaction
           {
               get { return m_Transaction; }
               set
               {
                   m_Transaction = value;
                   BaseAdapter.SetTransaction(Adapter, CommandCollection, value);
               }
           }

           internal int CommandTimeout
           {
               get { return CommandCollection.Select(c => c.CommandTimeout).FirstOrDefault(); }
               set
               {
                   foreach (SqlCommand command in CommandCollection)
                   {
                       command.CommandTimeout = value;
                   }
               }
           }
       }
}