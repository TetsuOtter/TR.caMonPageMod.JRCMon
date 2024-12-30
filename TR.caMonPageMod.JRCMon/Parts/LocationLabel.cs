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
	const int DOT_POS_Y = 44;
	const int DOT_PADDING = 4;
	const int LINE_X = 60;
	const int LINE_WIDTH = 148;
	const int INTEGER_NUMBER_WIDTH = 72;
	const int DECIMAL_NUMBER_WIDTH = 18;
	const int UNIT_WIDTH = 36;

	const int INTEGER_NUMBER_X = DOT_POS_X - INTEGER_NUMBER_WIDTH;
	const int DECIMAL_NUMBER_X = DOT_POS_X + DOT_SIZE + DOT_PADDING;
	const int UNIT_X = WIDTH - UNIT_WIDTH - 2;

	private readonly Label IntegerNumberLabel = ComponentFactory.Get2XLabel();
	private readonly Label DecimalNumberLabel = ComponentFactory.Get2XLabel();

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
			X1 = LINE_X,
			Y1 = 54,
			X2 = LINE_X + LINE_WIDTH,
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
		IntegerNumberLabel.Height = NUMBER_HEIGHT;
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
		DecimalNumberLabel.Height = NUMBER_HEIGHT;
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

		Label unit = ComponentFactory.Get2XLabel();
		unit.Margin = new(UNIT_X, NUMBER_Y, 0, 0);
		unit.Width = UNIT_WIDTH;
		unit.Height = NUMBER_HEIGHT;
		unit.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
		unit.VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom;
		unit.Content = "km";
		Children.Add(unit);

		SetLocation_km(1234.5);
	}

	void SetLocation_km(double km)
	{
		int integerValue = (int)km;
		int decimalValue = Math.Abs((int)((km - integerValue) * 10));
		string integerStr = integerValue.ToString();
		string decimalStr = decimalValue.ToString();
		if (km <= -1000 || 10000 <= km)
		{
			integerStr = "****";
			decimalStr = "*";
		}

		Dispatcher.Invoke(() =>
		{
			IntegerNumberLabel.Content = integerStr;
			DecimalNumberLabel.Content = decimalStr;
		});
	}
}
