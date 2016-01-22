# This Example
## CustomButton
* Changes the background color of the button to orange/brown on each platform. (Looks hideous on iOS.)

# Custom Renderer Notes
* **Custom renderers** are a bridge between Xamarin.Forms and Xamarin.iOS and Xamarin.Android.
* These can be a *View*, a *Cell* or a *Page*.

## When is a custom renderer necessary?
* When you want to make a small change to a view and X.Forms isn't obliging you.
* A custom control for when you need direct access to an element's platform-specific properties and methods.
* Or when you need to completely replace an X.Forms view with your own custom element.

## Creating a custom renderer
### 1. Preparing the custom element in Xamarin.Forms project
1. Create an element subclass, eg.
```
public class CustomButton: Button {}
```
2. Use the element (eg. `CustomButton`) in a layout in Xamarin.Forms project.

### 2. Creating a custom renderer in each platform-specific project
*These steps occur once for each platform.*

1. Create a custom renderer. Add a custom renderer class to each platform-specific project where you want to make customizations.

2. Add the `[assembly]` attribute outside of namespace declaration to declare the new renderer.

3. Add `using` statements to the renderer class so that the renderer types are resolved.


```
using Xamarin.Forms;
using Xamarin.Forms.Platform.<Platform>;	# replace with relevant platform
using ProjectNamespace;						# replace with project namespace
using ProjectNamespace.<Platform>;			# ^^ 
using UIKit;								# if iOS

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace CustomRenderersTut.Droid
{
	public class CustomButtonRenderer: ButtonRenderer
	{
		# code here...
	}
}
```

## Key Methods
* `OnElementChanged`: fires upon changes to the element and is used for control initialization; set the initial control and its properties

* `OnElementPropertyChanged`: fires upon changes to element properties and is useful for data binding.

* `SetNativeControl`: this method is called manually to replace the entire element with a custom platform-specific control, eg. `SetNativeControl(new YourCustomControl())`.

## Important Properties
* `Control`
	* reference to the platform-specific element (eg. `UIButton`) displayed by the renderer
	* platform-specific properties are available here
	* this object can also be replaced entirely
* `Element`
	* reference to the Xamarin.Forms subclassed element (eg. `CustomButton`)
	* Xamarin.Forms element properties are available here

## Elements, Their Renderers and Platform-Specific Elements
Xamarin.Forms | Renderer | Android | iOS
------------- | -------- | ------- | ----
ContentPage	  | PageRenderer | ViewGroup | UIView
Label | LabelRenderer | TextView | UILabel
Button | ButtonRenderer | Button | UIButton
Entry | EntryRenderer | EditText | UITextField
Image | ImageRenderer | ImageView | UIImageView
BoxView | BoxRenderer | ViewGroup | CGContext
ScrollView | ScrollViewRenderer | ScrollView | UIScrollView
Frame | FrameRenderer | Drawable | UIView
Picker | PickerRenderer | TextView, AlertDialog, NumberPicker | UIPickerView, UIPickerViewModel, UIToolbar, UIBarButtonItems, UITextField
DatePicker, TimePicker | Date/TimePickerRenderer | TextView, AlertDialog | UIDatePicker, UIToolbar, UITextField, UIBarButtonItems
Stepper | StepperRenderer | LinearLayout, Button | UIStepper
Slider | SliderRenderer | SeekBar | UISlider 
Switch | SwitchRenderer | Switch | UISwitch 
ListView | ListViewRenderer | (not yet available) | UITableView
TextCell | TextCellRenderer | LinearLayout, TextView, ImageView | UITableViewCell
EntryCell | EntryCellRenderer | LinearLayout, TextView, EditText | UITableViewCell, UITextField
SwitchCell | SwitchCellRenderer | Switch | UITableViewCell, UISwitch
ImageCell | ImageCellRenderer | TextView, ImageView | UITableViewCell, UIImage
NavigationPage | TabbedRenderer | (none with view pages) | UIViewController, UIView
CarouselPage | CarouselPageRenderer | View | UIScrollView