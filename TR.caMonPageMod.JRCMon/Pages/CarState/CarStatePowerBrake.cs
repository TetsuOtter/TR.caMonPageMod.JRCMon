using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;

namespace TR.caMonPageMod.JRCMon.Pages.CarState;

[PageTypes.NormalPage("車両状態", ResourceManager.ResourceFiles.CarInfoIcon, "起動制動")]
public partial class CarStatePowerBrake : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CAR_STATE;

	public CarStatePowerBrake() : base(ResourceManager.ResourceFiles.CarStatePowerBrake)
	{
		Children.Add(new LocationLabel());
	}
}
