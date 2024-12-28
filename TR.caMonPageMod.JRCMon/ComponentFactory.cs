using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using TR.caMonPageMod.JRCMon.Parts;

namespace TR.caMonPageMod.JRCMon;

public class ComponentFactory
{
	public static Label GetBasicLabel(Brush? foreground = null) => new()
	{
		Margin = new(0),
		Padding = new(0),
		FontFamily = Constants.FONT_FAMILY,
		FontSize = Constants.FONT_SIZE_1X,
		Foreground = foreground ?? Brushes.White,
		HorizontalAlignment = HorizontalAlignment.Left,
		VerticalAlignment = VerticalAlignment.Top,
#if DEBUG
		Background = new SolidColorBrush(Color.FromArgb(0x50, 0, 0xFF, 0)),
#endif
	};
	public static Label Get1XLabel(Brush? foreground = null) => GetBasicLabel(foreground);
	public static Label Get1HalfXLabel(Brush? foreground = null)
	{
		Label label = GetBasicLabel(foreground);
		label.FontSize = Constants.FONT_SIZE_1_HALF_X;
		return label;
	}
	public static Label Get2XLabel(Brush? foreground = null)
	{
		Label label = GetBasicLabel(foreground);
		label.FontSize = Constants.FONT_SIZE_2X;
		return label;
	}
	public static Label Get1XLongLabel(Brush? foreground = null)
	{
		Label label = GetBasicLabel(foreground);
		label.LayoutTransform = new ScaleTransform(1, 1.5);
		return label;
	}
	public static Label Get1XLong2Label(Brush? foreground = null)
	{
		Label label = GetBasicLabel(foreground);
		label.LayoutTransform = new ScaleTransform(1, 2);
		return label;
	}
	public static Label Get1HalfXLongLabel(Brush? foreground = null)
	{
		Label label = Get1HalfXLabel(foreground);
		label.LayoutTransform = new ScaleTransform(1, 1.5);
		return label;
	}
	public static Label Get2XLongLabel(Brush? foreground = null)
	{
		Label label = GetBasicLabel(foreground);
		label.FontSize = Constants.FONT_SIZE_2X;
		label.LayoutTransform = new ScaleTransform(1, 1.5);
		return label;
	}

	public static readonly Color BASIC_BUTTON_COLOR = Color.FromArgb(0xFF, 0x0B, 0x62, 0xED);
	public static System.Drawing.Color WpfColorToDrawingColor(Color color) => System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);

	private static ControlTemplate template
	{
		get
		{
			FrameworkElementFactory border = new(typeof(Border));
			border.SetValue(Border.BorderBrushProperty, Brushes.Transparent);
			border.SetBinding(Border.BackgroundProperty, new Binding("Background") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) });

			FrameworkElementFactory contentPresenter = new(typeof(ContentPresenter));
			contentPresenter.SetValue(ContentPresenter.ContentProperty, new TemplateBindingExtension(Button.ContentProperty));
			contentPresenter.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
			contentPresenter.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
			border.AppendChild(contentPresenter);

			ControlTemplate template = new(typeof(Button))
			{
				VisualTree = border
			};
			return template;
		}
	}
	public static readonly Style EmptyButtonStyle = new(typeof(Button))
	{
		Setters =
		{
			new Setter(Control.TemplateProperty, template),
			#if DEBUG
			new Setter(Control.BackgroundProperty, new SolidColorBrush(Color.FromArgb(0x50, 0xFF, 0, 0))),
			#else
			new Setter(Control.BackgroundProperty, Brushes.Transparent),
			#endif
		},
	};

	public static Button GetEmptyButton(Thickness margin, double Width, double Height) => new()
	{
		Style = EmptyButtonStyle,
		Margin = margin,
		Width = Width,
		Height = Height,
		VerticalAlignment = VerticalAlignment.Top,
		HorizontalAlignment = HorizontalAlignment.Left,
	};

	public static Button GetBasicButton(Thickness margin, int Width, int Height, bool isSmall = false, Color? color = null, bool isShadowColored = false)
	{
		Button button = GetEmptyButton(margin, Width, Height);
		button.Background = new ImageBrush(ButtonBaseImage.GetButtonImage(Width, Height, isSmall, WpfColorToDrawingColor(color ?? BASIC_BUTTON_COLOR), isShadowColored))
		{
			Stretch = Stretch.Fill,
		};

		return button;
	}
	public static Button GetBasicButton(Thickness margin, int Width, int Height, ContentControl label, bool isSmall = false, Color? color = null, bool isShadowColored = false)
	{
		Button button = GetBasicButton(margin, Width, Height, isSmall, color, isShadowColored);
		button.Content = label;
		return button;
	}

	public static Button GetRedReplacedImgButton(ResourceManager.ResourceFiles resource, Thickness margin, Color? color = null)
	{
		BitmapImage img = RedReplacer.GetImage(resource, WpfColorToDrawingColor(color ?? Colors.Black));
		Button button = GetEmptyButton(margin, img.PixelWidth, img.PixelHeight);
		button.Background = new ImageBrush(img)
		{
			Stretch = Stretch.Fill,
		};
		return button;
	}
	public static Button GetRedReplacedImgButton(ResourceManager.ResourceFiles resource, Thickness margin, ContentControl label, Color? color = null)
	{
		Button button = GetRedReplacedImgButton(resource, margin, color);
		button.Content = label;
		return button;
	}
}
