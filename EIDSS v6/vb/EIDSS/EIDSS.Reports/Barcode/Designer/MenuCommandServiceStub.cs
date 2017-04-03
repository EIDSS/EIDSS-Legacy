using System;
using System.ComponentModel.Design;

namespace EIDSS.Reports.Barcode.Designer
{
    public class MenuCommandServiceStub : IMenuCommandService
    {
        public void AddCommand(MenuCommand command)
        {
        }

        public void AddVerb(DesignerVerb verb)
        {
        }

        private void HandlerStub(object senrer, EventArgs e)
        {
        }

        public MenuCommand FindCommand(CommandID commandID)
        {
            return new MenuCommand(HandlerStub, new CommandID(Guid.NewGuid(), -1));
        }

        public bool GlobalInvoke(CommandID commandID)
        {
            return true;
        }

        public void RemoveCommand(MenuCommand command)
        {
        }

        public void RemoveVerb(DesignerVerb verb)
        {
        }

        public void ShowContextMenu(CommandID menuID, int x, int y)
        {
        }

        public DesignerVerbCollection Verbs
        {
            get { return new DesignerVerbCollection(); }
        }
    }
}