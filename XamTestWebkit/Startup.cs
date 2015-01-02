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
	public class Startup
	{
		public void Configuartion (IAppBuilder builder)
		{
			builder.Run (context => {
				context.Response.ContentType = "text/plain";
				return context.Response.WriteAsync ("Hello World");
			});
		}
	}

	
}
