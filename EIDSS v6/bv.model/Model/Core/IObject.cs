using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using System.Collections.Specialized;

namespace bv.model.Model.Core
{
    public interface IObject
    {
        object Key { get; }
        bool IsNew { get; }
        bool HasChanges { get; }
        void RejectChanges();
        void DeepRejectChanges();
        void DeepAcceptChanges();
        void SetChange();
        void DeepSetChange();
        bool MarkToDelete();
        bool IsMarkedToDelete { get; }
        string ObjectName { get; }
        string ObjectIdent { get; }
        IObjectAccessor GetAccessor();
        IObjectPermissions GetPermissions();
        IObjectEnvironment Environment { get; set; }
        bool ReadOnly { get; set; }
        bool IsReadOnly(string name);
        bool IsInvisible(string name);
        bool IsRequired(string name);
        bool IsHiddenPersonalData(string name);
        string GetType(string name);
        object GetValue(string name);
        void SetValue(string name, string val);
        CompareModel Compare(IObject o);
        BvSelectList GetList(string name);
        string KeyName { get; }
        string ToStringProp { get; }
        Dictionary<string, string> GetFieldTags(string name);

        event PropertyChangedEventHandler PropertyChanged;

        event ValidationEvent Validation;
        event ValidationEvent ValidationEnd;
        event AfterPostEvent AfterPost;

        IObject Parent { get; }
        IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false);
        void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true);
    }
}
