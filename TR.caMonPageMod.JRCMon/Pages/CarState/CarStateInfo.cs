using System.Windows.Controls;

using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;
using TR.caMonPageMod.JRCMon.Parts.CarPartsState;
using TR.caMonPageMod.JRCMon.Parts.Unit;

namespace TR.caMonPageMod.JRCMon.Pages.CarState;

[PageTypes.NormalPage("運転詳細", ResourceManager.ResourceFiles.DriverIcon, "ｽｲｯﾁ状態")]
public class CarStateInfo : Canvas, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CAR_STATE_INFO;

	const int TOHEI_LABEL_TOP = ComponentFactory.Driver.ASSIST_LABEL_TOP - Constants.FONT_SIZE_2X - 8;
	const int TOHEI_LABEL_LEFT = ComponentFactory.Driver.ASSIST_LABEL_LEFT + 6;

	const int DOOR_STATE_TOP = TOHEI_LABEL_TOP + 5;

	readonly List<DoorState> DoorStates = [];
	private readonly AppState State;
	public CarStateInfo(AppState state)
	{
		State = state;
		Children.Add(new LocationLabel());
		Children.Add(new TrainFormationImage(state));

		Children.Add(ComponentFactory.Driver.GetAssistLabel());

		BitmapLabel toheiLabel = ComponentFactory.Get2XLabel();
		toheiLabel.Text = "戸　閉";
		SetTop(toheiLabel, TOHEI_LABEL_TOP);
		SetLeft(toheiLabel, TOHEI_LABEL_LEFT);
		Children.Add(toheiLabel);

		int carIndex = 0;
		foreach (var trainFormation in State.TrainFormation ?? [])
		{
			foreach (var carInfo in trainFormation.CarInfoList)
			{
				DoorState doorState = new(carIndex++, DOOR_STATE_TOP);
				DoorStates.Add(doorState);
				Children.Add(doorState);
			}
		}
	}
}
