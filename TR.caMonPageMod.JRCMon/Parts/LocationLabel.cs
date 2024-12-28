using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TR.caMonPageMod.JRCMon.Parts;

class LocationLabel : Grid
{
	const int WIDTH = 207;
	const int HEIGHT = 60;
	const int NUMBER_BOTTOM_MARGIN = 8;
	const int NUMBER_HEIGHT = HEIGHT - NUMBER_BOTTOM_MARGIN;
	const int NUMBER_Y = HEIGHT - NUMBER_HEIGHT - NUMBER_BOTTOM_MARGIN;
	const int DOT_SIZE = 4;
	const int DOT_POS_X = 138;
	const int DOT_POS_Y = 40;
	const int DOT_PADDING = 4;
	const int INTEGER_NUMBER_WIDTH = 72;
	const int DECIMAL_NUMBER_WIDTH = 18;
	const int UNIT_WIDTH = 36;

	const int INTEGER_NUMBER_X = DOT_POS_X - INTEGER_NUMBER_WIDTH - DOT_PADDING;
	const int DECIMAL_NUMBER_X = DOT_POS_X + DOT_SIZE + DOT_PADDING;
	const int UNIT_X = WIDTH - UNIT_WIDTH;

	const double NUMBER_LABEL_MULTIPLIER = 1.5;

	private readonly Label IntegerNumberLabel = ComponentFactory.Get1HalfXLongLabel();
	private readonly Label DecimalNumberLabel = ComponentFactory.Get1HalfXLongLabel();

	public LocationLabel()
	{
		Margin = new(0, 0, 0, 0);
		Width = WIDTH;
		Height = HEIGHT;

		Label label = ComponentFactory.Get1XLabel();
		label.Margin = new(4, 6, 0, 0);
		label.Content = "キロ程";
		Children.Add(label);

		Line line = new()
		{
			X1 = 60,
			Y1 = 54,
			X2 = 207,
			Y2 = 54,
			Stroke = Brushes.White,
			StrokeThickness = 2
		};
		Children.Add(line);

		IntegerNumberLabel.Margin = new(
			INTEGER_NUMBER_X,
			NUMBER_Y,
			0,
			0
		);
		IntegerNumberLabel.Width = INTEGER_NUMBER_WIDTH;
		IntegerNumberLabel.Height = NUMBER_HEIGHT / NUMBER_LABEL_MULTIPLIER;
		IntegerNumberLabel.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
		IntegerNumberLabel.VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom;
		Children.Add(IntegerNumberLabel);

		DecimalNumberLabel.Margin = new(
			DECIMAL_NUMBER_X,
			NUMBER_Y,
			0,
			0
		);
		DecimalNumberLabel.Width = DECIMAL_NUMBER_WIDTH;
		DecimalNumberLabel.Height = NUMBER_HEIGHT / NUMBER_LABEL_MULTIPLIER;
		DecimalNumberLabel.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
		DecimalNumberLabel.VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom;
		Children.Add(DecimalNumberLabel);

		Rectangle dot = new()
		{
			Margin = new(DOT_POS_X, DOT_POS_Y, 0, 0),
			Width = DOT_SIZE,
			Height = DOT_SIZE,
			Fill = Brushes.White,
			HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
			VerticalAlignment = System.Windows.VerticalAlignment.Top,
		};
		Children.Add(dot);

		Label unit = ComponentFactory.Get1HalfXLongLabel();
		unit.Margin = new(UNIT_X, NUMBER_Y, 0, 0);
		unit.Width = UNIT_WIDTH;
		unit.Height = NUMBER_HEIGHT / NUMBER_LABEL_MULTIPLIER;
		unit.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
		unit.VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom;
		unit.Content = "km";
		Children.Add(unit);

		SetLocation_km(12345.6);
	}

	void SetLocation_km(double km)
	{
		int integerValue = (int)km;
		int decimalValue = (int)((km - integerValue) * 10);

		Dispatcher.Invoke(() =>
		{
			IntegerNumberLabel.Content = integerValue.ToString();
			DecimalNumberLabel.Content = decimalValue.ToString();
		});
	}
}
