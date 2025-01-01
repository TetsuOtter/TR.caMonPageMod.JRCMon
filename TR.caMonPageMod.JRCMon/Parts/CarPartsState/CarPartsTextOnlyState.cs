using TR.caMonPageMod.JRCMon.Parts.Unit;

namespace TR.caMonPageMod.JRCMon.Parts.CarPartsState;

public class CarPartsTextOnlyState : BitmapLabel
{
	const int MARGIN_X = CarPartsStateBase.MARGIN_X + CarPartsStateBase.STROKE_THICKNESS;
	public CarPartsTextOnlyState(int carIndex, int top)
	{
		Margin = new(MARGIN_X, 0, MARGIN_X, 0);
		Width = CarPartsStateBase.INNER_WIDTH;
		Height = CarPartsStateBase.INNER_HEIGHT - CarPartsStateBase.LABEL_TOP;

		SetLeft(this, TrainFormationImage.LEFT + (CarImageGen.WIDTH * carIndex));
		SetTop(this, top);

		HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
	}
}
