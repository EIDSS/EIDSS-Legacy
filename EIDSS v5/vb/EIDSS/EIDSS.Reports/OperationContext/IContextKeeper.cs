namespace EIDSS.Reports.OperationContext
{
    public interface IContextKeeper
    {
        Context CreateNewContext(string contextName);
        bool ContainsContext(string contextName);
    }
}