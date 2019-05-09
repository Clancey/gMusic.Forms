using System;
using gMusic.Server;
using System.Net.Sockets;
using System.Net;

namespace gMusic {
	public class LocalWebServer : Server.WebServer
	{

		public static LocalWebServer Shared { get; set; } = new LocalWebServer ();

		public LocalWebServer (int webServerPort = 0) : base (webServerPort)
		{
			
		}
		public override void RegisterRoutes ()
		{
			Router.AddRoute<MediaStreamingRoute> ();
		}

	}
}

