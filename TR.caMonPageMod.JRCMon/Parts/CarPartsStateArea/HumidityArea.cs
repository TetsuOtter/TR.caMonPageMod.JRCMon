using System.Windows.Controls;
using System.Windows.Media;

using TR.caMonPageMod.JRCMon.Parts.CarPartsState;

namespace TR.caMonPageMod.JRCMon.Parts.CarPartsStateArea;

public class HumidityArea : Canvas
{
	static readonly Brush FOREGROUND = Brushes.Aqua;
	public static readonly int TOP = TemperatureArea.TOP + Constants.FONT_SIZE_1X + StateAreaConstants.AREA_PADDING;
	public HumidityArea(AppState state)
	{
		SetTop(this, TOP);
		Console.WriteLine("HumidityArea: TOP = " + TOP);

		BitmapLabel label = ComponentFactory.Get1XWideLabel();
		label.Text = "湿度(％)";
		label.Foreground = FOREGROUND;
		SetLeft(label, StateAreaConstants.LEFT);
		Children.Add(label);

		int carIndex = 0;
		foreach (var trainFormation in state.TrainFormation ?? [])
		{
			foreach (var carInfo in trainFormation.CarInfoList)
			{
				CarPartsTextOnlyState stateComponent = new(carIndex++, StateAreaConstants.STATE_TOP)
				{
					Text = "12",
					Foreground = FOREGROUND,
				};
				stateComponent.Width -= Constants.FONT_SIZE_1X;
				Children.Add(stateComponent);
			}
		}
	}
}
