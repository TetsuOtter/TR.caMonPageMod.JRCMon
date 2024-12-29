using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;
using TR.caMonPageMod.JRCMon.Parts.Unit;

namespace TR.caMonPageMod.JRCMon.Pages.Conductor;

[PageTypes.NormalPage("車　掌", ResourceManager.ResourceFiles.ConductorIcon, "空調ﾓｰﾄﾞ")]
public class ConductorAC : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CONDUCTOR_AIR_COND;

	public ConductorAC(AppState state) : base(ResourceManager.ResourceFiles.ConductorAC)
	{
		Children.Add(new LocationLabel());

		Children.Add(new TrainFormationImage(state));
	}
}
