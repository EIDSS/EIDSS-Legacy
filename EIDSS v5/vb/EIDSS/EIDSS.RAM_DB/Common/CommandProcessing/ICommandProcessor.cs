using EIDSS.RAM_DB.Common.CommandProcessing.Commands;

namespace EIDSS.RAM_DB.Common.CommandProcessing
{
    public interface ICommandProcessor
    {
        void Process(Command cmd);
    }
}