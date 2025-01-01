using System.Windows.Controls;

using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;
using TR.caMonPageMod.JRCMon.Parts.CarPartsStateArea;
using TR.caMonPageMod.JRCMon.Parts.Unit;

namespace TR.caMonPageMod.JRCMon.Pages.CarState;

[PageTypes.NormalPage("運転詳細", ResourceManager.ResourceFiles.DriverIcon, "ｽｲｯﾁ状態")]
public class CarStateInfo : Canvas, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CAR_STATE_INFO;

	private readonly AppState State;
	public CarStateInfo(AppState state)
	{
		State = state;
		Children.Add(new LocationLabel());
		Children.Add(new TrainFormationImage(state));

		Children.Add(ComponentFactory.Driver.GetAssistLabel());
		Children.Add(new DoorStateArea(state));
	}
}
