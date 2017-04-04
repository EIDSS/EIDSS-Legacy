using System;
using System.Collections.Generic;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace bv.winclient.Layout
{
    public class ActionEventArgs : EventArgs
    {
        public DbManagerProxy Manager { get; set; }
        public IObject BussinessObject{ get; set; }
        public List<object> Parameters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        public ActionEventArgs(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            Manager = manager;
            BussinessObject = bo;
            Parameters = parameters;
        }
    }
}
