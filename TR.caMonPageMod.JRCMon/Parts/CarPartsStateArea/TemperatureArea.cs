using System.Windows.Controls;
using System.Windows.Media;

using TR.caMonPageMod.JRCMon.Parts.CarPartsState;

namespace TR.caMonPageMod.JRCMon.Parts.CarPartsStateArea;

public class TemperatureArea : Canvas
{
	static readonly Brush FOREGROUND = Brushes.Yellow;
	public static readonly int TOP = StateAreaConstants.getTop(4) + 4;
	public TemperatureArea(AppState state)
	{
		SetTop(this, TOP);

		BitmapLabel label = ComponentFactory.Get1XWideLabel();
		label.Text = "室温(℃)";
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
					Text = "12.5",
					Foreground = FOREGROUND,
				};
				Children.Add(stateComponent);
			}
		}
	}
}
