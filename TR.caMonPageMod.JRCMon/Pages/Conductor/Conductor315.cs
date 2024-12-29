using TR.caMonPageMod.JRCMon.Footer;
using TR.caMonPageMod.JRCMon.Parts;
using TR.caMonPageMod.JRCMon.Parts.Unit;

namespace TR.caMonPageMod.JRCMon.Pages.Conductor;

[PageTypes.NormalPage("車　掌", ResourceManager.ResourceFiles.ConductorIcon, "３１５")]
public class Conductor315 : NormalPageBase, IFooterInfo
{
	public IReadOnlyList<FooterInfo> FooterInfoList => FooterType.CONDUCTOR_BASE_315;

	public Conductor315(AppState state) : base(ResourceManager.ResourceFiles.Conductor315)
	{
		Children.Add(new LocationLabel());

		Children.Add(new TrainFormationImage(state));
	}
}
