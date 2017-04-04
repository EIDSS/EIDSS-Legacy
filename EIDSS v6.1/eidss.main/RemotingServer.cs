using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using bv.common.Diagnostics;
using bv.common.Configuration;
using eidss.remoting;

namespace eidss.main
{
	public class RemotingServer
	{
		
		private static TcpChannel m_Channel;
		public static void Init()
		{
			m_Channel = new TcpChannel(RemoteEventManager.TcpPort);
			ChannelServices.RegisterChannel(m_Channel, false);
			RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteEventManager), RemoteEventManager.Uri, WellKnownObjectMode.Singleton);
            Dbg.Debug("Remote server is initialized with port {0} and uri {1}", RemoteEventManager.TcpPort, RemoteEventManager.Uri);
			var pi = new Process();
			try
			{
				if (BaseSettings.DontStartClient != true)
				{
				    var path = Path.GetDirectoryName(Application.ExecutablePath);
                    if (path != null)
                    {
                        pi.StartInfo.FileName = path + "\\eidss_clientagent.exe";
                        pi.StartInfo.WorkingDirectory = path;
                        pi.Start();
                    }
				}
			}
			catch (Exception ex)
			{
				Dbg.Debug("can\'t start EIDSS_ClientAgent: {0}", ex);
			}
			
		}
		
		public static void DeInit()
		{
			
		}
		
	}
	
}
