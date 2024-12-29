using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;
using TR.caMonPageMod.JRCMon.Parts.Unit;

namespace TR.caMonPageMod.JRCMon.Pages.Conductor;

[PageTypes.NormalPage("車　掌", ResourceManager.ResourceFiles.ConductorIcon, "車掌情報")]
public class ConductorInto : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CONDUCTOR_INFO;

	public ConductorInto(AppState state) : base(ResourceManager.ResourceFiles.ConductorInfo)
	{
		Children.Add(new LocationLabel());

		Children.Add(new TrainFormationImage(state));
	}
}
