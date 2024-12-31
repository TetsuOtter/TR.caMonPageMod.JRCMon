using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TR.caMonPageMod.JRCMon.Parts;

class LocationLabel : Canvas
{
	const int WIDTH = 214;
	const int HEIGHT = 44;

	const int LABEL_TOP = 5;
	const int LABEL_LEFT = 4;

	const int LINE_X = LABEL_LEFT + (Constants.FONT_SIZE_1X * 3) + 1;
	const int LINE_THICKNESS = 1;
	const int LINE_WIDTH = WIDTH - LINE_X;
	const int NUMBER_WIDTH = Constants.FONT_SIZE_2X * 3;
	const int NUMBER_BOTTOM = 4;
	const int NUMBER_PADDING_RIGHT = Constants.FONT_SIZE_2X / 2;
	const int UNIT_RIGHT = 6;

	const int NUMBER_RIGHT = UNIT_RIGHT + Constants.FONT_SIZE_2X + NUMBER_PADDING_RIGHT;

	private readonly BitmapLabel NumberLabel = ComponentFactory.Get2XLabel();

	public LocationLabel()
	{
		Margin = new(0, 0, 0, 0);
		Width = WIDTH;
		Height = HEIGHT;

		BitmapLabel label = ComponentFactory.Get1XLabel();
		SetLeft(label, LABEL_LEFT);
		SetTop(label, LABEL_TOP);
		label.Text = "キロ程";
		Children.Add(label);

		Line line = new()
		{
			X1 = 0,
			Y1 = LINE_THICKNESS / 2,
			X2 = LINE_WIDTH,
			Y2 = LINE_THICKNESS / 2,
			Stroke = Brushes.White,
			StrokeThickness = LINE_THICKNESS
		};
		SetLeft(line, LINE_X);
		SetBottom(line, 0);
		Children.Add(line);

		NumberLabel.Width = NUMBER_WIDTH;
		NumberLabel.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
		SetRight(NumberLabel, NUMBER_RIGHT);
		SetBottom(NumberLabel, NUMBER_BOTTOM);
		Children.Add(NumberLabel);

		BitmapLabel unit = ComponentFactory.Get2XLabel();
		SetRight(unit, UNIT_RIGHT);
		SetBottom(unit, NUMBER_BOTTOM);
		unit.Text = "km";
		Children.Add(unit);

		SetLocation_km(174.3);
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
			NumberLabel.Text = $"{integerStr}.{decimalStr}";
		});
	}
}
