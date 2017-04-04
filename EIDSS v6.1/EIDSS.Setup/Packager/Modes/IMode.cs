namespace SetupExe.Modes
{
  using System;


  internal interface IMode : IDisposable
  {
    ErrorCode Run();
  }
}