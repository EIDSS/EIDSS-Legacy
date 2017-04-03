using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Linq;

namespace bv.common.Resources
{
    class BvResourceManagerSerializer : CodeDomSerializer
    {
        public override object Deserialize(IDesignerSerializationManager manager, object codeDomObject)
        {
            CodeDomSerializer baseSerializer = (CodeDomSerializer)manager.GetSerializer(typeof(BvResourceManagerChanger).BaseType, typeof(CodeDomSerializer));
            return baseSerializer.Deserialize(manager, codeDomObject);
        }

        public override object Serialize(IDesignerSerializationManager manager, object value)
        {
            CodeDomSerializer baseSerializer = (CodeDomSerializer)manager.GetSerializer(typeof(BvResourceManagerChanger).BaseType, typeof(CodeDomSerializer)); 
            object codeObject = baseSerializer.Serialize(manager, value);


            if (codeObject is CodeStatementCollection)
            {
                CodeStatementCollection statements = (CodeStatementCollection)codeObject;

                Component component = (Component)value;
                IDesignerHost host = component.Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (host != null)
                {
                    CodeCommentStatement comment = new CodeCommentStatement("Form Is Localizable: " + IsLocalizable(host));
                    statements.Insert(0, comment);
                    if (IsLocalizable(host))
                    {
                        CodeTypeDeclaration classTypeDeclaration = (CodeTypeDeclaration)manager.GetService(typeof(CodeTypeDeclaration));
                        CodeExpression typeofExpression = new CodeTypeOfExpression(classTypeDeclaration.Name);
                        CodeDirectionExpression outResourceExpression = new CodeDirectionExpression(FieldDirection.Out, new CodeVariableReferenceExpression("resources"));
                        CodeExpression rightCodeExpression = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("bv.common.Resources.BvResourceManagerChanger"), "GetResourceManager", new CodeExpression[] { typeofExpression, outResourceExpression });

                        statements.Insert(0, new CodeExpressionStatement(rightCodeExpression));
                    }
                }
            }
            return codeObject;
        }

        private static bool IsLocalizable(IDesignerHost host)
        {
            if (host != null)
            {
                PropertyDescriptor prop = TypeDescriptor.GetProperties(host.RootComponent)["Localizable"];
                if (prop != null && prop.PropertyType == typeof(bool))
                {
                    return (bool)prop.GetValue(host.RootComponent);
                }
            }
            return false;
        }
    }
}
