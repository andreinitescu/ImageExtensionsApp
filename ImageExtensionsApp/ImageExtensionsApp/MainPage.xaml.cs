using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ImageExtensionsApp.Helpers;
using System.Diagnostics;

namespace ImageExtensionsApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();

			/*ImageSourceExtensions.SetStatusChangedHandler (Image.Source, (sender, status) => {
				Debug.WriteLine("Image status: {0}", status);
			});*/
		}

        void Image_ImageOpened(object sender, EventArgs args)
        {
                
        }

        void Image_ImageFailed(object sender, EventArgs args)
        {

        }
	}

}

