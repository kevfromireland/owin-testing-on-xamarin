using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;
using Owin;
using Microsoft.Owin.Testing;
using Microsoft.Owin;
using System.Threading.Tasks;
using MonoMac.OpenGL;

namespace XamTestWebkit
{

	public class OwinServer
	{
		public string Get ()
		{
			using (TestServer server = TestServer.Create (new Startup ().Configuartion)) 
			{
				return server.HttpClient.GetStringAsync ("http://www.foo.com/").Result;
			}
		}
	}
	
}
