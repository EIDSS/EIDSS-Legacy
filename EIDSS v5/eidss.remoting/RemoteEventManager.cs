using System.Data;
using System.Collections;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System;
using System.Runtime.InteropServices;
using System.Reflection;

namespace eidss.remoting
{
	public delegate void ShowEventDetailHandler(object EventID);
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]public interface IRemoteServer
		{
		void ShowEventDetail(object EventId);
		object MainForm{
			get;
			set;
		}
		
	}
	
	public class RemoteEventManager : MarshalByRefObject, IRemoteServer
	{
		
		private static System.Timers.Timer m_Timer;
		private static Queue m_EventsQueue = new Queue();
		public const string Uri = "EIDSS_RemotingServer";
		
		public RemoteEventManager()
		{
			Console.WriteLine("RemoteEventManager activated");
		}
		private static RemoteEventManager m_Singleton = new RemoteEventManager();
		public static RemoteEventManager Singleton
		{
			get
			{
				return m_Singleton;
			}
		}
		
		
		public void ShowEventDetail(object EventID)
		{
			if (m_Timer == null)
			{
				m_Timer = new System.Timers.Timer();
				m_Timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
			}
			m_EventsQueue.Enqueue(EventID);
			m_Timer.Start();
		}
		
		private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			m_Timer.Stop();
			object EventID = null;
			if (m_EventsQueue.Count > 0)
			{
				EventID = m_EventsQueue.Dequeue();
			}
			if (EventID != null)
			{
				System.Reflection.MethodInfo mi;
				mi = Singleton.MainForm.GetType().GetMethod("ShowEventDetail");
				if (mi != null)
				{
					Delegate d = Delegate.CreateDelegate(typeof(ShowEventDetailHandler), Singleton.MainForm, mi);
					//We should call ShowEventDetail in the thread of main application,
					//to do this use Invoke method of main application form
					((System.Windows.Forms.Control) Singleton.MainForm).Invoke(d, new object[] {EventID});
				}
			}
			if (m_EventsQueue.Count > 0)
			{
				m_Timer.Start();
			}
		}
		
		
		private object m_MainForm;
		public object MainForm
		{
			get
			{
				return m_MainForm;
			}
			set
			{
				m_MainForm = value;
			}
		}
		
		public static string RemoteURL
		{
			get
			{
				return string.Format("tcp://localhost:{0}/{1}", TcpPort, Uri);
			}
		}
		private static int m_port = 0;
		public static int TcpPort
		{
			get
			{
				if (m_port == 0)
				{
					m_port = System.Convert.ToInt32(bv.common.Configuration.BaseSettings.TcpPort);
				}
				return m_port;
			}
		}
	}
	
	
}
