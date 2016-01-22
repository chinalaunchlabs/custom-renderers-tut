using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CustomRenderersTut;
using CustomRenderersTut.Droid;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace CustomRenderersTut.Droid
{
	public class CustomButtonRenderer: ButtonRenderer
	{
		/*
		 * Override this method to replace the control's behavior with your own
		 * customized platform-specific behavior.
		 * 
		 * eg. 
		 * 	If replacing entire control:
		 * 	if (Control != null) {
		 * 		SetNativeControl(new YourCustomizedControl());
		 * 	}
		 */
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e) {
			base.OnElementChanged (e);

			if (Control != null) {
				Control.SetBackgroundColor (global::Android.Graphics.Color.Chocolate);
			}
		}

	}
}

