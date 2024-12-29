using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;

namespace TR.caMonPageMod.JRCMon.Pages.CarState;

[PageTypes.NormalPage("運転詳細", ResourceManager.ResourceFiles.MaintenanceIcon, "三相給電")]
public partial class CarStateThreePhase : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CAR_STATE;

	public CarStateThreePhase() : base(ResourceManager.ResourceFiles.CarStateThreePhase)
	{
		Children.Add(new LocationLabel());
	}
}
