using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TR.caMonPageMod.JRCMon;

public class ComponentFactory
{
	public static Label GetBasicLabel(Brush? foreground = null) => new()
	{
		FontFamily = Constants.FONT_FAMILY,
		FontSize = Constants.FONT_SIZE_1X,
		Foreground = foreground ?? Brushes.White,
		HorizontalAlignment = HorizontalAlignment.Left,
		VerticalAlignment = VerticalAlignment.Top,
	};
	public static Label Get1XLabel(Brush? foreground = null) => GetBasicLabel(foreground);
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
	public static Label Get1XLong3Label(Brush? foreground = null)
	{
		Label label = GetBasicLabel(foreground);
		label.LayoutTransform = new ScaleTransform(1, 2.5);
		return label;
	}
	public static Label Get2XLongLabel(Brush? foreground = null)
	{
		Label label = GetBasicLabel(foreground);
		label.FontSize = Constants.FONT_SIZE_2X;
		label.LayoutTransform = new ScaleTransform(1, 1.5);
		return label;
	}

	private static ControlTemplate template
	{
		get
		{
			FrameworkElementFactory border = new(typeof(Border));
#if DEBUG
			border.SetValue(Border.BackgroundProperty, new SolidColorBrush(Color.FromArgb(0x50, 0xFF, 0, 0)));
#else
			border.SetValue(Border.BackgroundProperty, Brushes.Transparent);
#endif
			border.SetValue(Border.BorderBrushProperty, Brushes.Transparent);

			ControlTemplate template = new(typeof(Button))
			{
				VisualTree = border
			};
			return template;
		}
	}
	private static readonly Style EmptyButtonStyle = new(typeof(Button))
	{
		Setters =
		{
			new Setter(Control.TemplateProperty, template),
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
	public static Button GetFooterMenuButton(int right, bool isFullPage = false) => new()
	{
		Style = EmptyButtonStyle,
		Margin = new(
			Constants.DISPLAY_WIDTH - Constants.FOOTER_MENU_BUTTON_WIDTH - right,
			(isFullPage ? Constants.DISPLAY_HEIGHT : Constants.BODY_HEIGHT) - Constants.FOOTER_MENU_BUTTON_HEIGHT - 5,
			right,
			5
		),
		Width = Constants.FOOTER_MENU_BUTTON_WIDTH,
		Height = Constants.FOOTER_MENU_BUTTON_HEIGHT,
	};
}
