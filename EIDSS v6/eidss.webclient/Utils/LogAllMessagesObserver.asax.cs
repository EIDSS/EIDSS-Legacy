using System;
using System.Diagnostics;
using MvcContrib.PortableAreas;

namespace eidss.webclient.Utils
{
	public class LogAllMessagesObserver : MessageHandler<IEventMessage>
	{
		public override void Handle(IEventMessage message)
		{
			Debug.WriteLine(message);
		}

		public override bool CanHandle(Type type)
		{
			return true;
		}
	}
}