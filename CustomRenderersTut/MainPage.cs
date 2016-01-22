using System;
using Xamarin.Forms;

namespace CustomRenderersTut
{
	public class MainPage: ContentPage
	{
		public MainPage ()
		{
			CustomButton cb = new CustomButton {
				Text = "Custom Button",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Fill
			};
			cb.Clicked += (sender, e) => {
				DisplayAlert("Congratulations", "This button was rendered in a platform-specific class.", "OK");
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				Children = {
					cb
				}
			};
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
		}
	}
}

