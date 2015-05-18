using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Threading;
using ImageExtensionsApp.Helpers;
using ImageExtensionsApp.WinPhone.Renderers;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportImageSourceHandler(typeof(UriImageSource), typeof(ImageLoaderSourceHandlerEx))]

namespace ImageExtensionsApp.WinPhone.Renderers
{
	public class ImageLoaderSourceHandlerEx : IImageSourceHandler 
	{
		ImageLoaderSourceHandler _imageLoaderSourceHandler;

		public ImageLoaderSourceHandlerEx()
		{
			_imageLoaderSourceHandler = new ImageLoaderSourceHandler ();
		}

        async public Task<System.Windows.Media.ImageSource> LoadImageAsync(ImageSource imageSource, CancellationToken cancelationToken)
        {
            System.Windows.Media.ImageSource image = await _imageLoaderSourceHandler.LoadImageAsync(imageSource, cancelationToken);
            EventHandler<bool> statusChangedHandler = (EventHandler<bool>)ImageSourceExtensions.GetStatusChangedHandler(imageSource);
            if (statusChangedHandler != null)
            {
                statusChangedHandler(imageSource, image != null);
            }
            return image;
        }
	}
}
