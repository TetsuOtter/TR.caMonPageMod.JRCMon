using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;
using TR.caMonPageMod.JRCMon.Parts.Unit;

namespace TR.caMonPageMod.JRCMon.Pages.Conductor;

[PageTypes.NormalPage("車　掌", ResourceManager.ResourceFiles.ConductorIcon, "サービス")]
public class ConductorService : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList { get; }

	public ConductorService(AppState state) : base(ResourceManager.ResourceFiles.ConductorService)
	{
		Children.Add(new LocationLabel());

		Children.Add(new TrainFormationImage(state));

		FooterInfoList = state.Is315Connected ? FooterType.CONDUCTOR_BASE_315 : FooterType.CONDUCTOR_BASE;
	}
}
