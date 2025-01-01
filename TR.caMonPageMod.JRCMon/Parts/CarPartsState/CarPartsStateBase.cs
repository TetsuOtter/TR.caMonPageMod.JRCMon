using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using TR.caMonPageMod.JRCMon.Parts.Unit;

namespace TR.caMonPageMod.JRCMon.Parts.CarPartsState;

public class CarPartsStateBase : Canvas
{
	public const int STROKE_THICKNESS = 1;
	public const int MARGIN_X = 3 - STROKE_THICKNESS;
	public const int INNER_WIDTH = CarImageGen.WIDTH - ((MARGIN_X + STROKE_THICKNESS) * 2);
	public const int INNER_HEIGHT = Constants.FONT_SIZE_1X + 3;
	public const int OUTER_WIDTH = INNER_WIDTH + (STROKE_THICKNESS * 2);
	public const int OUTER_HEIGHT = INNER_HEIGHT + (STROKE_THICKNESS * 2);
	public const int LABEL_TOP = 1;
	readonly BitmapLabel label = ComponentFactory.Get1XLabel();
	public CarPartsStateBase(int carIndex, int top)
	{
		Margin = new(MARGIN_X, 0, MARGIN_X, 0);
		Width = OUTER_WIDTH;
		Height = OUTER_HEIGHT;

		SetLeft(this, TrainFormationImage.LEFT + (CarImageGen.WIDTH * carIndex));
		SetTop(this, top);

		Rectangle rect = new()
		{
			Width = OUTER_WIDTH,
			Height = OUTER_HEIGHT,
			Stroke = Brushes.White,
			StrokeThickness = STROKE_THICKNESS,
		};
		Children.Add(rect);

		label.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
		label.VerticalContentAlignment = System.Windows.VerticalAlignment.Top;
		label.Width = INNER_WIDTH;
		label.Height = INNER_HEIGHT - LABEL_TOP;
		SetLeft(label, STROKE_THICKNESS);
		SetTop(label, STROKE_THICKNESS + LABEL_TOP);
		Children.Add(label);
	}

	public string Text
	{
		get => label.Text;
		set => label.Text = value;
	}

	public Brush Foreground
	{
		get => label.Foreground;
		set => label.Foreground = value;
	}
}
