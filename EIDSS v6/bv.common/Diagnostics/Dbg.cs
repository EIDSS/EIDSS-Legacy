
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using bv.common.Core;
using System.IO;
using System.Linq;
using bv.common.Configuration;
using System.Windows.Forms;

namespace bv.common.Diagnostics
{
    public class Dbg
    {

        //private static Regex s_DebugMethodFilterRegexp;
        //private static bool s_DebugMethodFilterRegexpDefined;
        private static int m_DefaultDetailLevel;

        private Dbg()
        {
            // NOOP
        }

        private static readonly StandardOutput m_StandardOutput = new StandardOutput();
        public static DebugFileOutput CreateDebugFileOutput(string fileName)
        {
            if (!Utils.IsEmpty(fileName))
            {
                DirectoryInfo dir = Directory.GetParent(Application.CommonAppDataPath);
                string logfile = dir.FullName + "\\" + fileName;
                if (IsValidOutputFile(logfile))
                    return new DebugFileOutput(logfile, false);
                logfile = Utils.GetExecutingPath() + fileName;
                if (IsValidOutputFile(logfile))
                    return new DebugFileOutput(logfile, false);
            }
            return null;
        }
        private static IDebugOutput CreateDefaultOutputMethod()
        {
            // TODO: allow configurable output to log file
            m_DefaultDetailLevel = BaseSettings.DebugDetailLevel;
            if (!BaseSettings.DebugOutput)
            {
                return null;
            }
            if (!Utils.IsEmpty(BaseSettings.DebugLogFile))
            {
                var output = CreateDebugFileOutput(BaseSettings.DebugLogFile);
                if (output != null)
                    return output;
            }
            return m_StandardOutput;
        }

        private static bool IsValidOutputFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    FileAttributes attr = File.GetAttributes(fileName);
                    if ((attr & FileAttributes.ReadOnly) != 0)
                    {
                        attr = attr & (~FileAttributes.ReadOnly);
                        File.SetAttributes(fileName, attr);
                    }
                    FileStream fs = File.OpenWrite(fileName);
                    fs.Close();
                }
                else
                {
                    FileStream fs = File.Create(fileName);
                    fs.Close();
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        private static string FormatDataRow(DataRow row)
        {
            var @out = (from DataColumn col in row.Table.Columns
                        select string.Format(":{0} <{1}>", col.ColumnName, FormatValue(row[col]))).ToList();
            return string.Format("#<DataRow {0}>", Utils.Join(" ", @out));
        }

        public static string FormatValue(object value)
        {
            if (value == null)
            {
                return "*Nothing*";
            }
            if (value == DBNull.Value)
            {
                return "*DBNull*";
            }
            var row = value as DataRow;
            if (row != null)
            {
                return FormatDataRow(row);
            }
            var view = value as DataRowView;
            if (view != null)
            {
                return FormatDataRow(view.Row);
            }
            return value.ToString();
        }

        private static IDebugOutput m_OutputMethod;
        public static IDebugOutput OutputMethod
        {
            get
            {
                if (!Config.IsInitialized)
                    Config.InitSettings();
                if (!Config.IsInitialized)
                    return m_StandardOutput;
                return m_OutputMethod ?? (m_OutputMethod = CreateDefaultOutputMethod());
                //Dim result As IDebugOutput = Nothing
                //If InitSlot() Then
                //    result = CType(Thread.GetData(s_OutputMethodSlot), IDebugOutput)
                //Else
                //    result = CreateDefaultOutputMethod()
                //    Thread.SetData(s_OutputMethodSlot, result)
                //End If
                //Return result
            }
            set
            {
                m_OutputMethod = value;
                //InitSlot()
                //Thread.SetData(s_OutputMethodSlot, value)
            }
        }

        private static void DoDbg(int detailLevel, string fmt, params object[] args)
        {
            if (OutputMethod != null)
            {
                var trace = new StackTrace(2, true);

                string methodName = "*UNKNOWN*";
                string declaringMethodName = "*UNKNOWN*";

                if (trace.GetFrame(0) != null)
                {
                    MethodBase method = trace.GetFrame(0).GetMethod();
                    if (method != null)
                    {
                        methodName = method.Name;
                        if (method.DeclaringType != null)
                            declaringMethodName = method.DeclaringType.Name;
                    }
                }
                if (ShouldIgnore(detailLevel))
                {
                    return;
                }
                if (args == null || args.Length == 0)
                {
                    OutputMethod.WriteLine(string.Format("{0} {1}.{2}(): {3}", DateTime.Now, declaringMethodName, methodName, fmt));
                    return;
                }
                var newArgs = new object[args.Length];
                for (int i = 0; i <= args.Length - 1; i++)
                {
                    newArgs[i] = FormatValue(args[i]);
                }
                OutputMethod.WriteLine(string.Format("{0} {1}.{2}(): {3}", DateTime.Now, declaringMethodName, methodName, string.Format(fmt, newArgs)));
            }
        }

        public static void WriteLine(string fmt, params object[] args)
        {
            if (OutputMethod != null)
            {
                var newArgs = new object[args.Length];
                for (int i = 0; i <= args.Length - 1; i++)
                    newArgs[i] = FormatValue(args[i]);
                OutputMethod.WriteLine(args.Length == 0 ? fmt : string.Format(fmt, newArgs));
            }
        }

        public static void Debug(string fmt, params object[] args)
        {
            DoDbg(0, fmt, args);
        }
        public static void ConditionalDebug(int detailLevel, string fmt, params object[] args)
        {
            DoDbg(detailLevel, fmt, args);
        }
        public static void ConditionalDebug(DebugDetalizationLevel detailLevel, string fmt, params object[] args)
        {
            DoDbg((int)detailLevel, fmt, args);
        }

        public static void Fail(string fmt, params object[] args)
        {
            string message = "Assertion failed: " + string.Format(fmt, args);
            DoDbg(0, "{0}", message); // TODO: always print failure messages
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
            throw (new InternalErrorException(message));
        }

        public static void Assert(bool value, string fmt, params object[] args)
        {
            if (!value)
            {
                // we duplicate Fail here to make DoDbg work correctly
                string message = "Assertion failed: " + string.Format(fmt, args);
                DoDbg(0, "{0}", message);
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
                throw (new InternalErrorException(message));
            }
        }

        public static void DbgAssert(bool value, string fmt, params object[] args)
        {
            if (!value)
            {
                // we duplicate Fail here to make DoDbg work correctly
                string message = "Assertion failed: " + string.Format(fmt, args);
                DoDbg(0, "{0}", message);
            }
        }

        public static void DbgAssert(int detailLevel, bool value, string fmt, params object[] args)
        {
            if (!value)
            {
                // we duplicate Fail here to make DoDbg work correctly
                string message = "Assertion failed: " + string.Format(fmt, args);
                DoDbg(detailLevel, "{0}", message);
            }
        }
        // TODO: probably System.Diagnostics.SymbolStore.* can be used to display extended error information
        public static void Require(params object[] values)
        {
            for (int i = 0; i <= values.Length - 1; i++)
            {
                if (values[i] == null)
                {
                    // we duplicate Fail here to make DoDbg work correctly
                    string message = string.Format("Require: value #{0} (starting from 1) is Nothing", i + 1);
                    DoDbg(0, "{0}", message);
                    if (Debugger.IsAttached)
                    {
                        Debugger.Break();
                    }
                    throw (new InternalErrorException(message));
                }
            }
        }

        private static bool ShouldIgnore(int detailLevel)
        {
            return detailLevel > m_DefaultDetailLevel;
        }

        public static void Trace(params object[] argValues)
        {
#if TRACE
            if (OutputMethod == null)
            {
                return;
            }
            var trace = new StackTrace(1, true);
            MethodBase method = null;
            string methodName = "*UNKNOWN*";
            string declaringTypeName = "*UNKNOWN*";

            if (trace.GetFrame(0) != null)
            {
                method = trace.GetFrame(0).GetMethod();
                if (method != null)
                {
                    methodName = method.Name;
                    if (method.DeclaringType != null)
                        declaringTypeName = method.DeclaringType.Name;
                }
            }
            var argStrings = new List<string>();
            if (argValues != null && argValues.Length != 0 && method != null)
            {
                ParameterInfo[] @params = method.GetParameters();
                int numArgs = Math.Min(@params.Length, argValues.Length);
                for (int i = 0; i <= numArgs - 1; i++)
                {
                    string valString = FormatValue(argValues[i]);
                    argStrings.Add(string.Format("{0} = <{1}>", @params[i].Name, valString));
                }
            }
            OutputMethod.WriteLine(string.Format("--> {0}.{1}({2})", declaringTypeName, methodName, Utils.Join(", ", argStrings)));
#endif
        }
    }
}
