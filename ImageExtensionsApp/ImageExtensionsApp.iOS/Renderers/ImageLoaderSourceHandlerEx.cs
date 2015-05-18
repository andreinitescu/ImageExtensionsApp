using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Threading.Tasks;
using ImageExtensionsApp.iOS.Renderers;
using System.Threading;
using ImageExtensionsApp.Helpers;

[assembly: ExportImageSourceHandler(typeof(UriImageSource), typeof(ImageLoaderSourceHandlerEx))]

namespace ImageExtensionsApp.iOS.Renderers
{
	public class ImageLoaderSourceHandlerEx : IImageSourceHandler 
	{
		ImageLoaderSourceHandler _imageLoaderSourceHandler;

		public ImageLoaderSourceHandlerEx()
		{
			_imageLoaderSourceHandler = new ImageLoaderSourceHandler ();
		}

        async public Task<UIImage> LoadImageAsync(ImageSource imageSource, CancellationToken cancelationToken, float scale)
        {
            UIImage image = await _imageLoaderSourceHandler.LoadImageAsync(imageSource, cancelationToken, scale);
            EventHandler<bool> statusChangedHandler = (EventHandler<bool>)ImageSourceExtensions.GetStatusChangedHandler(imageSource);
            if (statusChangedHandler != null)
            {
                statusChangedHandler(imageSource, image != null);
            }
            return image;
        }
	}
}
