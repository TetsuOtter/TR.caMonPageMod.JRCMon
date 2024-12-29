using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;
using TR.caMonPageMod.JRCMon.Parts.Unit;

namespace TR.caMonPageMod.JRCMon.Pages.Conductor;

[PageTypes.NormalPage("車　掌", ResourceManager.ResourceFiles.ConductorIcon, "副設定")]
public class ConductorAC_Sub : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CONDUCTOR_AIR_COND;

	public ConductorAC_Sub(AppState state) : base(ResourceManager.ResourceFiles.ConductorAC_Sub)
	{
		Children.Add(new LocationLabel());

		Children.Add(new TrainFormationImage(state));
	}
}
