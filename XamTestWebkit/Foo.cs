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

	public class OwinBasedProtocol : NSUrlProtocol
	{
		public OwinBasedProtocol (IntPtr ptr)
			: base (ptr)
		{
		}

		public OwinBasedProtocol (NSUrlRequest request, NSCachedUrlResponse cachedResponse, NSUrlProtocolClient client)
			: base (request, cachedResponse, client)
		{
		}

		[Export ("canInitWithRequest:")] 
		public static new bool CanInitWithRequest (NSUrlRequest request)
		{ 
			return true;
		}

		[Export ("canonicalRequestForRequest:")] 
		public static new NSUrlRequest GetCanonicalRequest (NSUrlRequest forRequest)
		{ 
			return forRequest; 
		}

		public override void StartLoading ()
		{ 
			var data = NSData.FromString (new OwinServer ().Get ());

			using (var response = new NSUrlResponse (Request.Url, "text/html", (int)data.Length, "utf8")) {
				Client.ReceivedResponse (this, response, NSUrlCacheStoragePolicy.NotAllowed);
				Client.DataLoaded (this, data);
				Client.FinishedLoading (this);
			}
		}

		public override void StopLoading ()
		{ 
		}
	}
}
