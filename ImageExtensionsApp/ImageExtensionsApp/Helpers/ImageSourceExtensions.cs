using System;
using Xamarin.Forms;

namespace ImageExtensionsApp.Helpers
{
	public class ImageSourceExtensions
	{
		#region StatusChanged property

		public static readonly BindableProperty StatusChangedHandlerProperty = 
			BindableProperty.CreateAttached<ImageSource,EventHandler<bool>> (b => ImageSourceExtensions.GetStatusChangedHandler (b), default(EventHandler<bool>), BindingMode.OneWay);

		public static EventHandler<bool> GetStatusChangedHandler (BindableObject bo)
		{
			return (EventHandler<bool>)bo.GetValue (StatusChangedHandlerProperty);
		}

		public static void SetStatusChangedHandler (BindableObject bo, EventHandler<bool> value)
		{
			bo.SetValue (StatusChangedHandlerProperty, value);
		}

		#endregion
	}
}

