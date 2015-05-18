using System;
using Xamarin.Forms.Platform.Android;
using System.Threading.Tasks;
using Android.Graphics;
using Xamarin.Forms;
using ImageExtensionsApp.Helpers;
using ImageExtensionsApp.Droid.Renderers;
using Android.Content;
using System.Threading;

[assembly: ExportImageSourceHandler(typeof(UriImageSource), typeof(ImageLoaderSourceHandlerEx))]

namespace ImageExtensionsApp.Droid.Renderers
{
	public class ImageLoaderSourceHandlerEx : IImageSourceHandler 
	{
		ImageLoaderSourceHandler _imageLoaderSourceHandler;

		public ImageLoaderSourceHandlerEx()
		{
			_imageLoaderSourceHandler = new ImageLoaderSourceHandler ();
		}

		public async Task<Bitmap> LoadImageAsync (ImageSource imageSource, Context context, CancellationToken cancelationToken = default(CancellationToken))
		{
			Bitmap bitmap = await _imageLoaderSourceHandler.LoadImageAsync(imageSource, context, cancelationToken);
			EventHandler<bool> statusChangedHandler = (EventHandler<bool>)ImageSourceExtensions.GetStatusChangedHandler (imageSource);
			if (statusChangedHandler != null) {
				statusChangedHandler (imageSource, bitmap != null);	
			}
			return bitmap;
		}
	}
}

