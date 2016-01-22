using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CustomRenderersTut;
using CustomRenderersTut.iOS;
using UIKit;

[assembly: ExportRenderer (typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace CustomRenderersTut.iOS
{
	public class CustomButtonRenderer: ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e) {
			base.OnElementChanged (e);

			if (Control != null) {
				Control.TintColor = UIColor.Yellow;
				Control.BackgroundColor = UIColor.Brown;
			}
		}
	}
}

