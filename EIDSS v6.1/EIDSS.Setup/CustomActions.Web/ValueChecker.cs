namespace CustomActions
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Linq;
  using System.Text;
  using Microsoft.Deployment.WindowsInstaller;


  public static class ValueChecker
  {
    [CustomAction]
    public static ActionResult MustBeNumber(Session session)
    {
      session.Log("Begin MustBeNumber");

      session[Properties.BadNumber] = null;

      int number;
      var probablyNumber = session[Properties.TestNumber];
      if (string.IsNullOrEmpty(probablyNumber))
      {
        SetBadNumberProperty(session, Properties.EmptyNumber);
      }
      else if (!int.TryParse(probablyNumber, out number))
      {
        SetBadNumberProperty(session, Properties.NotOnlyNumber);
      }
      else if (IsOutsideBounds(session, number))
      {
        SetBadNumberProperty(session, Properties.OutsideBounds);
      }

      return ActionResult.Success;
    }

    private static bool IsOutsideBounds(Session session, int number)
    {
      var numberLowerBoundValue = session[Properties.NumberLowerBound];
      var numberUpperBoundValue = session[Properties.NumberUpperBound];

      return IsOutsideBounds(session, number, numberLowerBoundValue, numberUpperBoundValue);
    }

    private static bool IsOutsideBounds(Session session, int number, string numberLowerBoundValue, string numberUpperBoundValue)
    {
      if (string.IsNullOrEmpty(numberLowerBoundValue) || string.IsNullOrEmpty(numberUpperBoundValue))
      {
        return false;
      }

      int numberLowerBound;
      if (!int.TryParse(numberLowerBoundValue, out numberLowerBound))
      {
        var error = string.Format(
          CultureInfo.InvariantCulture,
          "Lower bound has a value '{0}'. It's not a number!",
          numberLowerBoundValue);
        session.Log(error);
        throw new InstallerException(error);
      }

      int numberUpperBound;
      if (!int.TryParse(numberUpperBoundValue, out numberUpperBound))
      {
        var error = string.Format(CultureInfo.InvariantCulture,
          "Upper bound has a value '{0}'. It's not a number!",
          numberUpperBoundValue);
        session.Log(error);
        throw new InstallerException(error);
      }

      return numberLowerBound > number || number > numberUpperBound;
    }

    private static void SetBadNumberProperty(Session session, string errorMessageProperty)
    {
      session[Properties.BadNumber] = "1";
      session[Properties.BadNumberText] = session.Format(session[errorMessageProperty]);
    }

    private static void SetBadNumberMessage(Session session, string errorMessage)
    {
      session[Properties.BadNumber] = "1";
      session[Properties.BadNumberText] = session.Format(errorMessage);
    }

    [CustomAction]
    public static ActionResult MustBeNumbers(Session session)
    {
      session.Log("Begin MustBeNumbers");

      session[Properties.BadNumber] = null;
      var probablyNumbersProperty = session[Properties.TestNumberSets];
      try
      {
        if (string.IsNullOrEmpty(probablyNumbersProperty))
        {
          throw new ArgumentException();
        }

        var sets = probablyNumbersProperty.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        var testNumberNames = new HashSet<string>();
        var outOfBoundsMessage = new StringBuilder();
        foreach (var splittedSet in sets.Select(pair => pair.Split(',')))
        {
          int number;
          if (string.IsNullOrEmpty(splittedSet[0]) || !int.TryParse(splittedSet[0], out number))
          {
            testNumberNames.Add(splittedSet[1]);
          }
          else if (4 <= splittedSet.Length && IsOutsideBounds(session, number, splittedSet[2], splittedSet[3]))
          {
            outOfBoundsMessage.AppendLine(FormatOutOfBoundsMessage(session, splittedSet));
          }
        }

        SetBadNumbersMessage(session, testNumberNames, outOfBoundsMessage);
      }
      catch (ArgumentException)
      {
        var error = string.Format(
          CultureInfo.InvariantCulture,
          "{0} property must contain sets of the form [property1],<property1 name>,<lower bound1>,<upper bound1>;..;[propertyN],<propertyN name>,<lower boundN>,<upper boundN>",
          Properties.TestNumberSets);
        session.Log(error);
        throw new InstallerException(error);
      }

      return ActionResult.Success;
    }

    private static void SetBadNumbersMessage(Session session, HashSet<string> testNumberNames, StringBuilder outOfBoundsMessage)
    {
      var errorMessage = new StringBuilder();
      
      session[Properties.TestNumberName] = session.Format(string.Join(", ", testNumberNames));
      if (testNumberNames.Any())
      {
        errorMessage.Append(session.Format(session[Properties.NotOnlyNumber]));
        errorMessage.AppendLine();
      }
      errorMessage.Append(outOfBoundsMessage);

      if (0 != errorMessage.Length)
      {
        SetBadNumberMessage(session, errorMessage.ToString());
      }
    }

    private static string FormatOutOfBoundsMessage(Session session, IList<string> splittedSet)
    {
      session[Properties.TestNumberName] = splittedSet[1];
      session[Properties.NumberLowerBound] = splittedSet[2];
      session[Properties.NumberUpperBound] = splittedSet[3];
      return session.Format(session[Properties.OutsideBounds]);
    }
  }
}