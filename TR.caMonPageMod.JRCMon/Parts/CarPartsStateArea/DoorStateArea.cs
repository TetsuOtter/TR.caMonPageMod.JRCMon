using System.Windows.Controls;

using TR.caMonPageMod.JRCMon.Parts.CarPartsState;

namespace TR.caMonPageMod.JRCMon.Parts.CarPartsStateArea;

public class DoorStateArea : Canvas
{
	const int SEMIAUTO_LABEL_TOP = Constants.FONT_SIZE_2X / 2;
	const int SEMIAUTO_LABEL_LEFT = StateAreaConstants.LEFT + Constants.FONT_SIZE_2X * 3 + 5;

	BitmapLabel semiAutoLabel = ComponentFactory.Get1XLabel();
	public DoorStateArea(AppState state)
	{
		StateAreaConstants.setTop(this, 0);

		BitmapLabel toheiLabel = ComponentFactory.Get2XLabel();
		toheiLabel.Text = "戸　閉";
		SetLeft(toheiLabel, StateAreaConstants.LEFT);
		Children.Add(toheiLabel);

		semiAutoLabel.Text = "半自動";
		SetTop(semiAutoLabel, SEMIAUTO_LABEL_TOP);
		SetLeft(semiAutoLabel, SEMIAUTO_LABEL_LEFT);
		Children.Add(semiAutoLabel);

		int carIndex = 0;
		foreach (var trainFormation in state.TrainFormation ?? [])
		{
			foreach (var carInfo in trainFormation.CarInfoList)
			{
				Children.Add(new DoorState(carIndex++, StateAreaConstants.STATE_TOP));
			}
		}
	}
}
