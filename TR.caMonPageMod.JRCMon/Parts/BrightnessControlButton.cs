using System.Windows.Controls;
using System.Windows.Media;

namespace TR.caMonPageMod.JRCMon.Parts;

public class BrightnessControlButton : Button
{
	const int WIDTH = 104;
	const int HEIGHT = 28;

	private readonly Label BrightnessValueLabel = ComponentFactory.Get1XLabel();

	public BrightnessControlButton()
	{
		Style = ComponentFactory.EmptyButtonStyle;
		Margin = new(686, 3, 0, 0);
		Width = WIDTH;
		Height = HEIGHT;
		HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
		VerticalAlignment = System.Windows.VerticalAlignment.Top;
		Background = new ImageBrush(ButtonBaseImage.GetButtonImage(
			WIDTH,
			HEIGHT,
			true,
			ComponentFactory.WpfColorToDrawingColor(ComponentFactory.BASIC_BUTTON_COLOR)
		))
		{
			Stretch = Stretch.Fill,
		};

		Label brightnessLabel = ComponentFactory.Get1XLabel();
		brightnessLabel.Content = "輝度";
		brightnessLabel.Width = Constants.FONT_SIZE_1X * 4;
		brightnessLabel.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
		BrightnessValueLabel.Content = "明";
		BrightnessValueLabel.Width = brightnessLabel.Width;
		BrightnessValueLabel.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;

		Content = new Grid()
		{
			Children =
			{
				brightnessLabel,
				BrightnessValueLabel
			},
		};
	}
}
