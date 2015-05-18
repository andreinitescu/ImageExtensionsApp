using System;
using Xamarin.Forms;
using ImageExtensionsApp.Helpers;

namespace ImageExtensionsApp.Controls
{
    public class ImageEx : Image
    {
        public event EventHandler ImageOpened;
        public event EventHandler ImageFailed;

        protected override void OnPropertyChanging(string propertyName)
        {
            base.OnPropertyChanging(propertyName);
            if (propertyName == "Source")
            {
                OnSourceChanging();
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "Source")
            {
                OnSourceChanged();
            }
        }

        private void OnSourceChanging()
        {
            if (Source != null)
            {
                ImageSourceExtensions.SetStatusChangedHandler(Source, null);
            }
        }

        private void OnSourceChanged()
        {
            if (Source != null)
            {
                ImageSourceExtensions.SetStatusChangedHandler(Source, ImageSourceStatusChanged);
            }
        }

        void ImageSourceStatusChanged(object sender, bool status)
		{
            if (status)
            {
                if (ImageOpened != null)
                {
                    ImageOpened(this, new EventArgs());
                }
            }
			else if (ImageFailed != null)
            {
                ImageFailed(this, new EventArgs());
            }
		}
    }
}

