namespace CustomActions.UI
{
  internal interface IDialog
  {
    string Name { get; }
    string BackProperty { get; }
    string NextProperty { get; }
  }
}