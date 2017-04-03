namespace eidss.model.Avr.Commands
{
    public interface ICommandProcessor
    {
        void Process(Command cmd);
    }
}