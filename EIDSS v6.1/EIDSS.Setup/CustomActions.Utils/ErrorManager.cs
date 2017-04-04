namespace CustomActions.Utils
{
  using System.Collections.Generic;
  using System.Linq;


  public sealed class ErrorManager
  {
    private readonly IList<string> m_erroMessages = new List<string>();

    public string Errors
    {
      get { return m_erroMessages.Any() ? string.Join("\r\n", m_erroMessages) : string.Empty; }
    }

    public void Add(string message)
    {
      if (!m_erroMessages.Contains(message))
      {
        m_erroMessages.Add(message);
      }
    }
  }
}