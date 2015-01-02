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
	public partial class AppDelegate : NSApplicationDelegate
	{
		MainWindowController mainWindowController;

		public AppDelegate ()
		{
		}

		public override void FinishedLaunching (NSObject notification)
		{
			NSUrlProtocol.RegisterClass (new Class (typeof(OwinBasedProtocol)));

			mainWindowController = new MainWindowController ();
			mainWindowController.Window.MakeKeyAndOrderFront (this);
		}
	}
}

